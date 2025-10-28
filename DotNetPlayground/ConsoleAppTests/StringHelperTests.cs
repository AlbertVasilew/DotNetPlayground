using ConsoleApp.MethodsToTest;
using NUnit.Framework;

namespace ConsoleAppTests
{
    [TestFixture]
    public class StringHelperTests
    {
        [Test]
        public void Reverse_ShallReturnSameString_IfEmpty()
        {
            var helper = new StringHelper();
            var result = helper.Reverse("");
            Assert.That(result, Is.EqualTo(""));
        }

        [Test]
        public void Reverse_ShallReturnNull_OnNullInput()
        {
            var helper = new StringHelper();
            var result = helper.Reverse(null);
            Assert.That(result, Is.Null);
        }

        [TestCase("abc", "cba")]
        [TestCase("xyz", "zyx")]
        public void Reverse_ShallReturnReversedString_OnValidInput(string input, string expected)
        {
            var helper = new StringHelper();
            var result = helper.Reverse(input);
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}