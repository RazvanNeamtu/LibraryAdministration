using AutoMapper;
using LibraryAdministration.API.ViewModels;
using LibraryAdministration.Application.Models;
using LibraryAdministration.Application.Services.Abstractions;
using LibraryAdministration.Contracts.Requests.Authors;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace LibraryAdministration.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAuthorService _authorService;

        public AuthorController(IMapper mapper, IAuthorService authorService)
        {
            _mapper = mapper;
            _authorService = authorService;
        }

        /// <summary>
        /// Retrieves all authors
        /// </summary>
        /// <returns>List of authors</returns>
        [HttpGet]
        public async Task<ActionResult<List<Author>>> Get()
        {
            List<AuthorDto> authors = await _authorService.GetAll();
            var response = _mapper.Map<List<Author>>(authors);
            return Ok(response);
        }

        /// <summary>
        /// Retrieves author by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Author</returns>
        [Authorize]
        [HttpGet]
        [Route("{id:int}")]
        public ActionResult<Author> Get(int id)
        {
            AuthorDto author = _authorService.GetById(id);
            var response = _mapper.Map<Author>(author);
            return Ok(response);
        }

        /// <summary>
        /// Inserts new author
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] InsertAuthorRequest request)
        {
            if (request is null) throw new ValidationException($"Request {typeof(InsertAuthorRequest)} is null");
            await _authorService.Insert(request.FirstName, request.LastName);
            return Ok();
        }

        /// <summary>
        /// Deletes author by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize]
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _authorService.DeleteById(id);
            return Ok();
        }

        /// <summary>
        /// Updates existing author
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPut]
        [Route("{id:int}/Update")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateAuthorRequest request)
        {
            if (request is null) throw new ValidationException($"Request {typeof(UpdateAuthorRequest)} is null");
            await _authorService.Update(id, request.FirstName, request.LastName);
            return Ok();
        }
    }
}
