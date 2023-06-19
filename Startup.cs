using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql;
//using Microsoft.EntityFrameworkCore.Tools;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;
using TestMaster2;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        var connectionString = "server=localhost;user=root;password=1234;database=Provas";

        var serverVersion = new MySqlServerVersion(new Version(8, 0, 32));
        
        services.AddDbContext<ProvasContext>(
            dbContextOptions => dbContextOptions
                .UseMySql(connectionString, serverVersion)
                // The following three options help with debugging, but should
                // be changed or removed for production.
                //.LogTo(Console.WriteLine, LogLevel.Information)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors()
        );
    }
}