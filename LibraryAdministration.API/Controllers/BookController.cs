using LibraryAdministration.API.ViewModels;
using LibraryAdministration.Application.Models;
using LibraryAdministration.Contracts.Requests.Books;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAdministration.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<Book>> Get()
        {
            return Ok();
        }

        [HttpGet]
        [Route("/{id:int}")]
        public async Task<ActionResult<Book>> Get(int id)
        {
            return Ok();
        }

        [HttpGet]
        [Route("authors/{authorId:int}/books")]
        public async Task<ActionResult<List<Book>>> GetByAuthor(int authorId)
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] InsertBookRequest request)
        {
            return Ok();
        }

        [HttpDelete]
        [Route("/{id:int}/Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok();
        }

        [HttpPut]
        [Route("/{id}/Update")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateBookRequest request)
        {
            return Ok();
        }
    }
}
