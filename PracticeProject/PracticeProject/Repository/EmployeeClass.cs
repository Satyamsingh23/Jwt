using Microsoft.Data.SqlClient;
using PracticeProject.Models;
using PracticeProject.RequestModels;
using System.Data;

namespace PracticeProject.Repository
{
    public class EmployeeClass : IEmployeeInterface
    {
        //private readonly sdirectdbContext sdirectdbContext = new sdirectdbContext();
        public readonly sdirectdbContext _context;
        public EmployeeClass(sdirectdbContext context)
        {
            _context = context;                
        }

        public ResponseModel GetEmployees()
        {
            ResponseModel response = new ResponseModel();
            try
            {

                var data = (from emp in _context.EmployeeJuly3s
                            where emp.IsDeleted == false
                            select new GetEmployeeDto

                            {
                                EmpId = emp.EmpId,
                                EmpName = emp.EmpName,
                                EmpEmail = emp.EmpEmail,
                                Dob = emp.Dob,
                                EmpPhone = emp.EmpPhone,
                                IsActive = emp.IsActive,
                                City = emp.City,
                                CreatedBy = emp.CreatedBy,
                                CreatedOn = emp.CreatedOn,
                            }).ToList();
                response.ResponseMessage = "Data Fetched Successfully";
                response.StatusCode = 200;
                response.dataList = data;
                return response;
            }
            catch (Exception ex)
            {
                response.ResponseMessage = ex.Message;
                response.StatusCode = 500;
                return response;
            }
        }
        public ResponseModel GetEmployeebyId(int id)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                var data = (from e in _context.EmployeeJuly3s
                            where id == e.EmpId
                            select new GetEmployeeDto
                            {
                                EmpId = e.EmpId,
                                EmpName = e.EmpName,
                                EmpEmail = e.EmpEmail,
                                Dob = e.Dob,
                                EmpPhone = e.EmpPhone,
                                IsActive = e.IsActive,
                                City = e.City,
                                CreatedBy = e.CreatedBy,
                                CreatedOn = e.CreatedOn,

                            }).FirstOrDefault();
                response.ResponseMessage = "Data Fetched Successfully";
                response.StatusCode = 200;
                response.data = data;
                return response;

            }
            catch(Exception e)
            {
                response.ResponseMessage = e.Message;
                response.StatusCode = 500;
                return response;

            }

        }

        public ResponseModel AddEmployeeData(AddEmplyeeDto addEmplyeeDto)
        {
            ResponseModel response = new ResponseModel();
            try
            {


                var data = _context.EmployeeJuly3s.FirstOrDefault(i => i.EmpEmail == addEmplyeeDto.EmpEmail && i.EmpPhone == addEmplyeeDto.EmpPhone);

                if (data != null)
                {
                    response.StatusCode = 400;
                    response.ResponseMessage = "Enter Unique Details";
                    return response;
                }
                else
                {
                    var builder = WebApplication.CreateBuilder();
                    String ConnecStr = builder.Configuration.GetConnectionString("AppConn");
                    SqlConnection conn = new SqlConnection(ConnecStr);
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    SqlCommand cmd = new SqlCommand("PostEmployeeJuly", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@EmployeeName", SqlDbType.VarChar).Value = addEmplyeeDto.EmpName;
                    cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = addEmplyeeDto.EmpEmail;
                    cmd.Parameters.Add("@Dob", SqlDbType.VarChar).Value = addEmplyeeDto.Dob;
                    cmd.Parameters.Add("@phone", SqlDbType.VarChar).Value = addEmplyeeDto.EmpPhone;
                    cmd.Parameters.Add("@city", SqlDbType.VarChar).Value = addEmplyeeDto.City;

                    int iReturn = cmd.ExecuteNonQuery();
                    if (iReturn > 0)
                    {
                        response.StatusCode = 200;
                        response.ResponseMessage = "Employee Added Successfuly";
                        return response;
                    }
                    else
                    {
                        response.StatusCode = 400;
                        response.ResponseMessage = "Employee not added";
                        return response;
                    }

                }
            }
            catch (Exception ex)
            {
                response.ResponseMessage = ex.Message;
                response.StatusCode = 500;
                return response;
            }
        }
    }
}
