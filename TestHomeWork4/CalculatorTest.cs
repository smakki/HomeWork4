using HomeWork4;

namespace TestHomeWork4;

[TestFixture]
[TestOf(typeof(Calculator))]
public class CalculatorTest
{

    [Test]
    public void Test1()
    {
        double[] values = [3, -1];
        Assert.That(Calculator.Calculate(1,-2,-3), Is.EqualTo(values)); 
    }
    
    [Test]
    public void Test2()
    {
        double[] values = [-5, 3];
        Assert.That(Calculator.Calculate(-1,-2,15), Is.EqualTo(values)); 
    }
    
    [Test]
    public void Test3()
    {
        double[] values = [-6,0];
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
    
    [Test]
    public void Test5()
    {
        try
        {
            var dict = new Dictionary<string, string>();
            dict.Add("a", "a");
            dict.Add("b", "2");
            dict.Add("c", "3");
            Calculator.Parse(dict);
        }
        catch (FormatException )
        {
            Assert.Pass();
        }
        Assert.Fail();
    }

}
