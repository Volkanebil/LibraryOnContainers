using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Inventory.API.Model;
using Inventory.API.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        [HttpGet]
        [Route("books")]
        [ProducesResponseType(typeof(PaginatedItemsViewModel<Book>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(IEnumerable<Book>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        private async Task<IActionResult> BooksAsync([FromQuery] int pageSize = 10, [FromQuery]int pageIndex = 0, string ids = null)
        {
            var books = await GetBooksAsync();

            var model = new PaginatedItemsViewModel<Book>(pageIndex, pageSize, books.Count, books);

            return Ok(model);
        }

        private async Task<List<Book>> GetBooksAsync()
        {
            var books = new List<Book>
            {
                new Book
                {
                    Name = "Fahrenheit 451",
                    Description = @"Yazılmış en iyi bilimkurgu romanı. İlk okuduğumda, yarattığı dünyayla kâbuslar görmeme sebep olmuştu. -Margaret Atwood
                                    Öyle bir eser ki, hakkında ne söylesem eksik kalır. -Neil Gaiman",
                    AvailableStock  = 29,
                    Id = 1,
                    Price = 18
                },
                new Book
                {
                    Name = "Otomatik Portakal",
                    Description = @"Tüm hayvanların en zekisi, iyiliğin ne demek olduğunu bilen insanoğluna sistematik bir baskı uygulayarak onu otomatik 
                                    işleyen bir makine haline getirenlere kılıç kadar keskin olan kalemimle saldırmaktan başka hiçbir şey yapamıyorum...",
                    AvailableStock  = 12,
                    Id = 2,
                    Price = 22
                }
            };

            return books;
        }
    }

}