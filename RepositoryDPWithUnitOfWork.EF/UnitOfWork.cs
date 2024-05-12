using RepositoryDPWithUnitOfWork.Core.Interfaces;
using RepositoryDPWithUnitOfWork.Core.Models;
using RepositoryDPWithUnitOfWork.EF.Data;
using RepositoryDPWithUnitOfWork.EF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryDPWithUnitOfWork.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;

        public IGenericRepository<Author> Authors { get; private set; }

        public IGenericRepository<Book> Books { get; private set; }
        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            Authors = new GenericRepository<Author>(_dbContext);
            Books = new GenericRepository<Book>(_dbContext);
        }
        public int Complete()
        {
           return _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
