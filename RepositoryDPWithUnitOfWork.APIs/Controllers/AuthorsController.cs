using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryDPWithUnitOfWork.Core.Interfaces;
using RepositoryDPWithUnitOfWork.Core.Models;
using RepositoryDPWithUnitOfWork.EF;
using RepositoryDPWithUnitOfWork.EF.Repositories;

namespace RepositoryDPWithUnitOfWork.APIs.Controllers
{
  
    public class AuthorsController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public AuthorsController(IUnitOfWork unitOfWork)
        {
            
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public ActionResult<Author> GetById(int id) {
           return _unitOfWork.Authors.GetById(id);
        }

        [HttpGet("AddAuthors")]
        public async Task<ActionResult<IEnumerable<Author>>> AddAuthors()
        {
            var Authors = new List<Author> {
                new Author{Title = "Jack" },
                new Author{Title = "Mohamed" },
            };
            await _unitOfWork.Authors.AddRange(Authors);
            _unitOfWork.Complete();
            return Ok(Authors);
        }
    }
}
