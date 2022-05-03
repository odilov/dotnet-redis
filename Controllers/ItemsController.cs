using DotnetRedis.Models;
using DotnetRedis.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DotnetRedis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IItemRepo _repo;

        public ItemsController(IItemRepo repo)
        {
            _repo = repo;
        }

        [HttpGet("{id}", Name = "GetItemById")]
        public ActionResult<Item> GetItemById(string id)
        {
            var item = _repo.GetItemById(id);

            if (item != null)
            {
                return Ok(item);
            }

            return NotFound();
        }

        [HttpPost]
        public ActionResult<Item> CreateItem(Item item)
        {
            _repo.CreateItem (item);

            return CreatedAtRoute(nameof(GetItemById),
            new { Id = item.Id },
            item);
        }
    }
}
