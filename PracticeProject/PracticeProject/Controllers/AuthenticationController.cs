using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PracticeProject.Models;
using PracticeProject.Repository;
using PracticeProject.RequestModels;

namespace PracticeProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly sdirectdbContext _context;
        public IConfiguration _configuration;

        public IUserAuthenticate _authrnticate;

        public AuthenticationController(IConfiguration configuration, sdirectdbContext context, IUserAuthenticate auth)
        {
            _configuration = configuration;
            _context = context;
            _authrnticate = auth;


        }

        [HttpPost]
        [Route("AuthenticateUser")]

       public IActionResult AuthenticateUser(UserCredential login)
        {
            return Ok(_authrnticate.Authenticate(login));
        }

        [HttpPost("SetSession")]
     

        public IActionResult Set(string Key, string value)
        {
            HttpContext.Session.SetString(Key, value);
            return Ok();
        }

        [HttpGet("GetSession")]
       

        public IActionResult Get(string Key)
        {
            var value=HttpContext.Session.GetString(Key);
            return Ok(value);
        }


    }
}