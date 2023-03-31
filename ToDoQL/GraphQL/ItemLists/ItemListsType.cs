using HotChocolate;
using HotChocolate.Types;
using System.Linq;
using ToDoQL.Data;
using ToDoQL.Models;

namespace ToDoQL.GraphQL
{
    public class ItemListsType : ObjectType<ItemList>
    {
        protected override void Configure(IObjectTypeDescriptor<ItemList> descriptor)
        {
            descriptor.Description("This model is used as Item for Item List.");

            descriptor.Field(x => x.Items)
                .ResolveWith<Resolvers>(x => x.GetItems(default!, default))
                .UseDbContext<AppDbContext>()
                .Description("This Item is the list that Item belongs to.");
        }

        private class Resolvers
        {
            public IQueryable<Item> GetItems([Parent] ItemList itemList, [ScopedService] AppDbContext context)
            {
                return context.Items.Where(x => x.ListId == itemList.Id);
            }
        }
    }
}
