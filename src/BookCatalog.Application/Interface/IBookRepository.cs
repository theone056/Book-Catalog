using BookCatalog.Application.Models;
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
        Task<PagingResponseModel> GetAllBook(PagingRequestModel pagingRequestModel);
        Task<Book> GetBook(int id);
        void Create(Book book, List<int> SelectedCategories);
        void Update(Book book, List<int> SelectedCategories);
        void Delete(int id);
    }
}
