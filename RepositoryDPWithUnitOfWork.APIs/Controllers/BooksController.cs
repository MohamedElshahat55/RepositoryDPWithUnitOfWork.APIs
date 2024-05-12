using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryDPWithUnitOfWork.Core.Interfaces;
using RepositoryDPWithUnitOfWork.Core.Models;

namespace RepositoryDPWithUnitOfWork.APIs.Controllers
{
   
    public class BooksController : BaseApiController
    {
        private readonly IGenericRepository<Book> _bookRepo;

        public BooksController(IGenericRepository<Book> bookRepo)
        {
            _bookRepo = bookRepo;
        }

        [HttpGet("GetById")]
        public ActionResult<Book> GetById(int id)
        {
            return Ok(_bookRepo.GetById(id));
        }

        [HttpGet("GetByNameAsync")]
        public async Task<ActionResult<Book>> GetByNameAsync()
        {
            return Ok(await _bookRepo.FindAsync(b => b.Name == "Harry Poter" , new[] { "Author" }));
        }

        [HttpGet("GetAllBooksAsync")]
        public async Task<ActionResult<Book>> GetAllBooksAsync()
        {
            return Ok(await _bookRepo.GetAllAsync());
        }

        [HttpGet("GetAllWithAuthor")]
        public async Task<ActionResult<Book>> GetAllWithAuthor()
        {
            return Ok(await _bookRepo.FindAllAsync(b=>b.Name.Contains("new book") , new[] { "Author" }));
        }
    }
}
