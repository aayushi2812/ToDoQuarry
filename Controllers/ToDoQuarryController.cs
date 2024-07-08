using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoQuarry.Models;

namespace ToDoQuarry.Controllers;

[ApiController]
[Route("TodoItems")]
public class ToDoQuarryController : ControllerBase
{
    private readonly TodoContext _context;
    public ToDoQuarryController(TodoContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IEnumerable<TodoItem> Get(){
        return _context.todolist.AsEnumerable();
    }

    [HttpPost]
    public async Task<ActionResult<TodoItem>> PostTodoItem(TodoItem todoItem)
    {
        // DateTime today = DateTime.Now;
        // todoItem.dueDate = DateOnly.FromDateTime(today);
        _context.todolist.Add(todoItem);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(PostTodoItem), new { id = todoItem.ID }, todoItem);
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

    [HttpPut("{id}")]
    public async Task<IActionResult> PutTodoItem(long id, TodoItem todoItem)
    {
        if (id != todoItem.ID)
        {
            return BadRequest();
        }

        _context.Entry(todoItem).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TodoItemExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTodoItem(long id)
    {
        var todoItem = await _context.todolist.FindAsync(id);
        if (todoItem == null)
        {
            return NotFound();
        }

        _context.todolist.Remove(todoItem);
        await _context.SaveChangesAsync();

        return NoContent();
    }


    private bool TodoItemExists(long id)
    {
        return _context.todolist.Any(e => e.ID == id);
    }
}