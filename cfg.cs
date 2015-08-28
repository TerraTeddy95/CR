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
        public string newCode = " Wygenerowano nowy kod: %kod%";
        public string winMessage = " Zwyciezca: %gracz%";
        public string LoginIn = " Musisz byc zalogowany aby moc wpisywac kod!";
        public string Muted = " Jestes zmutowany! nie mozesz wpisywac kodu!";
        public string TwoTimes = " Ostatnio ty byles pierwszy! Daj szanse innym!";
        public string onHead = "Jestem zwyciezca! Weeeehe!";

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
