﻿using AutoMapper;
using BookCatalog.Application.Interface;
using BookCatalog.Application.Models;
using BookCatalog.Application.Services.Interface;
using BookCatalog.Domain.Entities;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<BookService> _logger;
        private readonly IMapper _mapper;
        public BookService(IBookRepository bookRepository,ILogger<BookService> logger, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _logger = logger;
            _mapper = mapper;
            _logger.LogInformation("Called Book Service");
        }
        public void Create(CreateBookModel book)
        {
            try
            {
                var model = _mapper.Map<Book>(book);
                _bookRepository.Create(model, book.SelectedCategories);
            }
            catch(Exception ex) {
                _logger.LogError(ex, ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public void Delete(int id)
        {
            try
            {
                _bookRepository.Delete(id);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<PagingResponseModel> GetAllBook(PagingRequestModel pagingRequestModel)
        {
            var result = await _bookRepository.GetAllBook(pagingRequestModel);
            return result;
        }

        public async Task<BookModelResult> GetBook(int id)
        {
            var result = await _bookRepository.GetBook(id);
            var model = _mapper.Map<BookModelResult>(result);
            return model;
        }

        public void Update(UpdateBookModel book)
        {
            try
            {
                var model = _mapper.Map<Book>(book);
                _bookRepository.Update(model, book.SelectedCategories);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw new Exception(ex.Message);
            }
        }
    }
}
