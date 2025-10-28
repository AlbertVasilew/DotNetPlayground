namespace ConsoleApp.MethodsToTest.UserNotifier
{
    public class UserNotifier
    {
        private readonly IEmailService _emailService;

        public UserNotifier(IEmailService emailService)
        {
            _emailService = emailService;
        }

        public bool NotifyUser(string email)
        {
            if (string.IsNullOrEmpty(email))
                return false;

            _emailService.SendEmail(email, "Welcome", "Thanks for joining!");
            return true;
        }
    }
}