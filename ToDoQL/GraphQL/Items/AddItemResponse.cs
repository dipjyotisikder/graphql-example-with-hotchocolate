namespace ToDoQL.GraphQL
{
    public record AddItemResponse(int Id, string Title, string Description, bool IsDone);
}