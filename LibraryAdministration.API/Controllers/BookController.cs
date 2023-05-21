using AutoMapper;
using LibraryAdministration.API.ViewModels;
using LibraryAdministration.Application.Models;
using LibraryAdministration.Application.Services.Abstractions;
using LibraryAdministration.Contracts.Requests.Books;
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

        [HttpGet]
        public async Task<ActionResult<List<Book>>> Get()
        {
            List<BookDto> books = await _bookService.GetAll(true);
            var response = _mapper.Map<List<Book>>(books);
            return Ok(response);
        }

        [HttpGet]
        [Route("/{id:int}")]
        public async Task<ActionResult<Book>> Get(int id)
        {
            BookDto book = await _bookService.GetById(id);
            var response = _mapper.Map<Book>(book);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] InsertBookRequest request)
        {
            var authors = request.Authors.Select(a =>  new Tuple<string,string>(a.AuthorFirstName, a.AuthorLastName));
            await _bookService.Insert(request.Title, request.Quantity, authors, request.ImageContent, request.ImageName);
            return Ok();
        }

        [HttpDelete]
        [Route("/{id:int}/Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            await _bookService.DeleteById(id);
            return Ok();
        }

        [HttpPut]
        [Route("/{id}/Update")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateBookRequest request)
        {
            await _bookService.Update(id, request.Title, request.Quantity, request.AuthorFirstName, request.AuthorLastName, request.ImageContent);
            return Ok();
        }
    }
}
