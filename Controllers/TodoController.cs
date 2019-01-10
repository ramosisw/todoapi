using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoAPI.Models.Todo;
using TodoAPI.Models.Messages;
using TodoAPI.Models;

namespace TodoAPI.Controllers
{
    /// <summary>
    /// Main Controller of todo Tasks
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly TodoContext _context;

        /// <summary>
        /// Init a context of controller
        /// </summary>
        /// <param name="context"></param>
        public TodoController(TodoContext context)
        {
            _context = context;
            //Insert only is any item added yet
            if (_context.TodoItems.Count() == 0)
            {
                _context.TodoItems.Add(new TodoItem
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Install docker",
                    Details = "download a docker system for your system",
                    IsDone = true,
                    EndDate = new DateTime(2018, 12, 26, 21, 00, 00),
                    StartDate = new DateTime(2018, 12, 28, 22, 00, 00)
                });

                _context.TodoItems.Add(new TodoItem
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Install MySql 5.7",
                    Details = "$ docker pull mysql:5.7",
                    IsDone = true,
                    EndDate = new DateTime(2018, 12, 26, 22, 00, 00),
                    StartDate = new DateTime(2018, 12, 28, 22, 30, 00)
                });

                _context.TodoItems.Add(new TodoItem
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Models & DbContext",
                    Details = "Write code that transport the data arround client <-> server",
                    IsDone = true,
                    EndDate = new DateTime(2018, 12, 26, 22, 30, 00),
                    StartDate = new DateTime(2018, 12, 28, 23, 00, 00)
                });

                _context.TodoItems.Add(new TodoItem
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Controller",
                    Details = "Write code that manipulate data of TodoItems",
                    IsDone = true,
                    EndDate = new DateTime(2018, 12, 27, 21, 00, 00),
                    StartDate = new DateTime(2018, 12, 27, 22, 00, 00)
                });

                _context.TodoItems.Add(new TodoItem
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Learn docker-compose",
                    Details = "Learn how to work with docker-compose",
                    IsDone = true,
                    EndDate = new DateTime(2018, 12, 27, 22, 00, 00),
                    StartDate = new DateTime(2018, 12, 28, 00, 00, 00)
                });

                _context.TodoItems.Add(new TodoItem
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Learn First Migrations",
                    Details = "Learn how to implement first migrations with docker-compose",
                    IsDone = true,
                    EndDate = new DateTime(2018, 12, 29, 15, 00, 00),
                    StartDate = new DateTime(2018, 12, 29, 20, 00, 00)
                });
                _context.SaveChanges();
            }
        }

        /// <summary>
        /// Get list of tasks
        /// </summary>
        /// <response code="200">List of task todo</response>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItem>>> Get()
        {
            return await _context.TodoItems.ToArrayAsync();
        }

        /// <summary>
        /// Get single task by Id
        /// </summary>
        /// <param name="id">Id of task to get full content</param>
        /// <response code="200">Task with id</response>
        /// <response code="404">Task with "id" not found</response>
        /// <returns>mixed</returns>
        [ProducesResponseType(200, Type = typeof(TodoItem))]
        [ProducesResponseType(404, Type = typeof(SimpleMessage))]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var todoItem = await _context.TodoItems.FindAsync(id);
            if (todoItem == null)
                return NotFound(new SimpleMessage { Code = 404, Message = $"Item with id={id} not found" });
            return Ok(todoItem);
        }

        /// <summary>
        /// Add new task
        /// </summary>
        /// <param name="todoItem">Object to put in database</param>
        /// <response code="200">Object inserted on database</response>
        /// <response code="400">Request body is empty</response>
        /// <returns>mixed</returns>
        [ProducesResponseType(200, Type = typeof(TodoItem))]
        [ProducesResponseType(400, Type = typeof(SimpleMessage))]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TodoItem todoItem)
        {
            if (todoItem == null) return BadRequest(new SimpleMessage { Code = 400, Message = "Request body is empty" });
            todoItem.Id = Guid.NewGuid().ToString();
            await _context.TodoItems.AddAsync(todoItem);
            await _context.SaveChangesAsync();
            return Ok(todoItem);
        }

        /// <summary>
        /// Update task with specified id
        /// </summary>
        /// <param name="id">Id of task to update</param>
        /// <param name="todoItem">Object content to update in database</param>
        /// <response code="200">Object updated on database</response>
        /// <response code="400">Request body is empty</response>
        /// <response code="404">Task with "id" not found</response>
        /// <returns></returns>
        [ProducesResponseType(200, Type = typeof(TodoItem))]
        [ProducesResponseType(400, Type = typeof(SimpleMessage))]
        [ProducesResponseType(404, Type = typeof(SimpleMessage))]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] TodoItem todoItem)
        {
            if (todoItem == null) return BadRequest(new SimpleMessage { Code = 400, Message = "Request body is empty" });
            var _todoItem = await _context.TodoItems.FindAsync(id);
            if (_todoItem == null) return NotFound(new SimpleMessage { Code = 404, Message = $"Item with id={id} not found" });
            _todoItem.Details = todoItem.Details;
            _todoItem.EndDate = todoItem.EndDate;
            _todoItem.IsDone = todoItem.IsDone;
            _todoItem.Name = todoItem.Name;
            _todoItem.StartDate = todoItem.StartDate;
            _context.TodoItems.Update(_todoItem);
            await _context.SaveChangesAsync();
            return Ok(_todoItem);
        }

        /// <summary>
        /// Delete specified task 
        /// </summary>
        /// <param name="id">Id of task to delete</param>
        /// <response code="200">Object deleted on database</response>
        /// <response code="404">Task with "id" not found</response>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(200, Type = typeof(SimpleMessage))]
        [ProducesResponseType(404, Type = typeof(SimpleMessage))]
        public async Task<IActionResult> Delete(string id)
        {
            var _todoItem = await _context.TodoItems.FindAsync(id);
            if (_todoItem == null) return NotFound(new SimpleMessage { Code = 404, Message = $"Item with id={id} not found" });

            _context.TodoItems.Remove(_todoItem);
            await _context.SaveChangesAsync();
            return Ok(new SimpleMessage { Code = 200, Message = "Delete success" });
        }
    }
}
