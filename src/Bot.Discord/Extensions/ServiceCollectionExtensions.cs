using Bot.Discord.Pipelines;
using Bot.persistence.MongoDb.Extensions;
using Color_Chan.Discord.Commands.Extensions;
using Color_Chan.Discord.Configurations;
using Color_Chan.Discord.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Bot.Discord.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDiscord(this IServiceCollection services, IConfiguration config)
    {
        var token = config["BOT_TOKEN"];
        if (token is null)
        {
            throw new NullReferenceException("Please set the BOT_TOKEN env variable!");
        }

        // Configure Color-Chan.Discord
        var ccConfig = new ColorChanConfigurations
        {
            SlashCommandConfigs = slashOptions => { slashOptions.SendDefaultErrorMessage = true; }
        };

        services.AddSlashCommandPipeline<GuildDbPipeline>();
        services.AddSlashCommandPipeline<CommandLoggingPipeline>();
        services.AddComponentInteractionPipeline<ComponentLoggingPipeline>();


        services.AddColorChanDiscord(token, Constants.PublicKey, Constants.BotId, ccConfig);
        services.AddMongoDb(config);

        return services;
    }
}