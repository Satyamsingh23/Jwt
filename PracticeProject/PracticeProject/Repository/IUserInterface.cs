using PracticeProject.RequestModels;

namespace PracticeProject.Repository
{
    public interface IUserInterface
    {
        public ResponseModel AddUserDetails(AddUser add);

        public ResponseModel GetUser();
    }
}
