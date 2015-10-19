using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using TShockAPI;
using TerrariaApi.Server;

namespace CodeReward
{
    public class Variables
    {

        public static string code2;
        public static bool codeon2;
        public static string code;
        public static bool codeon;
        public static string lastp;

        public static Variables.Options ALL = new Variables.Options();



        public class Options
        {
            public bool twotimesblock = true;
            public int lengthCode = 8;
            public int Interval = 30;
            public string letters = "0123456789abcdefghijklmnopqrstuvwxyzQWERTYUIOPASDFGHJKLZXCVBNM";
            public string newCode = " New code is: %code%";
            public string winMessage = " Winner: %player%";
            public string LoginIn = " You must be logged!";
            public string Muted = " You are muted, u can't write code!";
            public string TwoTimes = " Recently you were the first! Give others a chance!";
            public string onHead = "I'm winner! Weeeehe!";
            public Dictionary<string, Variables.Packages> Packages = new Dictionary<string, Variables.Packages>();
        }
        public class Packages
        {
            public bool NextOneAfterThis = true;
            public List<Item> ItemsOptions = new List<Item>();
            public List<Buff> BuffOptions = new List<Buff>();
        }

        public class Buff
        {
            public int Time = 60000;
            public int ID = 1;
        }
        public class Item
        {
            public int Amount = 1;
            public int ID = 1;
            public int Prefix = 1;
        }
    }
}