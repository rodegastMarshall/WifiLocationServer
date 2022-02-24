using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WifiLocationServer.Dtos;
using WifiLocationServer.Entities;
using WifiLocationServer.Repositories;

namespace WifiLocationServer.Controllers
{
    [ApiController]
    [Route("Items")]
    public class LocationController : ControllerBase
    {
        private readonly InterfaceLocationRepository repository;

        public LocationController(InterfaceLocationRepository repository)
        {
            this.repository = repository;
        }
        [HttpGet]
        public async Task<IEnumerable<ItemDto>> GetItemsAsync()
        {
            var items = (await repository.GetItemsAsync())
                .Select(item => item.AsDto());
     
            return items;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ItemDto>> GetItemAsync(Guid id)
        {
            var item = await repository.GetItemAsync(id);

            if(item is null )
            {
                return NotFound();
            }

            return item.AsDto();
        }

        [HttpPost]
        public async Task<ActionResult<ItemDto>> CreateLocationASync(CreateLocationDto itemDto)
        {
            Item item = new()
            {
                Id = Guid.NewGuid(),
                Location = itemDto.Location,
                MAC = itemDto.MAC,
                MaxSignalStrength = itemDto.MaxSignalStrength,
                MinSignalStrength = itemDto.MinSignalStrength
                };

            await repository.CreateItemAsync(item);

            return CreatedAtAction(nameof(GetItemAsync), new { id = item.Id }, item.AsDto());
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> updateItem(Guid id, UpdateLocationDto itemDto)
        {
            var existingItem = await repository.GetItemAsync(id);

            if (existingItem is null)
            {
                return NotFound();
            }

            Item updatedItem =  existingItem with
            {
                Location = itemDto.Location,
                MAC = itemDto.MAC,
                MaxSignalStrength = itemDto.MaxSignalStrength,
                MinSignalStrength = itemDto.MinSignalStrength
            };

           await repository.UpdateItemAsync(updatedItem);

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteItem(Guid id)
        {
            var existingItem = repository.GetItemAsync(id);

            if (existingItem is null)
            {
                return NotFound();
            }

           await repository.DeleteItemAsync(id);

            return NoContent();
        }

    }
}

