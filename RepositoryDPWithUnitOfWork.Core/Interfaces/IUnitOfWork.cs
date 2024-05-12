using RepositoryDPWithUnitOfWork.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryDPWithUnitOfWork.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public IGenericRepository<Author> Authors { get; }
        public IGenericRepository<Book> Books{ get; }

        int Complete();
    }
}
