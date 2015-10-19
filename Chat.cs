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
    public static class Chat
    {
        public static void onChat(ServerChatEventArgs e)
        {
            if (e.Handled == true)
            {
                return;
            }
            {
                String sendername = TShock.Players[e.Who].Name;
                TSPlayer sender = TShock.Players[e.Who];



                if (e.Text == Variables.code)
                {
                    if (sender.IsLoggedIn == false)
                    {
                        sender.SendMessage("[CodeReward] " + Variables.ALL.LoginIn, Color.Silver);
                        return;
                    }
                    if (sender.mute == true)
                    {
                        sender.SendMessage("[CodeReward] " + Variables.ALL.Muted, Color.Silver);
                        return;
                    }
                    if (Variables.lastp == sendername)
                    {
                        if (Variables.ALL.twotimesblock == true)
                        {
                            sender.SendMessage("[CodeReward] " + Variables.ALL.TwoTimes, Color.Silver);
                            return;
                        }
                    }

                    Variables.lastp = sendername;
                    Variables.code = null;
                    Variables.codeon = false;

                    bool stop = true;
                    int i = 0;
                    while (stop == true)
                    {
                        i++;
                        List<string> keys = new List<string>(Variables.ALL.Packages.Keys);
                        Random rand = new Random();
                        string randomKey = keys[rand.Next(Variables.ALL.Packages.Count)];

                        foreach (var reward in Variables.ALL.Packages[randomKey].ItemsOptions)
                        {
                            sender.GiveItem(reward.ID, "", 0, 0, reward.Amount, reward.Prefix);
                        }
                        foreach (var reward in Variables.ALL.Packages[randomKey].BuffOptions)
                        {
                            sender.SetBuff(reward.ID, reward.Time, true);
                        }
                        if (Variables.ALL.Packages[randomKey].NextOneAfterThis == false)
                        {
                            stop = false;
                        }
                        else
                        {
                            if (i > Variables.ALL.Packages.Count)
                            {
                                stop = false;
                            }
                        }
                    }

                    string message = Variables.ALL.winMessage;
                    while (message.Contains("%player%"))
                    {
                        message = message.Replace("%player%", sendername);
                    }


                    NetMessage.SendData((int)PacketTypes.CreateCombatText, -1, -1, Variables.ALL.onHead, 0, sender.X, sender.Y, 0, 0, 0, 0);
                    TSPlayer.All.SendMessage("[CodeReward] " + message, Color.Silver);


                }



            }
            if (Variables.codeon2 == true)
            {
                String sendername = TShock.Players[e.Who].Name;
                TSPlayer sender = TShock.Players[e.Who];



                if (e.Text == Variables.code2)
                {
                    if (sender.IsLoggedIn == false)
                    {
                        sender.SendMessage("[CodeReward] " + Variables.ALL.LoginIn, Color.Silver);
                        return;
                    }
                    if (sender.mute == true)
                    {
                        sender.SendMessage("[CodeReward] " + Variables.ALL.Muted, Color.Silver);
                        return;
                    }
                    if (Variables.lastp == sendername)
                    {
                        if (Variables.ALL.twotimesblock == true)
                        {
                            sender.SendMessage("[CodeReward] " + Variables.ALL.TwoTimes, Color.Silver);
                            return;
                        }
                    }

                    Variables.lastp = sendername;
                    Variables.code2 = null;
                    Variables.codeon2 = false;

                    bool stop = true;
                    int i = 0;
                    while (stop == true)
                    {
                        i++;
                        List<string> keys = new List<string>(Variables.ALL.Packages.Keys);
                        Random rand = new Random();
                        string randomKey = keys[rand.Next(Variables.ALL.Packages.Count)];

                        foreach (var reward in Variables.ALL.Packages[randomKey].ItemsOptions)
                        {
                            sender.GiveItem(reward.ID, "", 0, 0, reward.Amount, reward.Prefix);
                        }
                        foreach (var reward in Variables.ALL.Packages[randomKey].BuffOptions)
                        {
                            sender.SetBuff(reward.ID, reward.Time, true);
                        }
                        if (Variables.ALL.Packages[randomKey].NextOneAfterThis == false)
                        {
                            stop = false;
                        }
                        else
                        {
                            if (i > Variables.ALL.Packages.Count)
                            {
                                stop = false;
                            }
                        }
                    }


                    string message = Variables.ALL.winMessage;
                    while (message.Contains("%player%"))
                    {
                        message = message.Replace("%player%", sendername);
                    }
                    NetMessage.SendData((int)PacketTypes.CreateCombatText, -1, -1, Variables.ALL.onHead, 0, sender.X, sender.Y, 0, 0, 0, 0);
                    TSPlayer.All.SendMessage("[CodeReward]" + message, Color.Silver);

                }



            }
        }
    }
}