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
    public class StoreGenreRepository : IStoreGenreRepository
    {
        private readonly StoreContext _dbContext;

        public StoreGenreRepository(StoreContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Genre>> GetAll()
        {
            return await _dbContext.Genres
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<Genre>> Find(Expression<Func<Genre, bool>> filter)
        {
            return await _dbContext.Genres
                .AsNoTracking()
                .Where(filter).ToListAsync();
        }

        public async Task<Genre> GetById(int id)
        {
            return await _dbContext.Genres.AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Genre> Create(Genre entity)
        {
            if (entity == null) throw new Exception("Entity cannot be null");
            var result = await _dbContext.Genres.AddAsync(entity);

            await _dbContext.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<Genre> Update(Genre entity)
        {
            if (entity == null) throw new Exception("Entity cannot be null");

            _dbContext.Genres.Attach(entity);
            var entry = _dbContext.Entry(entity);
            entry.State = EntityState.Modified;

            await _dbContext.SaveChangesAsync();

            return entry.Entity;
        }

        public async Task<Genre> Delete(int id)
        {
            var entity = await _dbContext.FindAsync<Genre>(id);
            entity.IsDisabled = true;

            return await Update(entity);
        }

    }
}
