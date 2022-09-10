using login_system.Models;

namespace login_system.Interfaces
{
    public interface IUser
    {
        User GetUser(string email, string password);

    }
}
