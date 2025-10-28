using ConsoleApp.MethodsToTest;
using NUnit.Framework;

namespace ConsoleAppTests
{
    [TestFixture]
    public class MathUtilsTests
    {
        [TestCase(1, 3, 4)]
        [TestCase(5, 3, 8)]
        public void Add_ShallReturnSum_OnSpecifiedNum(int a, int b, int result)
        {
            // arrange
            var utils = new MathUtils();

            // act
            var sum = utils.Add(a, b);

            // assertion
            Assert.That(sum, Is.EqualTo(result));
        }

        [TestCase(6, 2, 3)]
        [TestCase(8, 2, 4)]
        public void Divide_ShallReturnDivisionResult_OnSpecificNum(int a, int b, int result)
        {
            var utils = new MathUtils();
            var division = utils.Divide(a, b);
            Assert.That(division, Is.EqualTo(result));
        }

        [Test]
        public void Divide_ShallThrowException_OnAnyZeroNum()
        {
            var utils = new MathUtils();
            Assert.Throws<DivideByZeroException>(() => utils.Divide(5, 0));
        }
    }
}