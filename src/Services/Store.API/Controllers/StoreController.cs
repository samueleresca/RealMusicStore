using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Store.API.Models;
using Store.API.Repositories;
using Store.API.Requests;
using Store.API.Responses;

namespace Store.API.Controllers
{
    [Route("api/vinyls")]
    [ApiController]
    public class StoreController : ControllerBase
    {

        private readonly IStoreArtistRepository _storeArtistRepository;
        private readonly IStoreViynlRepository _storeViynlRepository;
        private readonly IStoreGenreRepository _storeGenreRepository;
        private IMapper _autoMapper;

        public StoreController(IStoreArtistRepository storeArtistRepository, IStoreViynlRepository storeViynlRepository, IStoreGenreRepository storeGenreRepository, IMapper autoMapper)
        {
            _storeArtistRepository = storeArtistRepository;
            _storeViynlRepository = storeViynlRepository;
            _storeGenreRepository = storeGenreRepository;
            _autoMapper = autoMapper;
        }

        // GET api/v1/[controller]/items[?pageSize=3&pageIndex=10]
        [HttpGet("/api/vinyls")]
        [ProducesResponseType(typeof(PaginationResponseModel<StoreViynl>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(IEnumerable<StoreViynl>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Items([FromQuery]int pageSize = 10, [FromQuery]int pageIndex = 0, [FromQuery] string ids = null)
        {
            if (!string.IsNullOrEmpty(ids))
            {
                return await GetItemsByIds(ids);
            }

            var totalItems = _storeViynlRepository.GetAll().Result.LongCount();

            var itemsOnPage = _storeViynlRepository.GetAll().Result
                .OrderBy(c => c.Title)
                .Skip(pageSize * pageIndex)
                .Take(pageSize)
                .ToList();


            itemsOnPage = ChangeUriPlaceholder(itemsOnPage);

            var model = new PaginationResponseModel<StoreViynl>(
                pageIndex, pageSize, totalItems, itemsOnPage);

            return Ok(model);
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
            items = ChangeUriPlaceholder(items.ToList());
            return Ok(items);

        }

        [HttpGet]
        [Route("/api/vinyls/{id:int}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(StoreViynl), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetItemById(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var item = await _storeViynlRepository.Find(ci => ci.Id == id);

            if (item.Any())
            {
                return Ok(item);
            }

            return NotFound();
        }

        //// GET api/v1/[controller]/items/withname/samplename[?pageSize=3&pageIndex=10]
        //[HttpGet]
        //[Route("[action]/withname/{name:minlength(1)}")]
        //[ProducesResponseType(typeof(PaginationResponseModel<StoreViynl>), (int)HttpStatusCode.OK)]
        //public async Task<IActionResult> Items(string name, [FromQuery]int pageSize = 10, [FromQuery]int pageIndex = 0)
        //{

        //    var totalItems = _storeViynlRepository.Find(c => c.Title.StartsWith(name)).Result.LongCount();

        //    var itemsOnPage = await _storeViynlRepository
        //        .Find(c => c.Title.StartsWith(name));


        //    var paginatedItems = itemsOnPage.Skip(pageSize * pageIndex)
        //          .Take(pageSize)
        //          .ToList();

        //    itemsOnPage = ChangeUriPlaceholder(paginatedItems);

        //    var model = new PaginationResponseModel<StoreViynl>(
        //        pageIndex, pageSize, totalItems, itemsOnPage);

        //    return Ok(model);
        //}

        // GET api/v1/[controller]/items/type/1/brand/null[?pageSize=3&pageIndex=10]
        [HttpGet]
        [Route("/api/vinyls/type/{catalogTypeId}/brand/{catalogBrandId}")]
        [ProducesResponseType(typeof(PaginationResponseModel<StoreViynl>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Items(int? catalogTypeId, int? catalogBrandId, [FromQuery]int pageSize = 10, [FromQuery]int pageIndex = 0)
        {
            var root = (IQueryable<StoreViynl>)_storeViynlRepository;

            if (catalogTypeId.HasValue)
            {
                root = root.Where(ci => ci.ArtistId == catalogTypeId);
            }

            if (catalogBrandId.HasValue)
            {
                root = root.Where(ci => ci.GenreId == catalogBrandId);
            }

            var totalItems = root
                .LongCount();

            var itemsOnPage = root
                .Skip(pageSize * pageIndex)
                .Take(pageSize)
                .ToList();

            itemsOnPage = ChangeUriPlaceholder(itemsOnPage);

            var model = new PaginationResponseModel<StoreViynl>(
                pageIndex, pageSize, totalItems, itemsOnPage);

            return Ok(model);
        }

        //// GET api/v1/[controller]/CatalogTypes
        //[HttpGet]
        //[Route("[action]")]
        //[ProducesResponseType(typeof(List<Genre>), (int)HttpStatusCode.OK)]
        //public async Task<IActionResult> CatalogTypes()
        //{
        //    var items = await _storeGenreRepository.GetAll();
        //    return Ok(items);
        //}

        //// GET api/v1/[controller]/CatalogBrands
        //[HttpGet]
        //[Route("[action]")]
        //[ProducesResponseType(typeof(List<StoreArtist>), (int)HttpStatusCode.OK)]
        //public async Task<IActionResult> CatalogBrands()
        //{
        //    var items = await _storeArtistRepository.GetAll();
        //    return Ok(items);
        //}

        //PUT api/v1/[controller]/items
        [Route("/api/vinyls/{id:int}")]
        [HttpPut]
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
            catalogItem = _autoMapper.Map<UpdateVinylRequest, StoreViynl>(productToUpdate);

            catalogItem.Id = id;
            await _storeViynlRepository.Update(catalogItem);

            return CreatedAtAction(nameof(this.GetItemById), new {id }, null);
        }

        //POST api/v1/[controller]/items
        [Route("/api/vinyls")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> CreateProduct([FromBody]CreateVinylRequest product)
        {
            var result = await _storeViynlRepository.Create(_autoMapper.Map<CreateVinylRequest, StoreViynl>(product));
            return CreatedAtAction(nameof(GetItemById), new { id = result.Id }, null);
        }

        //DELETE api/v1/[controller]/id
        [Route("/api/vinyls/{id:int}")]
        [HttpDelete]
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

        private List<StoreViynl> ChangeUriPlaceholder(List<StoreViynl> items)
        {
            return items;
        }
    }
}
