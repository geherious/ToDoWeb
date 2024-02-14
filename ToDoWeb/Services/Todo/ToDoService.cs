using Microsoft.EntityFrameworkCore;
using ToDoWeb.Contracts.Todo;
using ToDoWeb.Data;
using ToDoWeb.Models;

namespace ToDoWeb.Services.Todo
{
    public class ToDoService : IToDoService
    {
        private readonly ApplicationDbContext _dbContext;

        public ToDoService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ToDoItem> CreateItemAsync(CreateTodoItem createTodoItem)
        {
            ToDoItem item = new ToDoItem
            {
                Name = createTodoItem.Name,
                Description = createTodoItem.Description,
                Created = DateTime.UtcNow
            };
            await _dbContext.ToDos.AddAsync(item);
            await _dbContext.SaveChangesAsync();
            return item;
        }

        public async Task<Guid> DeleteItemAsync(Guid Id)
        {
            var item = await _dbContext.ToDos.FirstOrDefaultAsync(x => x.Id == Id);
            if (item == null)
            {
                throw new Exception("Delete Exception");
            }
            _dbContext.ToDos.Remove(item);
            await _dbContext.SaveChangesAsync();
            return item.Id;
        }

        public async Task<IList<ToDoItem>> GetAllItemsAsync()
        {
            return await _dbContext.ToDos.OrderByDescending(x => x.Created).ToListAsync();
        }

        public async Task<Guid> UpdateItem(SaveItem changeItemState)
        {
            var item = await _dbContext.ToDos.FirstOrDefaultAsync(x => x.Id == changeItemState.Id);
            if (item == null)
            {
                throw new Exception("Updated item is null");
            }
            item.Name = changeItemState.Name;
            item.Description = changeItemState.Description;
            await _dbContext.SaveChangesAsync();
            return item.Id;

        }
    }
}
