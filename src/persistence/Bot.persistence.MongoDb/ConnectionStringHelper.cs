﻿namespace Bot.persistence.MongoDb;

public class ConnectionStringHelper
{
    public static string GetMongoDbConnectionString()
    {
        // https://docs.mongodb.com/manual/reference/connection-string/
        var connectionString = Environment.GetEnvironmentVariable("MONGO_CON_STRING");

        if (string.IsNullOrWhiteSpace(connectionString))
        {
            throw new NullReferenceException("Please set the MONGO_CON_STRING with your MongoDb connection string.");
        }

        return connectionString;
    }
}