using HotChocolate;
using HotChocolate.Data;
using System.Linq;
using ToDoQL.Data;
using ToDoQL.Models;

namespace ToDoQL.GraphQL
{
    public class Query
    {
        [UseDbContext(typeof(AppDbContext))]
        public IQueryable<ItemList> GetItemLists([ScopedService] AppDbContext context)
        {
            return context.ItemLists;
        }

        [UseDbContext(typeof(AppDbContext))]
        public IQueryable<Item> GetItems([ScopedService] AppDbContext context)
        {
            return context.Items;
        }
    }
}
