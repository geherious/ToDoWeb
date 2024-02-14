namespace ToDoWeb.Contracts.Todo
{
    public record SaveItem(Guid Id, string Name, string? Description);
}
