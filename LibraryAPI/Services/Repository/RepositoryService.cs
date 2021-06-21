using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LibraryAPI.Contexts;
using LibraryAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Services.Repository
{
    public class RepositoryService : IRepositoryService
    {
        private readonly DatabaseContext _context;

        public RepositoryService(DatabaseContext context)
        {
            _context = context;
        }

        #region -- IRepositoryService implementation --

        public async Task<IEnumerable<T>> GetAllAsync<T>() where T : class
        {
            var dbSet = _context.Set<T>();

            return await dbSet.AsNoTracking().ToListAsync();
        }

        public async Task AddAsync<T>(T entity) where T : class
        {
            var dbSet = _context.Set<T>();

            dbSet.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync<T>(T entity) where T : class
        {
            var dbSet = _context.Set<T>();

            dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync<T>(T entity) where T : class
        {
            var dbSet = _context.Set<T>();

            dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        #endregion
    }
}
