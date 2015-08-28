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
    [ApiVersion(1, 21)]
    public class main : TerrariaPlugin
    {

        public static Config Config;

        public main(Main game) : base(game) { Order -= 1; }

        public override Version Version { get { return new Version("1.7"); } }
        public override string Name { get { return "CodeReward"; } }
        public override string Author { get { return "Teddy"; } }
        public override string Description { get { return "Who first type code win!"; } }

        public override void Initialize()
        {
            Commands.ChatCommands.Add(new Command(permission.codereward, command.functionCmd, "codereward"));
            Commands.ChatCommands.Add(new Command(permission.codereward, command.functionCmd, "crt"));
            ServerApi.Hooks.ServerChat.Register(this, chat.onChat);

            string path = Path.Combine(TShock.SavePath, "CodeReward.json");
            Config = Config.Read(path);
            if (!File.Exists(path))
            {
                Config.Write(path);
            }

            string version = "1.3.0.8 (1.7)";
            varslist.var.codeon = false;
            varslist.var.Inverval = Config.Interval;
            varslist.var.RewardsBuffs = Config.RewardsBuffs;
            varslist.var.RewardsItems = Config.RewardsItems;
            varslist.var.BuffTime = Config.BuffTime;
            varslist.var.lengthCode = Config.lengthCode;
            varslist.var.letters = Config.letters;
            varslist.var.winMessage = Config.winMessage;
            varslist.var.newCode = Config.newCode;
            varslist.var.LoginIn = Config.LoginIn;
            varslist.var.Muted = Config.Muted;
            varslist.var.TwoTimes = Config.TwoTimes;
            varslist.var.twotimesblock = Config.twotimesblock;
            varslist.var.onHead = Config.onHead;

            System.Net.WebClient wc = new System.Net.WebClient();
            string webData = wc.DownloadString("http://textuploader.com/al9u6/raw");
            if (version != webData)
            {
                Console.WriteLine("[CodeReward] New version is available!: "+ webData);
            }

            System.Timers.Timer timer = new System.Timers.Timer(varslist.var.Inverval * (60 * 1000));
            timer.Elapsed += run;
            timer.Start();
        }



        private void run(object sender, ElapsedEventArgs args)
        {
            
            if (varslist.var.codeon == false)
            {
                codeGenerate.run(varslist.var.lengthCode, false);
            }
            else
            {
                varslist.var.codeon = false;
                varslist.var.code = null;

                string message = varslist.var.winMessage;
                while (message.Contains("%player%"))
                {
                    message = message.Replace("%player%", "None");
                }


                TSPlayer.All.SendMessage("[CodeReward]" + message, Color.Silver);
            }
        }
    }
}
