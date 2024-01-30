using AutoMapper;
using BookCatalog.Application.Interface;
using BookCatalog.Application.Models;
using BookCatalog.Application.Services.Interface;
using BookCatalog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalog.Application.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        public BookService(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }
        public void Create(CreateBookModel book)
        {
            try
            {
                var model = _mapper.Map<Book>(book);
                _bookRepository.Create(model, book.SelectedCategories);
            }
            catch(Exception ex) { 
                throw new Exception(ex.Message);
            }
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<BookModelResult>> GetAllBook()
        {
            var result = await _bookRepository.GetAllBook();
            var model = _mapper.Map<List<BookModelResult>>(result);
            return model;
        }

        public async Task<BookModelResult> GetBook(int id)
        {
            var result = await _bookRepository.GetBook(id);
            var model = _mapper.Map<BookModelResult>(result);
            return model;
        }

        public void Update(Book book)
        {
            throw new NotImplementedException();
        }
    }
}
