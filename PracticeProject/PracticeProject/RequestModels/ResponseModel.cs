using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace PracticeProject.RequestModels
{
    public class ResponseModel
    {
        public string ResponseMessage { get; set; }
        public int StatusCode { get; set; }
        public List<GetEmployeeDto>dataList { get; set; }

        public List<GetUser> UserList { get; set; }

        public GetEmployeeDto data { get; set; }

        public string Token { get; set; }

        public string name { get; set; }
        //public LoginClass CheckUser { get; set; }   

    }
    public class GetEmployeeDto
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; } = null!;
        public string EmpEmail { get; set; } = null!;
        public DateTime? Dob { get; set; }
        public int? EmpPhone { get; set; }
        public string? City { get; set; }
        public bool? IsActive { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
    }

    public class AddEmplyeeDto
    {
        [Required]
        [DefaultValue("")]
        public string EmpName { get; set; } = null!;

        [Required]
        [DefaultValue("")]
        public string EmpEmail { get; set; } = null!;

        [Required]
        public DateTime? Dob { get; set; }

        [Required]
        [DefaultValue("")]

        public int? EmpPhone { get; set; }

        [Required]
        [DefaultValue("")]
        public string? City { get; set; }
    }


    public class GetUser
    {
        public int UserId { get; set; }
        public string DisplayName { get; set; } = null!;
        public string? UserName { get; set; }
        public string UserEmail { get; set; } = null!;
        public string UserPassword { get; set; } = null!;
        public DateTime? CreateDate { get; set; }

    }

    public class AddUser
    {
        public string DisplayName { get; set; } = null!;

        //public string? UserName { get; set; }
        public string UserEmail { get; set; } = null!;
        public string UserPassword { get; set; } = null!;
        public DateTime? CreateDate { get; set; }

    }

    public class LoginClass
    {
        public string UserEmail { get; set; } = null!;
        public string UserPassword { get; set; } = null!;

    }

}

