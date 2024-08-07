using BookApi.Models;
using Microsoft.AspNetCore.Mvc;
namespace BookApi.Controllers;

[Route("api/[Controller]")]
[ApiController]
public class BooksController : ControllerBase
{
    //hard coding some
    private Book[] _books = new Book[]
    {
        new Book
        {
            Id = 1,
            Author = "MockAuthor1",
            Title = "MockTitle1"
        },
        new Book
        {
            Id = 2,
            Author = "MockAuthor2",
            Title = "MockTitle2"
        },
        new Book
        {
            Id = 3,
            Author = "MockAuthor3",
            Title = "MockTitle3"
        }
    };

    [HttpGet]
    public ActionResult<IEnumerable<Book>> GetBooks()
    {
        return Ok(_books);
    }
}
