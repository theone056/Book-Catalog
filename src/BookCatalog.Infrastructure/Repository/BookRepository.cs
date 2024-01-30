using BookCatalog.Application.Interface;
using BookCatalog.Application.Services.Interface;
using BookCatalog.Domain.Entities;
using BookCatalog.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalog.Infrastructure.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly BookCatalogDbContext _dbContext;
        public BookRepository(BookCatalogDbContext dbContext)
        {
           _dbContext = dbContext;
        }

        public void Create(Book book, List<int> SelectedCategories)
        {
            _dbContext.Books.Add(book);

            foreach (int category in SelectedCategories) {
                _dbContext.BookCategories.Add(new BookCategory()
                {
                    Book = book,
                    CategoryId = category
                });
                _dbContext.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Book>> GetAllBook()
        {
            return await _dbContext.Books
                                   .Include(x=>x.BookCategories)
                                   .ThenInclude(x=>x.Category)
                                   .ToListAsync();
        }

        public async Task<Book> GetBook(int id)
        {
            return await _dbContext.Books
                                   .Include(x => x.BookCategories)
                                   .ThenInclude(x => x.Category)
                                   .FirstOrDefaultAsync(x=>x.Id == id);
        }

        public void Update(Book book)
        {
            throw new NotImplementedException();
        }
    }
}
