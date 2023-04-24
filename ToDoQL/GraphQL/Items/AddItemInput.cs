namespace ToDoQL.GraphQL
{
    public record AddItemInput(string title, string description, bool isDone, int listId);
}