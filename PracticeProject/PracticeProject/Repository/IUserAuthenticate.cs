using PracticeProject.RequestModels;

namespace PracticeProject.Repository
{
    public interface IUserAuthenticate
    {

      
        public ResponseModel Authenticate(UserCredential user);

        //public ResponseModel LoginUser(LoginClass login);
    }
}
