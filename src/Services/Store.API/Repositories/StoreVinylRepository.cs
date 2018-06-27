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
    public class StoreVinylRepository : IStoreViynlRepository
    {
        private readonly StoreContext _dbContext;

        public StoreVinylRepository(StoreContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async  Task<IEnumerable<StoreViynl>> GetAll()
        {
            return await _dbContext.StoreTracks
                .AsNoTracking()
                .Include(_ => _.Artist)
                .Include(_ => _.Genre)
                .ToListAsync();
        }

        public async Task<IEnumerable<StoreViynl>> Find(Expression<Func<StoreViynl, bool>> filter)
        {
            return await _dbContext.StoreTracks
                .AsNoTracking()
                .Where(filter)
                .Include(_ => _.Artist)
                .ToListAsync();
        }

        public async Task<StoreViynl> GetById(int id)
        {
            return await _dbContext
                .StoreTracks
                .AsNoTracking()
                .Include(_=>_.Artist)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<StoreViynl> Create(StoreViynl entity)
        {
            if (entity == null) throw new Exception("Entity cannot be null");
            var result = await _dbContext
                .StoreTracks.AddAsync(entity);

            await _dbContext.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<StoreViynl> Update(StoreViynl entity)
        {
            if (entity == null) throw new Exception("Entity cannot be null");

            _dbContext.StoreTracks.Attach(entity);
            var entry = _dbContext.Entry(entity);
            entry.State = EntityState.Modified;

            await _dbContext.SaveChangesAsync();

            return entry.Entity;
        }

        public async Task<StoreViynl> Delete(int id)
        {
            var entity = await _dbContext.FindAsync<StoreViynl>(id);
            entity.IsDisabled = true;

            return await Update(entity);
        }

    }
}
