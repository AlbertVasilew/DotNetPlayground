using ConsoleApp.MethodsToTest.UserNotifier;
using Moq;
using NUnit.Framework;

namespace ConsoleAppTests
{
    [TestFixture]
    public class UserNotifierTests
    {
        private readonly Mock<IEmailService> emailService;
        private readonly UserNotifier userNotifier; 

        public UserNotifierTests()
        {
            emailService = new Mock<IEmailService>();
            userNotifier = new UserNotifier(emailService.Object);
        }

        [Test]
        public void NotifyUser_ShouldReturnFalse_WhenEmailIsEmpty()
        {
            var result = userNotifier.NotifyUser("");

            Assert.That(result, Is.EqualTo(false));

            emailService.Verify(
                x => x.SendEmail(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()),
                Times.Never);
        }

        [Test]
        public void NotifyUser_ShouldReturnFalse_WhenEmailIsNull()
        {
            var result = userNotifier.NotifyUser(null!);

            Assert.That(result, Is.EqualTo(false));

            emailService.Verify(
                x => x.SendEmail(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()),
                Times.Never);
        }

        [Test]
        public void NotifyUser_ShouldSendEmail_WhenEmailIsPresented()
        {
            var result = userNotifier.NotifyUser("avasilev2260@gmail.com");

            Assert.That(result, Is.EqualTo(true));

            emailService.Verify(
                x => x.SendEmail(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }
    }
}