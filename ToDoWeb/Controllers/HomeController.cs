using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ToDoWeb.Contracts.Todo;
using ToDoWeb.Services.Todo;
using ToDoWeb.Models;

namespace ToDoWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly IToDoService _toDoService;

        public HomeController(IToDoService toDoService)
        {
            _toDoService = toDoService;
        }

        [HttpGet]
        public async Task<IActionResult> Items()
        {
            var itemList = await _toDoService.GetAllItemsAsync();
            return Ok(itemList);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTodoItem createTodoItem)
        {
            if (createTodoItem.Name is null || createTodoItem.Name.Length == 0 || !ModelState.IsValid)
            {
                return BadRequest();
            }
            var newItem = await _toDoService.CreateItemAsync(createTodoItem);
            return Ok(newItem);
        }
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] SaveItem saveItem)
        {
            if (saveItem.Name is null || saveItem.Name.Length == 0 || !ModelState.IsValid)
            {
                return BadRequest();
            }
            var id = await _toDoService.UpdateItem(saveItem);
            return Ok(id);
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromBody] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _toDoService.DeleteItemAsync(id);
            return Ok(id);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
