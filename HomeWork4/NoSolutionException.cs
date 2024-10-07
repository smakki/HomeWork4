namespace HomeWork4;

public class NoSolutionException:Exception
{
    public NoSolutionException(): base(){}
    
    public NoSolutionException(string message): base(message){}
}