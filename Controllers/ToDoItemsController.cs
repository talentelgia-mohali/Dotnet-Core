using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CoreExample.Models;

namespace CoreExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoItemsController : ControllerBase
    {
        private readonly TodoContext _context;

        public ToDoItemsController(TodoContext context)
        {
            _context = context;
        }

        // GET: api/ToDoItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployee()
        {
            return await _context.Employees.ToListAsync();
        }

        // GET: api/ToDoItems/5
        [HttpGet("GetEmployee/{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var toDoItem = await _context.Employees.FindAsync(id);

            if (toDoItem == null)
            {
                return NotFound();
            }

            return toDoItem;
        }

        // PUT: api/ToDoItems/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int id, Employee emp)
        {
            if (id != emp.EmployeeId)
            {
                return BadRequest();
            }

            _context.Entry(emp).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
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

        // POST: api/ToDoItems
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        // POST: api/TodoItems
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(Employee emp)
        {
            _context.Employees.Add(emp);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
            return CreatedAtAction(nameof(GetEmployee), new { id = emp.EmployeeId }, emp);
        }

        // DELETE: api/ToDoItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Employee>> DeleteEmployee(int id)
        {
            var toDoItem = await _context.Employees.FindAsync(id);
            if (toDoItem == null)
            {
                return NotFound();
            }

            _context.Employees.Remove(toDoItem);
            await _context.SaveChangesAsync();

            return toDoItem;
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.EmployeeId == id);
        }
    }
}
