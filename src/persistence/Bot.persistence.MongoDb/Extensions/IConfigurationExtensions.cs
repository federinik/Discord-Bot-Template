using Microsoft.Extensions.Configuration;

namespace Bot.persistence.MongoDb.Extensions;

public static class IConfigurationExtensions
{
    public static string GetConnString(this IConfiguration config)
    {
        var connectionString = config.GetConnectionString("defaut") ?? config["MONGO_CON_STRING"];

        if (string.IsNullOrWhiteSpace(connectionString))
        {
            throw new NullReferenceException("Please set the MONGO_CON_STRING with your MongoDb connection string.");
        }

        return connectionString;
    }
}
