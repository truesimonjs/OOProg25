using RosBilRP.Models;

namespace RosBilRP.Services
{
    public interface IUserRepository : IRepository<User>
    {
        User? VerifyUser(string providedUsername, string providedPassword);
        List<string> Roles { get; }
    }
}
