/*using HotChocolate;
using HotChocolate.Data;
using System.Threading.Tasks;
using ToDoQL.Data;
using ToDoQL.Models;

namespace ToDoQL.GraphQL
{
    public class Mutation
    {
        [UseDbContext(typeof(AppDbContext))]
        public async Task<AddItemResponse> AddItemAsync(AddItemInput input, [Service(ServiceKind.Pooled)] AppDbContext context)
        {
            var item = new Item
            {
                IsDone = input.isDone,
                Description = input.description,
                ListId = input.listId,
                Title = input.title,
            };
            context.Items.Add(item);
            await context.SaveChangesAsync();

            return new AddItemPayload(item);
        }
    }
}
*/