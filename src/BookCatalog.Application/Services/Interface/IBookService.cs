using BookCatalog.Application.Models;
using BookCatalog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalog.Application.Services.Interface
{
    public interface IBookService
    {
        Task<List<BookModelResult>> GetAllBook();
        Task<BookModelResult> GetBook(int id);
        void Create(CreateBookModel book); 
        void Update(UpdateBookModel book);
        void Delete(int id);
    }
}
