using System;
using System.Collections.Generic;
using System.IO;
using TShockAPI;
using Newtonsoft.Json;

namespace CodeReward
{
    public class Config
    {
        public bool twotimesblock = true;

        public int BuffTime = 300;
        public int Interval = 30;
        public int lengthCode = 8;
        public string letters = "0123456789abcdefghijklmnopqrstuvwxyzQWERTYUIOPASDFGHJKLZXCVBNM";
        public string newCode = " New code is: %code%";
        public string winMessage = " Winner: %player%";
        public string LoginIn = " You must be logged!";
        public string Muted = " You are muted, u can't write code!";
        public string TwoTimes = " Recently you were the first! Give others a chance!";
        public string onHead = "I'm winner! Weeeehe!";

        public List<int> RewardsBuffs = new List<int> { 1, 2, 3, 4, 5 };
        public List<int> RewardsItems = new List<int> { 1, 2, 3, 4, 5 };
  





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
