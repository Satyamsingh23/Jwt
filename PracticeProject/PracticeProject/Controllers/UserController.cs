using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using PracticeProject.Repository;
using PracticeProject.RequestModels;

namespace PracticeProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserInterface _interface;

        public UserController(IUserInterface interfacee)
        {
            _interface = interfacee;
        }


        [HttpGet]
        [Route("GetUsers")]

        public IActionResult GetUsers()
        {
            var data = _interface.GetUser();
            return Ok(data);
        }

        [HttpPost]
        [Route("SaveUserDetails")]

        public IActionResult SaveEmployee(AddUser add)
        {
            var data = _interface.AddUserDetails(add);
            return Ok(data);
        }
    }
}
