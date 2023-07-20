using PracticeProject.RequestModels;

namespace PracticeProject.Repository
{
    public interface IEmployeeInterface
    {
        public ResponseModel GetEmployees();

        public ResponseModel AddEmployeeData(AddEmplyeeDto employee);

        public ResponseModel GetEmployeebyId(int id);
    }
}
