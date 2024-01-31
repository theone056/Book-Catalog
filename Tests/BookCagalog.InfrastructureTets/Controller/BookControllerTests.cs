using Book_Catalog.Controllers;
using BookCatalog.Application.Models;
using BookCatalog.Application.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BookCagalog.InfrastructureTests.Controller
{
    public class BookControllerTests
    {
        private readonly Mock<IBookService> _mockBookService;
        private readonly BookController _bookController;
        public BookControllerTests()
        {
            _mockBookService = new Mock<IBookService>();
            _bookController = new BookController(_mockBookService.Object);
        }

        [Fact]
        public async Task GetAllBook_Method_Returns_Ok()
        {
            var BookList = new List<BookModelResult>()
            {
                new BookModelResult() { Id = 1 }
            };
            _mockBookService.Setup(x => x.GetAllBook(It.IsAny<PagingRequestModel>())).ReturnsAsync(new PagingResponseModel() { Books = BookList });

            var ret = await _bookController.GetAllBook(It.IsAny<PagingRequestModel>()) as ObjectResult;

            Assert.NotNull(ret.Value);
            Assert.IsType<PagingResponseModel>(ret.Value);
            Assert.Equal((int)HttpStatusCode.OK,ret.StatusCode);
        }

        [Fact]
        public async Task GetAllBook_Method_Returns_NotFound()
        {
            _mockBookService.Setup(x => x.GetAllBook(It.IsAny<PagingRequestModel>())).ReturnsAsync(new PagingResponseModel());

            var ret = await _bookController.GetAllBook(It.IsAny<PagingRequestModel>()) as ObjectResult;

            Assert.Null(ret);
        }


        [Fact]
        public async Task GetBook_Method_Returns_Ok()
        {
            _mockBookService.Setup(x => x.GetBook(It.IsAny<int>())).ReturnsAsync(new BookModelResult() { Id = 1});

            var ret = await _bookController.GetBook(It.IsAny<int>()) as ObjectResult;

            Assert.NotNull(ret.Value);
            Assert.IsType<BookModelResult>(ret.Value);
            Assert.Equal((int)HttpStatusCode.OK, ret.StatusCode);
        }
    }
}
