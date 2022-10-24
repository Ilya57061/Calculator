using Calculator.Logic.Implementations;
using Xunit;

namespace Calculator.Tests
{
    public class CalculationTests
    {
        
        [Fact]
        public void TestProcessStatement()
        {
            Calculation calculation = new();
            string result = calculation.ProcessStatement(" "," ");
            Assert.Equal("0", result);
            result = calculation.ProcessStatement("f","ff");
            Assert.Equal("0", result);
            result = calculation.ProcessStatement("", "+");
            Assert.Equal("0", result);
            result = calculation.ProcessStatement("", "");
            Assert.Equal("0", result);
            result = calculation.ProcessStatement("f", "");
            Assert.Equal("0", result);
            result = calculation.ProcessStatement("", "999999999+1");
            Assert.Equal("EXCEEDED", result);
            result = calculation.ProcessStatement("-", "999999999-1");
            Assert.Equal("EXCEEDED", result);
        }
        [Fact]
        public void TestSum()
        {
            Calculation calculation = new();
            string result = calculation.ProcessStatement("", "3+7");
            Assert.Equal("10", result);
            result = calculation.ProcessStatement("", "3+8");
            Assert.Equal("11", result);
            result = calculation.ProcessStatement("", "2+7");
            Assert.Equal("9", result);
            result = calculation.ProcessStatement("-", "1+7");
            Assert.Equal("6", result);
        }
        [Fact]
        public void TestMultiple()
        {
            Calculation calculation = new();
            string result = calculation.ProcessStatement("", "3*7");
            Assert.Equal("21", result);
            result = calculation.ProcessStatement("", "2*2");
            Assert.Equal("4", result);
            result = calculation.ProcessStatement("", "2*ммм");
            Assert.Equal("0", result);
            result = calculation.ProcessStatement("", "2*");
            Assert.Equal("0", result);
            result = calculation.ProcessStatement("", "2*-");
            Assert.Equal("0", result);
            result = calculation.ProcessStatement("-", "2*2");
            Assert.Equal("-4", result);
        }
        [Fact]
        public void TestSubtract()
        {
            Calculation calculation = new();
            string result = calculation.ProcessStatement("", "3-4");
            Assert.Equal("-1", result);
            result = calculation.ProcessStatement("", "3+2");
            Assert.Equal("5", result);
            result = calculation.ProcessStatement("-", "3+2");
            Assert.Equal("-1", result);
            result = calculation.ProcessStatement("", "3--");
            Assert.Equal("0", result);
            result = calculation.ProcessStatement("-", "47-f");
            Assert.Equal("0", result);
            result = calculation.ProcessStatement("", "2-3f");
            Assert.Equal("0", result);
        }
        [Fact]
        public void TestDivideReturn2()
        {
            Calculation calculation = new();
            string result = calculation.ProcessStatement("", "2/1");
            Assert.Equal("2", result);
        }
        [Fact]
        public void TestDivideReturn1()
        {
            Calculation calculation = new();
            string result = calculation.ProcessStatement("", "3/2");
            Assert.Equal("1", result);
        }
        [Fact]
        public void TestDivideReturn0()
        {
            Calculation calculation = new();
            string result = calculation.ProcessStatement("", "2/f");
            Assert.Equal("0", result);
        }
        [Fact]
        public void TestDivideReturnNot0()
        {
            Calculation calculation = new();
            string result = calculation.ProcessStatement("", "2/0");
            Assert.Equal("NOT ÷ 0", result);
        }
        [Fact]
        public void TestDivide()
        {
            Calculation calculation = new();
           string result = calculation.ProcessStatement("-", "10/2");
            Assert.Equal("-5", result);
            result = calculation.ProcessStatement("", "0/2");
            Assert.Equal("NOT ÷ 0", result);
            result = calculation.ProcessStatement("", "2/0");
            Assert.Equal("NOT ÷ 0", result);
        }
        [Fact]
        public void TestUnary()
        {
            Calculation calculation = new();
            string result = calculation.ProcessStatement("-", "4-2");
            Assert.Equal("-6", result);
            result = calculation.ProcessStatement("-", "4+5");
            Assert.Equal("1", result);
            result = calculation.ProcessStatement("-", "4/2");
            Assert.Equal("-2", result);
            result = calculation.ProcessStatement("-", "4*2");
            Assert.Equal("-8", result);
        }
    }
}
