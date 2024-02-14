using System.ComponentModel;
using System.Diagnostics;

namespace ConsoleApp3
{
    public class DbService : IDb
    {
        private readonly AppContext _context = new AppContext();

        public bool AddUser(User user)
        {
             _context.Users.AddAsync(user);
             _context.SaveChangesAsync();

            return true;
        }

        public bool Login(User insertUser)
        {
            foreach (var user in _context.Users)
            {
                if (user.Login == insertUser.Login && user.Password == insertUser.Password)
                    return true;
            }

            return false;
        }

    }
}
