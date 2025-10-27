using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using STBEmployeeEntry.Interface;
using STBEmployeeEntry.Model;

namespace STBEmployeeEntry.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class STBEmployeeEntryController : ControllerBase
    {
        private readonly ISTBEmployeeEntry _Service;
        public STBEmployeeEntryController(ISTBEmployeeEntry service)
        {
            _Service = service;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<STBEmployeeEntryTable>>> GetEmployee()
        {
            var employees = await _Service.GetAllEmployeeAsync();
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<STBEmployeeEntryTable>> GetCustomer(int id)
        {
            var employee = await _Service.GetEmployeeByIdAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpPost]
        public async Task<ActionResult<STBEmployeeEntryTable>> CreateCustomer(STBEmployeeEntryTable employee)
        {
            var createdemployee = await _Service.CreateEmployeeAsync(employee);
            return CreatedAtAction(nameof(GetEmployee), new { id = createdemployee.Id }, createdemployee);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCustomer(int id, STBEmployeeEntryTable employee)
        {
            if (id != employee.Id)
            {
                return BadRequest();
            }

            await _Service.UpdateEmploYeeAsync(employee);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEmploYee(int id)
        {
            await _Service.DeleteEmploYeeAsync(id);
            return Ok();
        }
    }
}
