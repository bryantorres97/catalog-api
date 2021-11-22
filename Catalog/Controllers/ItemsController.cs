﻿using Catalog.Dtos;
using Catalog.Entities;
using Catalog.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Controllers
{
    [ApiController]
    [Route("items")]
    public class ItemsController : ControllerBase
    {
        private readonly IItemsRepository repository;

        public ItemsController(IItemsRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]

        public async Task<IEnumerable<ItemDto>> GetItemsAsync()
        {
            IEnumerable<ItemDto> items = (await repository.GetItemsAsync()).Select(item => item.AsDto());
            return items;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ItemDto>> GetItemAsync(Guid id)
        {
            Item item = await repository.GetItemAsync(id);

            if (item is null) { 
                return NotFound(); 
            }

            return item.AsDto();

           
        }

        [HttpPost]
        public async Task<ActionResult<ItemDto>> CreateItem(CreateItemDto itemDto)
        {
           Item item = new() { 
               Id = Guid.NewGuid(),
               Name = itemDto.Name,
               Price = itemDto.Price,
               CreatedDate = DateTimeOffset.Now,
           };
            
            await repository.CreateItemAsync(item);

            //return CreatedAtAction(nameof(GetItemAsync), new { id = item.Id }, item.AsDto());
            return CreatedAtAction(nameof(GetItemAsync), new {id = item.Id}, item.AsDto());
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateItemAsync(Guid id, UpdateItemDto itemDto)
        {
            Item existingItem = await repository.GetItemAsync(id);

            if(existingItem == null)
            {
                return NotFound();
            }

            Item updatedItem = existingItem with
            {
                Name = itemDto.Name,
                Price = itemDto.Price,
            };

            await repository.UpdateItemAsync(updatedItem);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteItem(Guid id)
        {
            Item existingItem = await repository.GetItemAsync(id);

            if( existingItem == null)
            {
                return NoContent();
            }

            await repository.DeleteItemAsync(id);

            return NoContent();
        }


        
    }
}
