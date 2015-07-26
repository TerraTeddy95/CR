﻿using System;
using System.Collections.Generic;
using System.IO;
using TShockAPI;
using Newtonsoft.Json;

namespace CodeReward
{
    public class Config
    {
        public int BuffTime = 300;
        public int Interval = 30;
        public int lengthCode = 8;
        public string letters = "0123456789abcdefghijklmnopqrstuvwxyzQWERTYUIOPASDFGHJKLZXCVBNM";
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