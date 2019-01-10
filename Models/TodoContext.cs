using Microsoft.EntityFrameworkCore;
using TodoAPI.Models.Todo;

namespace TodoAPI.Models
{
    /// <summary>
    /// DbContext
    /// </summary>
    public class TodoContext : DbContext
    {
        /// <summary>
        /// Collection of task todo
        /// </summary>
        /// <value></value>
        public DbSet<TodoItem> TodoItems { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public TodoContext(DbContextOptions<TodoContext> options) : base(options) { }
    }
}