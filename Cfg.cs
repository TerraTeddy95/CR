using System;
using System.Collections.Generic;
using System.IO;
using TShockAPI;
using Newtonsoft.Json;

namespace CodeReward
{
    public class Config
    {
        public Variables.Options ALL = new Variables.Options() { lengthCode = 8, Interval = 30, letters = "0123456789abcdefghijklmnopqrstuvwxyzQWERTYUIOPASDFGHJKLZXCVBNM", LoginIn = "You must be logged!", Muted = "You are muted, u can't write code!", newCode = "New code is: %code%", onHead = "I'm winner! Weeeehe!", TwoTimes = "Recently you were the first! Give others a chance!", winMessage = "Winner: %player%", twotimesblock = true, Packages = new Dictionary<string, Variables.Packages>() { { "default_package", new Variables.Packages { NextOneAfterThis = false, BuffOptions = new List<Variables.Buff>() { new Variables.Buff { Time = 6000, ID = 6 }, new Variables.Buff { Time = 6000, ID = 5 }, new Variables.Buff { Time = 6000, ID = 4 } }, ItemsOptions = new List<Variables.Item>() { new Variables.Item { Amount = 1, ID = 6, Prefix = 1 }, new Variables.Item { Amount = 30, ID = 50, Prefix = 1 }, new Variables.Item { Amount = 3, ID = 2, Prefix = 1 } } } }, { "default_package_2", new Variables.Packages { NextOneAfterThis = false, BuffOptions = new List<Variables.Buff>() { new Variables.Buff { Time = 6000, ID = 6 }, new Variables.Buff { Time = 6000, ID = 5 }, new Variables.Buff { Time = 6000, ID = 4 } }, ItemsOptions = new List<Variables.Item>() { new Variables.Item { Amount = 1, ID = 6, Prefix = 1 }, new Variables.Item { Amount = 30, ID = 50, Prefix = 1 }, new Variables.Item { Amount = 3, ID = 2, Prefix = 1 } } } } } };
        
        public void Write(string path)
        {
            File.WriteAllText(path, JsonConvert.SerializeObject(this, Formatting.Indented));
        }
        public static Config Read(string path)
        {
            return File.Exists(path) ? JsonConvert.DeserializeObject<Config>(File.ReadAllText(path)) : new Config();
        }
    }
}