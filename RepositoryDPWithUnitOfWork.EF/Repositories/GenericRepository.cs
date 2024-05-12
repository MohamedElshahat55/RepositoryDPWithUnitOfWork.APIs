using Microsoft.EntityFrameworkCore;
using RepositoryDPWithUnitOfWork.Core.Interfaces;
using RepositoryDPWithUnitOfWork.Core.Models;
using RepositoryDPWithUnitOfWork.EF.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryDPWithUnitOfWork.EF.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseModel
    {
        private readonly ApplicationDbContext _dbContext;

        public GenericRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> match, string[] includes = null)
        {
            IQueryable<T> Query = _dbContext.Set<T>();
            if (includes != null)
            {
                foreach (var include in includes)
                    Query = Query.Include(include);
            }
            return await Query.Where(match).ToListAsync();
        }

        public async Task<T> FindAsync(Expression<Func<T, bool>> match , string[] includes = null)
        {
            IQueryable<T> Query = _dbContext.Set<T>();
            if(includes != null)
            {
                foreach (var include in includes)
                    Query = Query.Include(include);
            }
            return await Query.SingleOrDefaultAsync(match);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public T GetById(int id)
        {
            return _dbContext.Set<T>().Find(id);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        
    }
}
