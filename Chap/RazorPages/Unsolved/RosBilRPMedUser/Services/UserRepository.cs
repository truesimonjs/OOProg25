using Microsoft.AspNetCore.Identity;
using RosBilRP.Models;

namespace RosBilRP.Services
{
    public class UserRepository : EFCRepositoryBase<User,RosBilDBContext>, IUserRepository
    {
        private PasswordHasher<string> passwordHasher;
        public UserRepository()
        {
            this.passwordHasher = new();
        }
        public override int Create(User user)
        {
            user.Password = passwordHasher.HashPassword(user.Navn, user.Password);
            return base.Create(user);
        }
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
            PasswordVerificationResult result = passwordHasher.VerifyHashedPassword(user.Navn,user.Password, providedPassword);

            return result == PasswordVerificationResult.Success;
        }
    }
}
