using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Store.API.Infrastructure.Extensions;
using Store.API.Models;
using Store.API.Repositories;
using Store.API.Requests;
using Store.API.Responses;

namespace Store.API.Controllers
{

    [Route("api/genres")]
    public class GenresController : Controller
    {
        private readonly IStoreGenreRepository _storeGenreRepository;
        private readonly IStoreViynlRepository _storeViynlRepository;
        private readonly IMapper _autoMapper;

        public GenresController(IStoreGenreRepository storeGenreRepository, IMapper autoMapper, IStoreViynlRepository storeViynlRepository)
        {
            _storeGenreRepository = storeGenreRepository;
            _autoMapper = autoMapper;
            _storeViynlRepository = storeViynlRepository;
        }


        [HttpGet("/api/genres")]
        [ProducesResponseType(typeof(PaginationResponseModel<StoreGenreListResponseModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(IEnumerable<StoreGenreListResponseModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll([FromQuery]int pageSize = 10, [FromQuery]int pageIndex = 0, [FromQuery] string ids = null)
        {
            if (!string.IsNullOrEmpty(ids))
            {
                return await GetItemsByIds(ids);
            }

            var result = await _storeGenreRepository.GetAll();

            var totalItems = result.LongCount();

            var itemsOnPage = result
                .Paginate(pageIndex, pageSize);

            var model = new PaginationResponseModel<StoreGenreListResponseModel>(
                pageIndex, pageSize, totalItems, _autoMapper.Map<IEnumerable<StoreGenreListResponseModel>>(itemsOnPage));

            return Ok(model);
        }

        [HttpGet("/api/genres/{id:int}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(StoreGenreListResponseModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetItemById(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var item = await _storeGenreRepository.Find(ci => ci.Id == id);

            if (item.Any())
            {
                return Ok(_autoMapper.Map<IEnumerable<StoreGenreListResponseModel>>(item));
            }

            return NotFound();
        }

        private async Task<IActionResult> GetItemsByIds(string ids)
        {
            var numIds = ids.Split(',')
                .Select(id => (Ok: int.TryParse(id, out int x), Value: x));
            if (!numIds.All(nid => nid.Ok))
            {
                return BadRequest("ids value invalid. Must be comma-separated list of numbers");
            }

            var idsToSelect = numIds.Select(id => id.Value);
            var items = await _storeGenreRepository.Find(ci => idsToSelect.Contains(ci.Id));
            return Ok(items);

        }

        [HttpGet("/api/genres/{genreId}/vinyls/")]
        [ProducesResponseType(typeof(PaginationResponseModel<StoreVinylListResponseModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetByReferencesId(int? genreId, [FromQuery]int pageSize = 10, [FromQuery]int pageIndex = 0)
        {
            if (!genreId.HasValue)
            {
                return NotFound();
            }

            var results = await _storeViynlRepository.Find(_ => _.GenreId == genreId);

            var totalItems = results
                .LongCount();

            var itemsOnPage = results.AsEnumerable()
                .Paginate(pageIndex, pageSize);

            var model = new PaginationResponseModel<StoreVinylListResponseModel>(
                pageIndex, pageSize, totalItems, _autoMapper.Map<IEnumerable<StoreVinylListResponseModel>>(itemsOnPage));

            return Ok(model);
        }

        //POST api/v1/[controller]/items
        [HttpPost("/api/genres")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> CreateArtist([FromBody] CreateGenreRequest request)
        {
            if (request == null)
            {
                return BadRequest();
            }

            var result = await _storeGenreRepository.Create(_autoMapper.Map<Genre>(request));
            return CreatedAtAction(nameof(GetItemById), new { id = result.Id }, null);
        }

        [HttpPut("/api/genres/{id:int}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] UpdateGenreRequest request)
        {
            var catalogItem = await _storeGenreRepository.GetById(id);

            if (catalogItem == null)
            {
                return NotFound(new { Message = $"Item with id {id} not found." });
            }
            // Update current request
            catalogItem = _autoMapper.Map<Genre>(request);

            catalogItem.Id = id;
            await _storeGenreRepository.Update(catalogItem);

            return CreatedAtAction(nameof(GetItemById), new { id }, null);
        }


        //DELETE api/v1/[controller]/id
        [HttpDelete("/api/genres/{id:int}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _storeGenreRepository.Find(x => x.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            await _storeGenreRepository.Delete(id);
            return NoContent();
        }

    }
}
