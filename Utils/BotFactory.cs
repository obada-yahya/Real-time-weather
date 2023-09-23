﻿namespace Real_time_weather.Utils;

public class BotFactory
{
    public static Bot? GetBot(BotSettings botSettings, string name)
    {
        var botName = name.ToLower();
        var message = botSettings.Message;
        Bot? bot = null;
        if (botName == "rainbot")
        {
            bot = new RainBot(botSettings.HumidityThreshold,message);
        }
        else if (botName == "snowbot")
        {
            bot = new SnowBot(botSettings.TemperatureThreshold, message);
        }
        else if (botName == "sunbot")
        {
            bot = new SunBot(botSettings.TemperatureThreshold, message);
        }
        else
        {
            Console.WriteLine($"{name} is not supported by the system.");
        }
        return bot;
    }
}