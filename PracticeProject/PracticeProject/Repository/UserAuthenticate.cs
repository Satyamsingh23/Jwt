using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.IdentityModel.Tokens;
using PracticeProject.Models;
using PracticeProject.RequestModels;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PracticeProject.Repository
{
    public class UserAuthenticate:IUserAuthenticate
    {
        public IConfiguration _configuration;

        public readonly sdirectdbContext _context;

        public UserAuthenticate(IConfiguration configuration,sdirectdbContext context)
        {
            _configuration = configuration;
            _context= context;
        }

        public  ResponseModel Authenticate(UserCredential user)
        {
            ResponseModel response = new ResponseModel();
            MyLoginTable tableObj= new MyLoginTable();

            var obj = _context.MyLoginTables.Where(i => i.UserEmail == user.UserEmail && i.UserPassword == user.UserPassword).FirstOrDefault();
            if(obj!= null ) 
            {
                response.name = tableObj.DisplayName;

                response.ResponseMessage = "Valid User";
                response.Token = GenerateJSOWebToken(user);
              
                return response;

            }
            else
            {
                response.ResponseMessage = "Invalid";
                return response;
            }
        }

    
        public string GenerateJSOWebToken(UserCredential info)
        {
          
            
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email,info.UserEmail),
                //new Claim(ClaimTypes.Name, info.DisplayName),

                //new Claim(ClaimTypes.Role,"admin")
                new Claim(ClaimTypes.Role,"employee")

                };                  

            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(120),
                 signingCredentials:credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

















        //public ResponseModel LoginUser(LoginClass login)
        //{
        //    ResponseModel response= new ResponseModel();

        //    var data = _context.MyLoginTables.FirstOrDefault(i => i.UserEmail == add.UserEmail);

        //    if (data != null)
        //    {
        //        response.StatusCode = 400;
        //        response.ResponseMessage = "Enter Unique Details";
        //        return response;
        //    }
        //}


    }
}












//LINQ WAY To GET ALL ELEMENT
//var obj = (from data in _context.MyLoginTables
//           where data.DisplayName == user.DisplayName && data.UserPassword == user.UserPassword
//           select new UserCredential
//           {
//               DisplayName = data.DisplayName,
//               UserPassword = data.UserPassword,
//           }).FirstOrDefault();
//if (obj != null)
//{
//    response.ResponseMessage = "Valid User";
//    response.StatusCode = 200;


//}