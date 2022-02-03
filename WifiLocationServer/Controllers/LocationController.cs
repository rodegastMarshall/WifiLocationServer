using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
        public IEnumerable<Item> GetItems()
        {
            var items = repository.GetItems();
            return items;
        }
        [HttpGet("{id}")]
        public ActionResult<Item> GetItem(Guid id)
        {
            var item = repository.GetItem(id);

            if(item is null )
            {
                return NotFound();
            }

            return item;
        }
    }
}

