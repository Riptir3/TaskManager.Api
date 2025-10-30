using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using TaskManager.Api.Data;
using TaskManager.Api.Models.Entities;

namespace TaskManager.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController(AppDbContext context) : ControllerBase
    {
        private readonly AppDbContext _context = context;

        [HttpGet]
        public async Task<IActionResult> GetUserTasks(
            [FromQuery] bool? isCompleted,
            [FromQuery] DateTime? dueBefore,
            [FromQuery] string? search,
            [FromQuery] string? sortBy,
            [FromQuery] string? order = "asc")
        {
            var userid = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

            var query = _context.Tasks
                .Where(t => t.UserId == userid)
                .AsQueryable();

            if(isCompleted.HasValue)
                query = query.Where(t => t.IsCompleted == isCompleted.Value);

            if(dueBefore.HasValue)
                query = query.Where(t=>t.DueDate <= dueBefore.Value);

            if(!string.IsNullOrEmpty(search))
                query = query.Where(t =>
                t.Title.Contains(search) || (t.Description != null && t.Description.Contains(search)));

            if (!string.IsNullOrEmpty(sortBy))
            {
                bool ascending = order?.ToLower() == "asc";

                query = sortBy.ToLower() switch
                {
                    "title" => ascending ? query.OrderBy(t => t.Title) : query.OrderByDescending(t => t.Title),
                    "duedate" => ascending ? query.OrderBy(t => t.DueDate) : query.OrderByDescending(t => t.DueDate),
                    "iscompleted" => ascending ? query.OrderBy(t => t.IsCompleted) : query.OrderByDescending(t => t.IsCompleted),
                    _ => query.OrderBy(t => t.Id)
                };
            }
            else
            {
                query = query.OrderBy(t => t.Id);
            }
                var tasks = await query.ToListAsync();

            return Ok(tasks);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetTask(int id)
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            var task = await _context.Tasks.FirstOrDefaultAsync(t => t.Id == id && t.UserId == userId);

            if (task == null)
                return NotFound("Task not found or you don't have access to it.");

            return Ok(task);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTask([FromBody] TaskItem task)
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            task.UserId = userId;

            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTask), new { id = task.Id }, task);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateTask(int id, [FromBody] TaskItem updatedTask)
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            var task = await _context.Tasks.FirstOrDefaultAsync(t => t.Id == id && t.UserId == userId);

            if (task == null)
                return NotFound("Task not found or you don't have access to it.");

            task.Title = updatedTask.Title;
            task.Description = updatedTask.Description;
            task.DueDate = updatedTask.DueDate;
            task.IsCompleted = updatedTask.IsCompleted;

            await _context.SaveChangesAsync();
            return Ok(task);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            var task = await _context.Tasks.FirstOrDefaultAsync(t => t.Id == id && t.UserId == userId);

            if (task == null)
                return NotFound("Task not found or you don't have access to it.");

            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
