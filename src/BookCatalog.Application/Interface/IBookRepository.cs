using BookCatalog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalog.Application.Interface
{
    public interface IBookRepository
    {
        Task<List<Book>> GetAllBook();
        Task<Book> GetBook(int id);
        void Create(Book book, List<int> SelectedCategories);
        void Update(Book book, List<int> SelectedCategories);
        void Delete(int id);
    }
}
