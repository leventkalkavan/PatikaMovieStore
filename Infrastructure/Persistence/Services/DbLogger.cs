using Application.Abstraction.Services;

namespace Persistence.Services;

public class DbLogger: ILoggerService
{
    public void Write(string message)
    {
        Console.WriteLine("[DbLogger]-" + message);
    }
}