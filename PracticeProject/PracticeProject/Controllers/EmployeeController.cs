using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PracticeProject.Repository;
using PracticeProject.RequestModels;

namespace PracticeProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        private readonly IEmployeeInterface _employeeInterface;

        public EmployeeController(IEmployeeInterface employeeInterface)
        {
            _employeeInterface = employeeInterface;
        }

        [Authorize(Roles ="employee")]
        [HttpGet]
        [Route("GetAllEmployeeDetails")]

        public IActionResult GetAll()

        {
            var data = _employeeInterface.GetEmployees();
            return Ok(data);

        }

        [Authorize(Roles ="admin")]
        [HttpGet]
        [Route("GetEmployee/Id")]

        public IActionResult GetEmployeeId(int id)

        {
            var data = _employeeInterface.GetEmployeebyId(id);
            return Ok(data);

        }
        [HttpPost]
        [Route("SaveEmployeeDetails")]

        public IActionResult SaveEmployee(AddEmplyeeDto addEmplyeeDto)
        {
            var data = _employeeInterface.AddEmployeeData(addEmplyeeDto);
            return Ok(data);
        }
    }
}
