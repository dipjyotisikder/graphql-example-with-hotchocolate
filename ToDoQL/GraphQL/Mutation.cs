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
                Title = input.Title,
                Description = input.Description,
                IsDone = input.IsDone,
                ListId = input.ListId,
            };
            context.Items.Add(item);
            await context.SaveChangesAsync();

            var response = new AddItemResponse(
                item.Id,
                item.Title,
                item.Description,
                item.IsDone);

            await topicEventSender.SendAsync(GraphQLConstants.ITEM_CREATION_TOPIC, response);

            return response;
        }

        [UseDbContext(typeof(AppDbContext))]
        public async Task<AddItemListResponse> AddItemList(
            AddItemListInput input,
            [Service] AppDbContext context,
            [Service] ITopicEventSender topicEventSender)
        {
            var itemList = new ItemList
            {
                Name = input.Name,
            };
            context.ItemLists.Add(itemList);
            await context.SaveChangesAsync();

            var response = new AddItemListResponse(itemList.Id, itemList.Name);

            await topicEventSender.SendAsync(GraphQLConstants.ITEMLIST_CREATION_TOPIC, response);

            return response;
        }
    }
}
