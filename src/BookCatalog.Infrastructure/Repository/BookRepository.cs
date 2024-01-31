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
            try
            {
                _dbContext.Books.Add(book);

                foreach (int category in SelectedCategories)
                {
                    _dbContext.BookCategories.Add(new BookCategory()
                    {
                        Book = book,
                        CategoryId = category
                    });
                    _dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message,ex);
            }
        }

        public void Delete(int id)
        {
            var books = _dbContext.Books.Where(x=>x.Id == id).ToList();
            var bookCategory = _dbContext.BookCategories.Where(x=>x.BookId == id).ToList();
            _dbContext.RemoveRange(books);
            _dbContext.RemoveRange(bookCategory);
            _dbContext.SaveChanges(true);
        }

        public async Task<List<Book>> GetAllBook()
        {
            try
            {
                return await _dbContext.Books
                        .Include(x => x.BookCategories)
                        .ThenInclude(x => x.Category)
                        .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<Book> GetBook(int id)
        {
            try
            {
                return await _dbContext.Books
                            .Include(x => x.BookCategories)
                            .ThenInclude(x => x.Category)
                            .FirstOrDefaultAsync(x => x.Id == id);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
     
        }

        public void Update(Book book, List<int> SelectedCategories)
        {
            try
            {
                _dbContext.Books.Update(book);

                var oldData = _dbContext.BookCategories
                                .Where(id => id.BookId == book.Id).ToList();

                _dbContext.BookCategories.RemoveRange(oldData);

                foreach (var bookCategory in SelectedCategories)
                {
                    _dbContext.BookCategories.Add(new BookCategory()
                    {
                        BookId = book.Id,
                        CategoryId = bookCategory
                    });

                    _dbContext.SaveChanges();
                }
            }catch(Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
