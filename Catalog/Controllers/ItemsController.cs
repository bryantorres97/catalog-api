using Microsoft.AspNetCore.Mvc;
using Catalog.Repositories;

namespace Catalog.Controllers
{

    // GET /items
    [ApiController]
    [Route("items")]
    public class ItemsController : ControllerBase
    {
        private readonly InMemItemsRepository repository;

    }
}
