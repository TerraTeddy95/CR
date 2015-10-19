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
    public static class Cmds
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
                        e.Player.SendMessage("*--====== Commands ======--*", Color.Silver);
                        e.Player.SendMessage("/crt help - Show list of commands.", Color.Silver);
                        e.Player.SendMessage("/crt start <int> - generating new code.", Color.Silver);
                        e.Player.SendMessage("/crt reload - reloading plugin.", Color.Silver);
                        return;
                    }
                    if (e.Parameters[0] == "start")
                    {
                        if (e.Player.Group.HasPermission(Permissions.coderewardstart))
                        {
                            int length = Variables.ALL.lengthCode;
                            int cos = Variables.ALL.lengthCode;
                            bool isNumerical = false;
                            if (e.Parameters.Count > 1)
                            {

                                isNumerical = int.TryParse(e.Parameters[1], out cos);
                            }
                            if (isNumerical == true)
                            {
                                length = cos;
                            }


                            if (Variables.codeon2 == false)
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
                        if (e.Player.Group.HasPermission(Permissions.coderewardreload))
                        {
                            string path = Path.Combine(TShock.SavePath, "CodeReward1_9.json");
                            Config = Config.Read(path);
                            if (!File.Exists(path))
                            {
                                Config.Write(path);
                            }
                            Variables.ALL = Config.ALL;
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
                    e.Player.SendMessage("[CodeReward] Use /crt help", Color.Silver);
                    return;
                }
            }
            else
            {
                e.Player.SendMessage("[CodeReward] Author: Teddy, use /crt help", Color.Silver);
                return;
            }
        }
    }
}