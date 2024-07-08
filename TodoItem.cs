using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoQuarry;

[Table("todolist")]
public class TodoItem{
    public long ID { get; set; }
    [Column("taskname")]
    public string? taskName { get; set; }
    [Column("duedate")]
    public DateOnly dueDate { get; set; }
    [Column("priority")]
    public string? priority { get; set; }
    [Column("iscomplete")]
    public bool IsComplete { get; set; }
}