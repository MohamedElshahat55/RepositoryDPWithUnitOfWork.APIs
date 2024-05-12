using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryDPWithUnitOfWork.Core.Contsnts;
using RepositoryDPWithUnitOfWork.Core.Interfaces;
using RepositoryDPWithUnitOfWork.Core.Models;

namespace RepositoryDPWithUnitOfWork.APIs.Controllers
{
   
    public class BooksController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public BooksController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            
        }

        [HttpGet("GetById")]
        public ActionResult<Book> GetById(int id)
        {
            return Ok(_unitOfWork.Books.GetById(id));
        }

        [HttpGet("GetByNameAsync")]
        public async Task<ActionResult<Book>> GetByNameAsync()
        {
            return Ok(await _unitOfWork.Books.FindAsync(b => b.Name == "Harry Poter" , new[] { "Author" }));
        }

        [HttpGet("GetAllBooksAsync")]
        public async Task<ActionResult<Book>> GetAllBooksAsync()
        {
            return Ok(await _unitOfWork.Books.GetAllAsync());
        }

        [HttpGet("GetAllWithAuthor")]
        public async Task<ActionResult<Book>> GetAllWithAuthor()
        {
            return Ok(await _unitOfWork.Books.FindAllAsync(b=>b.Name.Contains("new book") , new[] { "Author" }));
        }

        [HttpGet("GetOrdered")]
        public async Task<ActionResult<Book>> GetOrdered()
        {
            return Ok(await _unitOfWork.Books.FindAllAsync(b => b.Name.Contains("new book"), null, null, null, b => b.Id , OrderByConstsnts.Descending));
        }

        [HttpGet("AddBook")]
        public async Task<ActionResult<Book>> AddBook()
        {
            var newBook = _unitOfWork.Books.AddOne(new Book { Name = "Test", AuthorId = 1 });
            _unitOfWork.Complete(); // SaveChanges
            return Ok(newBook);
        }

    }
}
