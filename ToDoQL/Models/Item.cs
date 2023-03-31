namespace ToDoQL.Models
{
    public class Item
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public bool IsDone { get; set; }

        public int ListId { get; set; }

        public virtual ItemList ItemList { get; set; }

    }
}
