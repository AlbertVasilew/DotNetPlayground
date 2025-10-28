using ConsoleApp.MethodsToTest.Database;

namespace ConsoleApp.MethodsToTest.UserService
{
    public class UserService : IUserService
    {
        private readonly UserDbContext _dbContext;

        public UserService(UserDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool UserExists(string email)
        {
            if (string.IsNullOrEmpty(email)) return false;

            return _dbContext.Users.Any(u => u.Email == email);
        }
    }
}