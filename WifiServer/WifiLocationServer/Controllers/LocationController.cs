using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WifiLocationServer.Dtos;
using WifiLocationServer.Entities;
using WifiLocationServer.Repositories;

namespace WifiLocationServer.Controllers
{
    [ApiController]
    [Route("items")]
    public class LocationController : ControllerBase
    {
        private readonly InterfaceLocationRepository repository;

        public LocationController(InterfaceLocationRepository repository)
        {
            this.repository = repository;
        }
        [HttpGet]
        public IEnumerable<ItemDto> GetItems()
        {
            var items = repository.GetItems().Select(item => item.AsDto());
         
            return items;
        }

        [HttpGet("{id}")]
        public ActionResult<ItemDto> GetItem(Guid id)
        {
            var item = repository.GetItem(id);

            if(item is null )
            {
                return NotFound();
            }

            return item.AsDto();
        }

        [HttpPost]
        public ActionResult<ItemDto> CreateLocation(CreateLocationDto itemDto)
        {
            Item item = new()
            {
                Id = Guid.NewGuid(),
                Location = itemDto.Location,
                MAC = itemDto.MAC,
                SignalStrength = itemDto.SignalStrength
                };

            repository.CreateItem(item);

            return CreatedAtAction(nameof(GetItem), new { id = item.Id }, item.AsDto());
        }

    }
}

