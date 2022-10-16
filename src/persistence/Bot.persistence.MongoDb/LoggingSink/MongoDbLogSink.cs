using Bot.persistence.MongoDb.Extensions;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Serilog;
using Serilog.Configuration;
using Serilog.Sinks.Mongodb.TimeSeries.Configurations;
using Serilog.Sinks.Mongodb.TimeSeries.Extensions;

namespace Bot.persistence.MongoDb.LoggingSink;

public static class MongoDbLogSink
{
    /// <summary>
    ///     Add a MongoDB log sink to serilog.
    ///     This will save all the logs to the database.
    /// </summary>
    /// <param name="configuration">Controls sink configuration.</param>
    /// <returns>
    ///     The sink configurations.
    /// </returns>
    public static LoggerConfiguration MongoDb(this LoggerSinkConfiguration configuration, IConfiguration config)
    {
        var client = new MongoClient(config.GetConnString());
        var mongoDatabase = client.GetDatabase(Constants.DatabaseName);

        var configs = new MongoDbTimeSeriesSinkConfig(mongoDatabase)
        {
            CollectionName = "Logs",
            SyncingPeriod = TimeSpan.FromSeconds(10),
            EagerlyEmitFirstEvent = true,
            LogsExpireAfter = TimeSpan.FromDays(7)
        };

        return configuration.MongoDbTimeSeriesSink(configs);
    }
}