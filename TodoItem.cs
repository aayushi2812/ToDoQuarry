namespace ToDoQuarry;
public class TodoItem{
    public long Id { get; set; }
    public string? taskName { get; set; }
    public DateOnly dueDate { get; set; }
    public string? priority { get; set; }
    public bool IsComplete { get; set; }
}