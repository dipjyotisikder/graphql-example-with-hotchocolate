using HotChocolate.Subscriptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using ToDoQL.Data;
using ToDoQL.GraphQL;
using ToDoQL.Models;

namespace ToDoQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ITopicEventSender _topicEventSender;

        public ItemsController(
            AppDbContext context,
            ITopicEventSender topicEventSender)
        {
            _context = context;
            _topicEventSender = topicEventSender;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _context.Items.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddItemInput input)
        {
            var item = new Item
            {
                Title = input.title,
                Description = input.description,
                IsDone = input.isDone,
                ListId = input.listId,
            };
            _context.Items.Add(item);
            await _context.SaveChangesAsync();

            var response = new AddItemResponse(
                item.Id,
                item.Title,
                item.Description,
                item.IsDone);

            var itemCreationTopic = $"{"ItemCreated"}";
            await _topicEventSender.SendAsync(itemCreationTopic, response);

            return Ok(response);
        }
    }
}
