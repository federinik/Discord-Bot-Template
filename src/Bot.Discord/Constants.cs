using System.Drawing;

namespace Bot.Discord;

public class Constants
{
    // Todo: Replace the publicKey and the botId with yours. https://discord.com/developers/applications.
    public const string PublicKey = "eee70feae02552c5b44ae2bc7bcbe9b90f3727fc4bba83552c5181292536120b";
    public const long BotId = 1031194086092312596;

    public const string ArgsSeparator = ";";
    public const string SlashPrefix = "/";

    public static class Colors
    {
        public static readonly Color Error = Color.Red;
        public static readonly Color Successful = Color.LawnGreen;
        public static readonly Color Neutral = Color.White;
    }
}