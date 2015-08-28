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
    public static class chat
    {
        public static void onChat(ServerChatEventArgs e)
        {
            if (e.Handled == true)
            {
                return;
            }
            if (varslist.var.codeon == true)
            {
                String sendername = TShock.Players[e.Who].Name;
                TSPlayer sender = TShock.Players[e.Who];



                if (e.Text == varslist.var.code)
                {
                    if (sender.IsLoggedIn == false)
                    {
                        sender.SendMessage("[CodeReward]" + varslist.var.LoginIn, Color.Silver);
                        return;
                    }
                    if (sender.mute == true)
                    {
                        sender.SendMessage("[CodeReward]" + varslist.var.Muted, Color.Silver);
                        return;
                    }
                    if (varslist.var.lastp == sendername)
                    {
                        if (varslist.var.twotimesblock == true)
                        {
                            sender.SendMessage("[CodeReward]" + varslist.var.TwoTimes, Color.Silver);
                            return;
                        }
                    }

                    varslist.var.lastp = sendername;
                    varslist.var.code = null;
                    varslist.var.codeon = false;

                    foreach (int reward in varslist.var.RewardsBuffs)
                    {
                        sender.SetBuff(reward, varslist.var.BuffTime, true);
                    }
                    foreach (int reward in varslist.var.RewardsItems)
                    {
                        sender.GiveItem(reward, "", 0, 0, 1, 0);
                    }

                    string message = varslist.var.winMessage;
                    while (message.Contains("%player%"))
                    {
                        message = message.Replace("%player%", sendername);
                    }


                    NetMessage.SendData((int)PacketTypes.CreateCombatText, -1, -1, varslist.var.onHead, 0, sender.X, sender.Y, 0, 0, 0, 0);
                    TSPlayer.All.SendMessage("[CodeReward]" + message, Color.Silver);

 
                }



            }
            if (varslist.var.codeon2 == true)
            {
                String sendername = TShock.Players[e.Who].Name;
                TSPlayer sender = TShock.Players[e.Who];



                if (e.Text == varslist.var.code2)
                {
                    if (sender.IsLoggedIn == false)
                    {
                        sender.SendMessage("[CodeReward]" + varslist.var.LoginIn, Color.Silver);
                        return;
                    }
                    if (sender.mute == true)
                    {
                        sender.SendMessage("[CodeReward]" + varslist.var.Muted, Color.Silver);
                        return;
                    }
                    if (varslist.var.lastp == sendername)
                    {
                        if (varslist.var.twotimesblock == true)
                        {
                            sender.SendMessage("[CodeReward]" + varslist.var.TwoTimes, Color.Silver);
                            return;
                        }
                    }

                    varslist.var.lastp = sendername;
                    varslist.var.code2 = null;
                    varslist.var.codeon2 = false;

                    foreach (int reward in varslist.var.RewardsBuffs)
                    {
                        sender.SetBuff(reward, varslist.var.BuffTime, true);
                    }
                    foreach (int reward in varslist.var.RewardsItems)
                    {
                        sender.GiveItem(reward, "", 0, 0, 1, 0);
                    }


                    string message = varslist.var.winMessage;
                    while (message.Contains("%player%"))
                    {
                        message = message.Replace("%player%", sendername);
                    }
                    NetMessage.SendData((int)PacketTypes.CreateCombatText, -1, -1, varslist.var.onHead, 0, sender.X, sender.Y, 0, 0, 0, 0);
                   

                     
                    TSPlayer.All.SendMessage("[CodeReward]" + message, Color.Silver);

                }



            }
        }
    }
}
