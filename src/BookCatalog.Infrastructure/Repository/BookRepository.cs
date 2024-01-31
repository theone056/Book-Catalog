using AutoMapper;
using Azure;
using BookCatalog.Application.Interface;
using BookCatalog.Application.Models;
using BookCatalog.Application.Services.Interface;
using BookCatalog.Domain.Entities;
using BookCatalog.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalog.Infrastructure.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly BookCatalogDbContext _dbContext;
        private readonly IMapper _mapper;
        public BookRepository(BookCatalogDbContext dbContext, IMapper mapper)
        {
           _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Create(Book book, List<int> SelectedCategories)
        {
            try
            {
                _dbContext.Books.Add(book);

                AddBookCategories(book, SelectedCategories);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message,ex);
            }
        }

        private void AddBookCategories(Book book, List<int> SelectedCategories)
        {
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

        public void Delete(int id)
        {
            var books = _dbContext.Books.Where(x=>x.Id == id).ToList();
            var bookCategory = _dbContext.BookCategories.Where(x=>x.BookId == id).ToList();
            _dbContext.RemoveRange(books);
            _dbContext.RemoveRange(bookCategory);
            _dbContext.SaveChanges(true);
        }

        public async Task<PagingResponseModel> GetAllBook(PagingRequestModel pagingRequestModel)
        {
            try
            {
                IQueryable<Book> query = _dbContext.Books.Include(x=>x.BookCategories).ThenInclude(x=>x.Category);


                var parameter = Expression.Parameter(typeof(Book), "x");
                var property = Expression.Property(parameter, pagingRequestModel.orderBy);
                var lambda = Expression.Lambda<Func<Book,object>>(Expression.Convert(property, typeof(object)), parameter);

                query = pagingRequestModel.direction.ToLower() == "desc"
                        ? query.OrderByDescending(lambda)
                        : query.OrderBy(lambda);

                var entities = query
                                    .Skip((pagingRequestModel.PageNumber - 1) * pagingRequestModel.PageSize)
                                    .Take(pagingRequestModel.PageSize)
                                    .ToList();



                return new PagingResponseModel()
                {
                    OrderBy = pagingRequestModel.orderBy,
                    PageNumber = pagingRequestModel.PageNumber,
                    PageSize = pagingRequestModel.PageSize,
                    OrderDirection = pagingRequestModel.direction,
                    Books = _mapper.Map<List<BookModelResult>>(entities)
                };
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

                RemoveOldBookCategories(book);

                AddBookCategories(book, SelectedCategories);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        private void RemoveOldBookCategories(Book book)
        {
            var oldData = _dbContext.BookCategories
                                            .Where(id => id.BookId == book.Id).ToList();

            _dbContext.BookCategories.RemoveRange(oldData);
        }
    }
}
