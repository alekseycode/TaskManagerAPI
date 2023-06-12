using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using taskManagerAPI.Models;

namespace taskManagerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private List<Tassk> _tasks = new List<Tassk>();

        // GET: api/Tasks
        [HttpGet]
        public ActionResult<IEnumerable<Tassk>> GetTasks()
        {
            return Ok(_tasks);
        }

        // GET: api/Tasks/5
        [HttpGet("{id}")]
        public ActionResult<Tassk> GetTask(int id)
        {
            Tassk task = _tasks.Find(t => t.Id == id);
            if (task == null)
            {
                return NotFound();
            }

            return Ok(task);
        }

        // POST: api/Tasks
        [HttpPost]
        public ActionResult<Tassk> CreateTask(Tassk task)
        {
            // Assign a new ID to the task
            task.Id = _tasks.Count + 1;

            // Add the task to the list
            _tasks.Add(task);

            // Return the created task with the appropriate response status
            return CreatedAtAction(nameof(GetTask), new { id = task.Id }, task);
        }

        // PUT: api/Tasks/5
        [HttpPut("{id}")]
        public IActionResult UpdateTask(int id, Tassk updatedTask)
        {
            Tassk task = _tasks.Find(t => t.Id == id);
            if (task == null)
            {
                return NotFound();
            }

            // Update the properties of the existing task
            task.Title = updatedTask.Title;
            task.Description = updatedTask.Description;
            task.Status = updatedTask.Status;

            // Return a no content response
            return NoContent();
        }

        // DELETE: api/Tasks/5
        [HttpDelete("{id}")]
        public IActionResult DeleteTask(int id)
        {
            Tassk task = _tasks.Find(t => t.Id == id);
            if (task == null)
            {
                return NotFound();
            }

            // Remove the task from the list
            _tasks.Remove(task);

            // Return a no content response
            return NoContent();
        }
    }
}