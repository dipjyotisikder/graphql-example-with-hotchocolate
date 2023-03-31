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
            descriptor.Field(x => x.Items)
                .ResolveWith<FieldResolvers>(x => x.GetItems(default!, default))
                .UseDbContext<AppDbContext>();
        }
    }

    public class FieldResolvers
    {
        public IQueryable<Item> GetItems(ItemList itemList, [ScopedService] AppDbContext context)
        {
            return context.Items.Where(x => x.ListId == itemList.Id);
        }
    }
}
