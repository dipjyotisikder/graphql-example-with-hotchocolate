using HotChocolate;
using HotChocolate.Types;
using System.Linq;
using ToDoQL.Data;
using ToDoQL.Models;

namespace ToDoQL.GraphQL
{
    public class ItemType : ObjectType<Item>
    {
        protected override void Configure(IObjectTypeDescriptor<Item> descriptor)
        {
            descriptor.Description("This model is used as Item for Item List.");

            descriptor.Field(x => x.ItemList)
                .ResolveWith<Resolvers>(x => x.GetItem(default, default))
                .UseDbContext<AppDbContext>()
                .Description("This Item is the list that Item belongs to.");
        }

        private class Resolvers
        {
            public ItemList GetItem([Parent] Item item, [Service] AppDbContext context)
            {
                return context.ItemLists.Where(x => x.Id == item.ListId).FirstOrDefault();
            }
        }
    }
}
