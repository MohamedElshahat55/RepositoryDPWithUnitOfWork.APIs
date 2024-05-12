using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryDPWithUnitOfWork.Core.Interfaces;
using RepositoryDPWithUnitOfWork.Core.Models;
using RepositoryDPWithUnitOfWork.EF.Repositories;

namespace RepositoryDPWithUnitOfWork.APIs.Controllers
{
  
    public class AuthorsController : BaseApiController
    {
        private readonly IGenericRepository<Author> _authRepo;

        public AuthorsController(IGenericRepository<Author> authRepo)
        {
            _authRepo = authRepo;
        }

        [HttpGet]
        public ActionResult<Author> GetById(int id) {
           return _authRepo.GetById(id);
        }
    }
}
