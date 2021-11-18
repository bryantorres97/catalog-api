using Catalog.Entities;
using Catalog.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemsController : ControllerBase
    {
        private readonly InMemItemsRepository repository;

        public ItemsController()
        {
            repository = new InMemItemsRepository();
        }

        [HttpGet]

        public IEnumerable<Item> GetItems()
        {
            IEnumerable<Item> items = repository.GetItems();
            return items;
        }

        [HttpGet("{id}")]
        public Item GetItem(Guid id)
        {
            Item item = repository.GetItem(id);
            return item;
        }
        
    }
}
