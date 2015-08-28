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
    public static class command
    {
        public static Config Config;

        public static void functionCmd(CommandArgs e)
        {
            if (e.Parameters.Count > 0)
            {
                if (e.Parameters[0] == "help" || e.Parameters[0] == "reload" || e.Parameters[0] == "start")
                {
                    if (e.Parameters[0] == "help")
                    {
                        e.Player.SendMessage("*--====== Komendy ======--*", Color.Silver);
                        e.Player.SendMessage("/cr help - Show list of commands.", Color.Silver);
                        e.Player.SendMessage("/cr start <int> - generating new code.", Color.Silver);
                        e.Player.SendMessage("/cr reload - reloading plugin.", Color.Silver);
                        return;
                    }
                    if (e.Parameters[0] == "start")
                    {
                        if (e.Player.Group.HasPermission(permission.coderewardstart))
                        {
                            int length = varslist.var.lengthCode;
                            int cos = varslist.var.lengthCode;
                            bool isNumerical = false;
                            if (e.Parameters.Count > 1)
                            {
                                
                                isNumerical = int.TryParse(e.Parameters[1], out cos);
                            }
                            if (isNumerical == true)
                            {
                                length = cos;
                            }


                            if (varslist.var.codeon2 == false)
                            {
                                codeGenerate.run(length, true);
                                return;
                            }
                            else
                            {
                                e.Player.SendMessage("[CodeReward] Code is already generated.", Color.Silver);
                                return;
                            }
                        }
                        else
                        {
                            e.Player.SendMessage("[CodeReward] You don't have permission.", Color.Silver);
                            return;
                        }
                    }

                    if (e.Parameters[0] == "reload")
                    {
                        if (e.Player.Group.HasPermission(permission.coderewardreload))
                        {
                            string path = Path.Combine(TShock.SavePath, "CodeReward.json");
                            Config = Config.Read(path);
                            if (!File.Exists(path))
                            {
                                Config.Write(path);
                            }
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

                            e.Player.SendMessage("[CodeReward] Successfully reloaded.", Color.Silver);
                            return;
                        }
                        else
                        {
                            e.Player.SendMessage("[CodeReward] You don't have permission.", Color.Silver);
                            return;
                        }
                    }
                }
                else
                {
                    e.Player.SendMessage("[CodeReward] Use /cr help", Color.Silver);
                    return;
                }
            }
            else
            {
                e.Player.SendMessage("[CodeReward] Author: Teddy, use /cr help", Color.Silver);
                return;
            }
        }
    }
}
