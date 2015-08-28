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
                if (e.Parameters[0] == "pomoc" || e.Parameters[0] == "reload" || e.Parameters[0] == "start")
                {
                    if (e.Parameters[0] == "pomoc")
                    {
                        e.Player.SendMessage("*--====== Komendy ======--*", Color.Silver);
                        e.Player.SendMessage("/cr pomoc - pokazuje liste komend.", Color.Silver);
                        e.Player.SendMessage("/cr start <dlugosc> - generuje nowy kod.", Color.Silver);
                        e.Player.SendMessage("/cr reload - przeladowuje plugin", Color.Silver);
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
                                e.Player.SendMessage("[CodeReward] Kod jest juz wygenerowany.", Color.Silver);
                                return;
                            }
                        }
                        else
                        {
                            e.Player.SendMessage("[CodeReward] Nie masz uprawnien do tej komendy.", Color.Silver);
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

                            e.Player.SendMessage("[CodeReward] Pomyslnie przeladowano konfiguracje.", Color.Silver);
                            return;
                        }
                        else
                        {
                            e.Player.SendMessage("[CodeReward] Nie masz uprawnien do tej komendy.", Color.Silver);
                            return;
                        }
                    }
                }
                else
                {
                    e.Player.SendMessage("[CodeReward] Uzyj /cr pomoc", Color.Silver);
                    return;
                }
            }
            else
            {
                e.Player.SendMessage("[CodeReward] Autor: Teddy, uzyj /cr pomoc", Color.Silver);
                return;
            }
        }
    }
}
