using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeReward
{
    public static class varslist
    {
        public class var
        {
            public static int Inverval = 30;
            public static int BuffTime = 300;

            public static string letters = "0123456789abcdefghijklmnopqrstuvwxyzQWERTYUIOPASDFGHJKLZXCVBNM";
            public static string newCode = " New code is: %code%";
            public static string winMessage = " Winner: %player%";
            public static string LoginIn = " You must be logged!";
            public static string Muted = " You are muted, u can't write code!";
            public static string TwoTimes = " Recently you were the first! Give others a chance!";
            public static string onHead = "I'm winner! Weeeehe!";

            public static string code2;
            public static bool codeon2;

            public static string code;
            public static bool codeon;
            public static string lastp;
            public static int lengthCode;

            public static bool twotimesblock;

            public static List<int> RewardsBuffs;
            public static List<int> RewardsItems;
        }
    }
}
