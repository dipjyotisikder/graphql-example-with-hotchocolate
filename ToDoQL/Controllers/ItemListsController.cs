using HotChocolate.Subscriptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using ToDoQL.Data;
using ToDoQL.GraphQL;
using ToDoQL.Models;

namespace ToDoQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemListsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ITopicEventSender _topicEventSender;

        public ItemListsController(
            AppDbContext context,
            ITopicEventSender topicEventSender)
        {
            _context = context;
            _topicEventSender = topicEventSender;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _context.ItemLists
                .Select(x => new
                {
                    x.Id,
                    x.Name,
                    Items = x.Items.Select(y => new
                    {
                        y.Id,
                        y.Title,
                        y.Description,
                        y.IsDone,
                    })
                })
                .ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddItemListInput input)
        {
            var itemList = new ItemList
            {
                Name = input.Name,
            };
            _context.ItemLists.Add(itemList);
            await _context.SaveChangesAsync();

            var response = new AddItemListResponse(
                itemList.Id,
                itemList.Name
                );

            await _topicEventSender.SendAsync(GraphQLConstants.ITEMLIST_CREATION_TOPIC, response);

            return Ok(response);
        }
    }
}
