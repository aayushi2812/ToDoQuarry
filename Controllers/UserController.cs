using Microsoft.AspNetCore.Mvc;
using ToDoQuarry.Models;

namespace ToDoQuarry.Controllers;

[ApiController]
[Route("user")]
public class UserController : ControllerBase
{
    private readonly TodoContext _context;

    public UserController(TodoContext context)
    {
        _context = context;
    }


    [HttpGet("{id}")]
    public async Task<ActionResult<TodoItem>> GetTodoItem(long id)
    {
        var todoItem = await _context.todolist.FindAsync(id);

        if (todoItem == null)
        {
            return NotFound();
        }

        return todoItem;
    }

    [HttpPost]
    public async Task<ActionResult<TodoItem>> PostTodoItem(TodoItem todoItem)
    {
        DateTime today = DateTime.Now;
        todoItem.dueDate = DateOnly.FromDateTime(today);
        _context.todolist.Add(todoItem);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(PostTodoItem), new { id = todoItem.ID }, todoItem);
    }
}