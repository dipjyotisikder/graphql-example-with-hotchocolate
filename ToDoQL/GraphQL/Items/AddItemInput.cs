namespace ToDoQL.GraphQL
{
    public record AddItemInput(string Title, string Description, bool IsDone, int ListId);
}