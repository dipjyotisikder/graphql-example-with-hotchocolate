namespace ToDoQL.GraphQL
{
    public record AddItemResponse(int id, string title, string description, bool isDone);
}