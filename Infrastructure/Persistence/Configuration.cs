using Microsoft.Extensions.Configuration;

namespace Persistence;

public class Configuration
{
    public static string? GetConnectionString
    {
        get
        {
            ConfigurationManager configurationManager = new();
            configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(),
                //API projesinin tam yolunu yaz
                "/../../../Prestation/WebAPI.API"));
            configurationManager.AddJsonFile("appsettings.json");
                                                            //appsettings.jsondaki connectionStringsin altındaki parametre
            return configurationManager.GetConnectionString("SqlConnectonName");
        }
    }
}