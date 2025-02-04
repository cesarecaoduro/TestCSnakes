using CSnakes.Runtime;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ConsoleApp;

internal class Program
{
    static void Main(string[] args)
    {
        var home = Path.Join(Environment.CurrentDirectory, "..", "..", "..", "..");
        var venv = Path.Join(home, ".venv");
        var builder = Host.CreateDefaultBuilder(args)
            .ConfigureServices(services =>
            {
                services
                    .WithPython()
                    //.WithHome(home)
                    .WithVirtualEnvironment(venv)
                    .FromNuGet("3.12.8");
                    //.FromMacOSInstallerLocator("3.12.8");
                    //.WithPipInstaller();
            });
        var app = builder.Build();
        var env = app.Services.GetRequiredService<IPythonEnvironment>();
        var ifcOps = env.IfcOps();
        Console.WriteLine($"Ifcopenshell version: {ifcOps.GetVersion()}");
        Console.ReadKey();
    }
}
