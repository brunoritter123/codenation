using Xunit;

namespace Codenation.Challenge
{
    public class MathTest
    {

        [Fact]
        public void Fibonacci_Test()
        {
            var math = new Math();
            var result = math.Fibonacci();
            Assert.NotNull(result);
        }

        [Fact]
        public void Is_Fibonacci_Test()
        {
            var math = new Math();
            Assert.True(math.IsFibonacci(5));
        }

        [Fact]
        public void Is_NotFibonacci_Test()
        {
            var math = new Math();
            Assert.False(math.IsFibonacci(4));
        }

        [Fact]
        public void Is_NotFibonacci_Negative_Test()
        {
            var math = new Math();
            Assert.False(math.IsFibonacci(-1));
        }

        [Fact]
        public void Is_Fibonacci_Out_Range_Test()
        {
            var math = new Math();
            Assert.False(math.IsFibonacci(377));
        }

        [Fact]
        public void Is_Fibonacci_Zero_Test()
        {
            var math = new Math();
            Assert.True(math.IsFibonacci(0));
        }
    }
}
