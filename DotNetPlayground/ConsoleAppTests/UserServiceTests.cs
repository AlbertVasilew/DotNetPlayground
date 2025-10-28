using ConsoleApp.MethodsToTest.Database;
using ConsoleApp.MethodsToTest.UserService;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;

namespace ConsoleAppTests
{
    [TestFixture]
    public class UserServiceTests
    {
        private readonly Mock<UserDbContext> userDbContextMock;
        private readonly UserService userService;

        public UserServiceTests()
        {
            userDbContextMock = new Mock<UserDbContext>(new DbContextOptions<UserDbContext>());
            userService = new UserService(userDbContextMock.Object);
        }

        [Test]
        public void UserExists_ShallReturnFalse_IfEmailIsEmpty()
        {
            var result = userService.UserExists("");
            Assert.That(result, Is.EqualTo(false));
            userDbContextMock.Verify(x => x.Set<User>().Any(), Times.Never);
        }
    }
}