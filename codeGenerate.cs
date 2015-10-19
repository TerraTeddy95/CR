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
                        Enumerable.Repeat(Variables.ALL.letters, i)
                                  .Select(s => s[random.Next(s.Length)])
                                  .ToArray());
                Variables.code = result;
                Variables.codeon = true;

                string message = Variables.ALL.newCode;
                while (message.Contains("%code%"))
                {
                    message = message.Replace("%code%", result);
                }

                TSPlayer.All.SendMessage("[CodeReward] " + message, Color.Silver);
                return result;
            }
            else
            {
                var random = new Random();
                string result = new string(
                        Enumerable.Repeat(Variables.ALL.letters, i)
                                  .Select(s => s[random.Next(s.Length)])
                                  .ToArray());
                Variables.code2 = result;
                Variables.codeon2 = true;
                string message = Variables.ALL.newCode;
                while (message.Contains("%code%"))
                {
                    message = message.Replace("%code%", result);
                }


                TSPlayer.All.SendMessage("[CodeReward]" + message, Color.Silver);
                return result;
            }
        }
    }
}