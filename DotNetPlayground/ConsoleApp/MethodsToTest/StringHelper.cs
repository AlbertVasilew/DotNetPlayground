namespace ConsoleApp.MethodsToTest
{
    public class StringHelper
    {
        public string Reverse(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            return new string(input.Reverse().ToArray());
        }
    }
}