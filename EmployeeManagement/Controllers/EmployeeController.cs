using System.Threading.Tasks;
using BusinessLayer.Contracts;
using EmployeeManagement.DTOs;
using Microsoft.AspNetCore.Mvc;


namespace EmployeeManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeManager _employeeManager;

        public EmployeeController(IEmployeeManager employeeManager)
        {
            _employeeManager = employeeManager;
        }

        [HttpGet]
        public async Task<ActionResult<EmployeeDTO>> Get([FromQuery]int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var employees = await _employeeManager.EmployeeDetails(pageNumber, pageSize);
            return Ok(employees);
        }

        [HttpDelete("{employeeId}")]
        public async Task<ActionResult> Delete([FromRoute] long employeeId)
        {
            var response = await _employeeManager.DeleteEmployee(employeeId);

            if (response)
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
