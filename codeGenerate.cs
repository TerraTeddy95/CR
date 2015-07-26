using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using TShockAPI;
using TerrariaApi.Server;
using System.Timers;
using Newtonsoft.Json;
using System.IO;

namespace CodeReward
{
    public class codeGenerate
    {


        public static string run(int i, bool playerSend)
        {
            if (playerSend == false)
            {
                var random = new Random();
                string result = new string(
                        Enumerable.Repeat(varslist.var.letters, i)
                                  .Select(s => s[random.Next(s.Length)])
                                  .ToArray());
                varslist.var.code = result;
                varslist.var.codeon = true;
                TSPlayer.All.SendMessage("[CodeReward] Nowy kod: " + result, Color.Silver);
                return result;
            }
            else
            {
                var random = new Random();
                string result = new string(
                        Enumerable.Repeat(varslist.var.letters, i)
                                  .Select(s => s[random.Next(s.Length)])
                                  .ToArray());
                varslist.var.code2 = result;
                varslist.var.codeon2 = true;
                TSPlayer.All.SendMessage("[CodeReward] Nowy kod: " + result, Color.Silver);
                return result;
            }
        }
    }
}
