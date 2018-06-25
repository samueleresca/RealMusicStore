using System;
using System.Linq;
using System.Threading.Tasks;
using Catalog.API.Infrastructure.DataAccess;
using Catalog.API.Model;
using Microsoft.EntityFrameworkCore;

namespace Catalog.API.Infrastructure.Repositories
{
    public class CatalogRepository : ICatalogRepository
    {
        private readonly CatalogContext _dbContext;

        public CatalogRepository(CatalogContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<CatalogTrack> GetAll => _dbContext.Set<CatalogTrack>().AsNoTracking();


        public async Task<CatalogTrack> GetById(int id)
        {
            return await _dbContext.CatalogTracks
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<CatalogTrack> Create(CatalogTrack entity)
        {
            if (entity == null) throw new Exception("Entity cannot be null");

            var result = await _dbContext.CatalogTracks.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<CatalogTrack> Update(int id, CatalogTrack entity)
        {
            if (entity == null) throw new Exception("Entity cannot be null");

            var oldEntity = _dbContext.CatalogTracks.FirstOrDefault(_ => _.Id == id);

            entity.Id = id;

            _dbContext.Entry(oldEntity ?? throw new Exception("Entity cannot be null")).State = EntityState.Detached;
            _dbContext.CatalogTracks.Attach(entity);

            var result = _dbContext.Entry(entity);
            result.State = EntityState.Modified;

            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<CatalogTrack> Delete(int id)
        {
            var entity = await _dbContext.FindAsync<CatalogTrack>(id);
            entity.IsDeleted = true;

            return await Update(id, entity);
        }


    }
}
