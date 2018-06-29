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

    [Route("api/artists")]
    public class ArtistsController : Controller
    {
        private readonly IStoreArtistRepository _storeArtistRepository;
        private readonly IMapper _autoMapper;

        public ArtistsController(IStoreArtistRepository storeArtistRepository, IMapper autoMapper)
        {
            _storeArtistRepository = storeArtistRepository;
            _autoMapper = autoMapper;
        }


        [HttpGet("/api/artists")]
        [ProducesResponseType(typeof(PaginationResponseModel<StoreArtistListResponseModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(IEnumerable<StoreArtistListResponseModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll([FromQuery]int pageSize = 10, [FromQuery]int pageIndex = 0, [FromQuery] string ids = null)
        {
            if (!string.IsNullOrEmpty(ids))
            {
                return await GetItemsByIds(ids);
            }

            var result = await _storeArtistRepository.GetAll();

            var totalItems = result.LongCount();

            var itemsOnPage = result
                .OrderBy(c => c.ArtistName)
                .Paginate(pageIndex, pageSize);

            var model = new PaginationResponseModel<StoreArtistListResponseModel>(
                pageIndex, pageSize, totalItems, _autoMapper.Map<IEnumerable<StoreArtistListResponseModel>>(itemsOnPage));

            return Ok(model);
        }

        [HttpGet]
        [Route("/api/artists/{id:int}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(StoreArtistListResponseModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetItemById(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var item = await _storeArtistRepository.Find(ci => ci.Id == id);

            if (item.Any())
            {
                return Ok(_autoMapper.Map<IEnumerable<StoreArtistListResponseModel>>(item));
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
            var items = await _storeArtistRepository.Find(ci => idsToSelect.Contains(ci.Id));
            return Ok(items);

        }

        [HttpGet]
        [Route("/api/artists/{artistId}/vinyls/")]
        [ProducesResponseType(typeof(PaginationResponseModel<StoreVinylListResponseModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetByReferencesId(int? artistId, [FromQuery]int pageSize = 10, [FromQuery]int pageIndex = 0)
        {
            if (!artistId.HasValue)
            {
                return NotFound();
            }

            var results = await _storeArtistRepository.GetById(artistId.Value);

            var totalItems = results.Vinyls
                .LongCount();

            var itemsOnPage = results.Vinyls.AsEnumerable()
                .Paginate(pageIndex, pageSize);

            var model = new PaginationResponseModel<StoreVinylListResponseModel>(
                pageIndex, pageSize, totalItems, _autoMapper.Map<IEnumerable<StoreVinylListResponseModel>>(itemsOnPage));

            return Ok(model);
        }

        //POST api/v1/[controller]/items
        [Route("/api/artists")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> CreateArtist([FromBody]CreateArtistRequest request)
        {
            if (request == null)
            {
                return BadRequest();
            }

            var result = await _storeArtistRepository.Create(_autoMapper.Map<StoreArtist>(request));
            return CreatedAtAction(nameof(GetItemById), new { id = result.Id }, null);
        }

        [Route("/api/artists/{id:int}")]
        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] UpdateArtistRequest request)
        {
            var catalogItem = await _storeArtistRepository.GetById(id);

            if (catalogItem == null)
            {
                return NotFound(new { Message = $"Item with id {id} not found." });
            }
            // Update current request
            catalogItem = _autoMapper.Map<StoreArtist>(request);

            catalogItem.Id = id;
            await _storeArtistRepository.Update(catalogItem);

            return CreatedAtAction(nameof(GetItemById), new { id }, null);
        }


        //DELETE api/v1/[controller]/id
        [Route("/api/artists/{id:int}")]
        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _storeArtistRepository.Find(x => x.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            await _storeArtistRepository.Delete(id);
            return NoContent();
        }



    }
}
