using Microsoft.EntityFrameworkCore;
using TodoAPI.Models.Todo;

namespace TodoAPI.Models
{
    /// <summary>
    /// DbContext
    /// </summary>
    public class TodoContext : DbContext
    {
        public DbSet<TodoItem> TodoItems { get; set; }

        public TodoContext(DbContextOptions<TodoContext> options) : base(options) { }
    }
}