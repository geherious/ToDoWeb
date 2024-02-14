using ToDoWeb.Contracts.Todo;
using ToDoWeb.Models;

namespace ToDoWeb.Services.Todo
{
    public interface IToDoService
    {
        Task<IList<ToDoItem>> GetAllItemsAsync();
        Task<ToDoItem> CreateItemAsync(CreateTodoItem createTodoItem);
        Task<Guid> DeleteItemAsync(Guid Id);
        Task<Guid> UpdateItem(SaveItem changeItemState);
    }
}
