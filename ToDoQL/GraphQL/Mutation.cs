using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Subscriptions;
using System.Threading.Tasks;
using ToDoQL.Data;
using ToDoQL.Models;

namespace ToDoQL.GraphQL
{
    public class Mutation
    {
        [UseDbContext(typeof(AppDbContext))]
        public async Task<AddItemResponse> AddItem(
            AddItemInput input,
            [Service] AppDbContext context,
            [Service] ITopicEventSender topicEventSender)
        {
            var item = new Item
            {
                Title = input.title,
                Description = input.description,
                IsDone = input.isDone,
                ListId = input.listId,
            };
            context.Items.Add(item);
            await context.SaveChangesAsync();

            var itemCreationTopic = $"{"ItemCreated"}";

            var response = new AddItemResponse(
                item.Id,
                item.Title,
                item.Description,
                item.IsDone);

            await topicEventSender.SendAsync(itemCreationTopic, response);

            return response;
        }
    }
}
