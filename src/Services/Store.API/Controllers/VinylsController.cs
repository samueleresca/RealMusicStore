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
    [Route("api/vinyls")]
    [ApiController]
    public class VinylsController : ControllerBase
    {
        private readonly IStoreViynlRepository _storeViynlRepository;
        private readonly IMapper _autoMapper;

        public VinylsController(IStoreArtistRepository storeArtistRepository, IStoreViynlRepository storeViynlRepository, IStoreGenreRepository storeGenreRepository, IMapper autoMapper)
        {
            _storeViynlRepository = storeViynlRepository;
            _autoMapper = autoMapper;
        }

        // GET api/v1/[controller]/items[?pageSize=3&pageIndex=10]
        [HttpGet("/api/vinyls")]
        [ProducesResponseType(typeof(PaginationResponseModel<StoreVinylListResponseModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(IEnumerable<StoreVinylListResponseModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll([FromQuery]int pageSize = 10, [FromQuery]int pageIndex = 0, [FromQuery] string ids = null)
        {
            if (!string.IsNullOrEmpty(ids))
            {
                return await GetItemsByIds(ids);
            }

            var totalItems = _storeViynlRepository.GetAll().Result.LongCount();

            var itemsOnPage = _storeViynlRepository.GetAll().Result
                .OrderBy(c => c.Title)
                .Paginate(pageIndex, pageSize);

            var model = new PaginationResponseModel<StoreVinylListResponseModel>(
                pageIndex, pageSize, totalItems, _autoMapper.Map<IEnumerable<StoreVinylListResponseModel>>(itemsOnPage));

            return Ok(model);
        }

        [HttpGet("/api/vinyls/{id:int}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(StoreVinylDetailResponseModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetItemById(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var item = await _storeViynlRepository.Find(ci => ci.Id == id);

            if (item.Any())
            {
                return Ok(_autoMapper.Map<IEnumerable<StoreVinylDetailResponseModel>>(item));
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
            var items = await _storeViynlRepository.Find(ci => idsToSelect.Contains(ci.Id));
            return Ok(items);

        }


        [HttpGet("/api/vinyls/genre/{genreId}")]
        [ProducesResponseType(typeof(PaginationResponseModel<StoreVinylDetailResponseModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetByGenreReferencesId(int? genreId, [FromQuery]int pageSize = 10, [FromQuery]int pageIndex = 0)
        {
            if (!genreId.HasValue)
            {
                return NotFound();
            }

            var results = await _storeViynlRepository.Find(ci => ci.GenreId == genreId);

            var totalItems = results
                .LongCount();

            var itemsOnPage = results.AsEnumerable()
                .Paginate(pageIndex, pageSize)
                .ToList();

            var model = new PaginationResponseModel<StoreVinylDetailResponseModel>(
                pageIndex, pageSize, totalItems, _autoMapper.Map<IEnumerable<StoreVinylDetailResponseModel>>(itemsOnPage));

            return Ok(model);
        }

        //POST api/v1/[controller]/items
        [HttpPost("/api/vinyls")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> CreateProduct([FromBody]CreateVinylRequest product)
        {
            if (product == null)
            {
                return BadRequest();
            }

            var result = await _storeViynlRepository.Create(_autoMapper.Map<StoreViynl>(product));
            return CreatedAtAction(nameof(GetItemById), new { id = result.Id }, null);
        }

        //PUT api/v1/[controller]/items
        [HttpPut("/api/vinyls/{id:int}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody]UpdateVinylRequest productToUpdate)
        {
            var catalogItem = await _storeViynlRepository.GetById(id);

            if (catalogItem == null)
            {
                return NotFound(new { Message = $"Item with id {id} not found." });
            }
            // Update current product
            catalogItem = _autoMapper.Map<StoreViynl>(productToUpdate);

            catalogItem.Id = id;
            await _storeViynlRepository.Update(catalogItem);

            return CreatedAtAction(nameof(GetItemById) , new { id }, null);
        }


        //DELETE api/v1/[controller]/id
        [HttpDelete("/api/vinyls/{id:int}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _storeViynlRepository.Find(x => x.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            await _storeViynlRepository.Delete(id);
            return NoContent();
        }

    }
}
