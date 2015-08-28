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
            public static string newCode = " Wygenerowano nowy kod: %kod%";
            public static string winMessage = " Zwyciezca: %gracz%";
            public static string LoginIn = " Musisz byc zalogowany aby moc wpisywac kod!";
            public static string Muted = " Jestes zmutowany! nie mozesz wpisywac kodu!";
            public static string TwoTimes = " Ostatnio ty byles pierwszy! Daj szanse innym!";
            public static string onHead = "Jestem zwyciezca! Weeeehe!";

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
