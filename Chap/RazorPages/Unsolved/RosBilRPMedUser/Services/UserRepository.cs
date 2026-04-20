using RosBilRP.Models;

namespace RosBilRP.Services
{
    public class UserRepository : EFCRepositoryBase<User,RosBilDBContext>, IUserRepository
    {
        public List<string> Roles
        {
            get
            {
                return new List<string>() { "admin", "ansat" };
            }
        }
        public User? VerifyUser(string providedUsername, string providedPassword)
        {
            User? user = All.FirstOrDefault(u=>u.Navn == providedUsername);

            if (user == null || !VerifyPassword(user, providedPassword))
            {
                return null;
            }
            return user;
            
        
        }

        private bool VerifyPassword(User user, string providedPassword)
        {
            return user.Password == providedPassword;
        }
    }
}
