using BookCatalog.Application.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Book_Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("GetAllBook")]
        public async Task<IActionResult> GetAllBook()
        {
            var result = await _bookService.GetAllBook();
            if (!result.IsNullOrEmpty())
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("GetBook")]
        public async Task<IActionResult> GetBook(int Id)
        {
            var result = await _bookService.GetBook(Id);
            if(result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
