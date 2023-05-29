using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiDbMigrations.Data;
using WebApiDbMigrations.Models;
using WebApiDbMigrations.Services;

namespace WebApiDbMigrations.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly WebApiDbMigrationsContext _context;
        private readonly IMapper _mapper;
        private readonly IEmpRepository _empRepository;

        public EmployeesController(WebApiDbMigrationsContext context, IMapper mapper, IEmpRepository empRepository)
        {
            _context = context;
            _mapper = mapper;
            _empRepository = empRepository;
        }

        // GET: api/Employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployee()
        {
            if (_context.Employee == null)
            {
                return NotFound();
            }
            var emp = await _empRepository.GetEmployee();
            var emp1 = emp.Select(x => _mapper.Map<Employee>(x));
            return (emp);

        }

        // GET: api/Employees/5
        //[Route("Employees/GetEmployee/")]
        [HttpGet("{id}")]

        public async Task<ActionResult<Employee>> GetEmployeeById(int id)
        {
            if (_context.Employee == null)
            {
                return NotFound();
            }
            var employee = await _empRepository.GetEmployeeById(id);

            if (employee == null)
            {
                return NotFound();
            }
            var item = _mapper.Map<Employee>(employee);
            return item;

        }

        // PUT: api/Employees/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int id, Employee employee)
        {
            if (id != employee.Id)
            {
                return BadRequest();
            }
            _context.Entry(employee).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();

            //    var updateEmp1 = _mapper.Map<Employee>(_context.Entry(employee).State);

            //    try
            //    {
            //        await _context.SaveChangesAsync();
            //    }
            //    catch (DbUpdateConcurrencyException)
            //    {
            //        if (!EmployeeExists(id))
            //        {
            //            return NotFound();
            //        }
            //        else
            //        {
            //            throw;
            //        }
            //    }

            //    return Ok(updateEmp1);


        }

        // POST: api/Employees
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        {
            if (_context.Employee == null)
            {
                return Problem("Entity set 'WebApiDbMigrationsContext.Employee'  is null.");
            }
            await _empRepository.AddEmployeeAsync(employee);
            _mapper.Map<Employee>(employee);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployee", new { id = employee.Id }, employee);
        }

        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            if (_context.Employee == null)
            {
                return NotFound();
            }
            var employee = await _empRepository.GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound();
            }

            await _empRepository.DeleteEmployeeAsync(id);
            //await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployeeExists(int id)
        {
            return (_context.Employee?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
