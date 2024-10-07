using HomeWork4;

namespace TestHomeWork4;

[TestFixture]
[TestOf(typeof(Calculator))]
public class CalculatorTest
{

    [Test]
    public void Test1()
    {
        var values = new double[] { 3, -1 };
        Assert.That(Calculator.Calculate(1,-2,-3), Is.EqualTo(values)); 
    }
    
    [Test]
    public void Test2()
    {
        var values = new double[] { -5, 3 };
        Assert.That(Calculator.Calculate(-1,-2,15), Is.EqualTo(values)); 
    }
    
    [Test]
    public void Test3()
    {
        var values = new double[] { -6 };
        Assert.That(Calculator.Calculate(1,12,36), Is.EqualTo(values)); 
    }
    
    [Test]
    public void Test4()
    {
        try
        {
            var values = Calculator.Calculate(5, 3, 7);
        }
        catch (NoSolutionException )
        {
            Assert.Pass();
        }
        Assert.Fail();
    }

}
