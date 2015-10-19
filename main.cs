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
        public override Version Version { get { return new Version("1.9"); } }
        public override string Name { get { return "CodeReward"; } }
        public override string Author { get { return "Teddy"; } }
        public override string Description { get { return "CodeReward"; } }

        public override void Initialize()
        {
            string path = Path.Combine(TShock.SavePath, "CodeReward1_9.json");
            Config = Config.Read(path);
            if (!File.Exists(path))
            {
                Config.Write(path);
            }
            Commands.ChatCommands.Add(new Command(Permissions.codereward, Cmds.functionCmd, "codereward"));
            Commands.ChatCommands.Add(new Command(Permissions.codereward, Cmds.functionCmd, "crt"));
            Variables.ALL = Config.ALL;



            //Events
            ServerApi.Hooks.ServerChat.Register(this, Chat.onChat);

            string version = "1.3.0.8 (1.9)";
            System.Net.WebClient wc = new System.Net.WebClient();
            string webData = wc.DownloadString("http://textuploader.com/al9u6/raw");
            if (version != webData)
            {
                Console.WriteLine("[CodeReward] New version is available!: " + webData);
            }


            System.Timers.Timer timer = new System.Timers.Timer(Variables.ALL.Interval * (60 * 1000));
            timer.Elapsed += run;
            timer.Start();
        }
        private void run(object sender, ElapsedEventArgs args)
        {
            if (Variables.codeon == false)
            {
                codeGenerate.run(Variables.ALL.lengthCode, false);
            }
            else
            {
                Variables.codeon = false;
                Variables.code = null;

                string message = Variables.ALL.winMessage;
                while (message.Contains("%player%"))
                {
                    message = message.Replace("%player%", "None");
                }

                TSPlayer.All.SendMessage("[CodeReward]" + message, Color.Silver);
            }
        }

    }
}