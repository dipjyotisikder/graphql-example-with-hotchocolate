using HotChocolate;
using HotChocolate.Data;
using System.Linq;
using ToDoQL.Data;
using ToDoQL.Models;

namespace ToDoQL.GraphQL
{
    public class Query
    {
        [UseFiltering]
        [UseSorting]
        public IQueryable<ItemList> GetItemLists([Service] AppDbContext context)
        {
            return context.ItemLists;
        }

        [UseFiltering]
        [UseSorting]
        public IQueryable<Item> GetItems([Service] AppDbContext context)
        {
            return context.Items;
        }

        [UseFiltering]
        [UseSorting]
        public IQueryable<MyItem> GetMyItems([Service] AppDbContext context)
        {
            return context.Items.Select(x => new MyItem
            {
                Id = x.Id,
                Description = x.Description,
                Title = x.Title,
            });
        }
    }
}
