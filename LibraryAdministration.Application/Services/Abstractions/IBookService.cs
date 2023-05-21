﻿using LibraryAdministration.Application.Models;

namespace LibraryAdministration.Application.Services.Abstractions
{
    public interface IBookService
    {
        Task DeleteById(int id);
        Task<List<BookDto>> GetAll(bool includeAuthors);
        Task<BookDto> GetById(int id);
        Task Insert(string title, int quantity, IEnumerable<Tuple<string,string>> authors, byte[]? imageContent);
        Task Update(int id, string title, int quantity, string authorFirstName, string authorLastName, byte[]? imageContent);
    }
}