using RepositoryDPWithUnitOfWork.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryDPWithUnitOfWork.Core.Interfaces
{
    public interface IGenericRepository<T> where T : BaseModel
    {

       Task<IEnumerable<T>> GetAllAsync();
        T GetById(int id);
        Task<T> GetByIdAsync(int id);
        Task<T> FindAsync(Expression<Func<T, bool>> match , string[] includes );
        Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> match , string[] includes );




    }
}
