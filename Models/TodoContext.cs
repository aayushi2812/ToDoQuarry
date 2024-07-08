using Microsoft.EntityFrameworkCore;
namespace ToDoQuarry.Models;

public class TodoContext : DbContext
{

    protected readonly IConfiguration Configuration;

    public TodoContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to postgres with connection string from app settings
            options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"));
        }


    public DbSet<TodoItem> todolist { get; set; } = null!;

    public DbSet<TodoItem> userList { get; set; } = null!;
}