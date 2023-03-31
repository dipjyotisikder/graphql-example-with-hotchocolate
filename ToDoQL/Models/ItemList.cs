using System.Collections.Generic;

namespace ToDoQL.Models
{
    public class ItemList
    {
        public ItemList()
        {
            Items = new HashSet<Item>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Item> Items { get; set; }
    }
}
