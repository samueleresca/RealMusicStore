using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Store.API.Infrastructure.DataAccess;
using Store.API.Models;

namespace Store.API.Repositories
{
    public class StoreArtistRepository : IStoreArtistRepository
    {
        private readonly StoreContext _dbContext;

        public StoreArtistRepository(StoreContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<StoreArtist>> GetAll()
        {
            return await _dbContext.StoreArtists
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<StoreArtist>> Find(Expression<Func<StoreArtist, bool>> filter)
        {
            return await _dbContext.StoreArtists
                .AsNoTracking()
                .Where(filter).ToListAsync();
        }

        public async Task<StoreArtist> GetById(int id)
        {
            return await _dbContext
                .StoreArtists
                .AsNoTracking()
                .FirstOrDefaultAsync(_ => _.Id == id);

        }

        public async Task<StoreArtist> Create(StoreArtist entity)
        {
            if (entity == null) throw new Exception("Entity cannot be null");
            var result = await _dbContext.StoreArtists.AddAsync(entity);

            await _dbContext.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<StoreArtist> Update(StoreArtist entity)
        {
            if (entity == null) throw new Exception("Entity cannot be null");

            _dbContext.StoreArtists.Attach(entity);
            var entry = _dbContext.Entry(entity);
            entry.State = EntityState.Modified;

            await _dbContext.SaveChangesAsync();

            return entry.Entity;
        }

        public async Task<StoreArtist> Delete(int id)
        {
            var entity = await _dbContext.FindAsync<StoreArtist>(id);
            entity.IsDisabled = true;

            return await Update(entity);
        }

    }
}
