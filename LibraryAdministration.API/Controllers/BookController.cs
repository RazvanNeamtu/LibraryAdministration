using AutoMapper;
using LibraryAdministration.API.ViewModels;
using LibraryAdministration.Application.Models;
using LibraryAdministration.Application.Services.Abstractions;
using LibraryAdministration.Contracts.Requests.Books;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAdministration.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly IMapper _mapper;
        public BookController(IBookService bookService, IMapper mapper)
        {
            _bookService = bookService;
            _mapper = mapper;
        }

        /// <summary>
        /// Retrieves all books
        /// </summary>
        /// <returns>List of books</returns>
        [HttpGet]
        public async Task<ActionResult<List<Book>>> Get()
        {
            List<BookDto> books = await _bookService.GetAll(true);
            var response = _mapper.Map<List<Book>>(books);
            return Ok(response);
        }

        /// <summary>
        /// Retrieves book by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Book</returns>
        [Authorize]
        [HttpGet]
        [Route("{id:int}")]
        public ActionResult<Book> Get(int id)
        {
            BookDto book = _bookService.GetById(id);
            var response = _mapper.Map<Book>(book);
            return Ok(response);
        }

        /// <summary>
        /// Inserts new book
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] InsertBookRequest request)
        {
            if (request is null) throw new Exception(); //TODO: Error handling
            var authors = request.Authors.Select(a =>  new Tuple<string,string>(a.AuthorFirstName, a.AuthorLastName));
            await _bookService.Insert(request.Title, request.Quantity, authors, request.ImageContent, request.ImageName);
            return Ok();
        }

        /// <summary>
        /// Deletes book by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize]
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _bookService.DeleteById(id);
            return Ok();
        }

        //TODO: Fix this one
        //[HttpPut]
        //[Route("/{id}/Update")]
        //public async Task<IActionResult> Update(int id, [FromBody] UpdateBookRequest request)
        //{
        //    await _bookService.Update(id, request.Title, request.Quantity, request.AuthorFirstName, request.AuthorLastName, request.ImageContent);
        //    return Ok();
        //}
    }
}
