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
                        if (varslist.var.lastp == sendername)
                        {
                            sender.SendMessage("[CodeReward] Ostatnio Ty byles pierwszy, daj szanse innym.", Color.Silver);
                            return;
                        }
                        if (sender.mute == true)
                        {
                            sender.SendMessage("[CodeReward] Jestes zmutowany, nie mozesz wpisywac kodu.", Color.Silver);
                            return;
                        }
                        if (sender.IsLoggedIn == false)
                        {
                            sender.SendMessage("[CodeReward] Musisz byc zalogowany aby moc pisac kod.", Color.Silver);
                            return;
                        }
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


                        TSPlayer.All.SendMessage("[CodeReward] Zwyciezca: " + sendername, Color.Silver);

                    }
                


            }
            if (varslist.var.codeon2 == true)
            {
                String sendername = TShock.Players[e.Who].Name;
                TSPlayer sender = TShock.Players[e.Who];



                if (e.Text == varslist.var.code2)
                {
                    if (varslist.var.lastp == sendername)
                    {
                        sender.SendMessage("[CodeReward] Ostatnio Ty byles pierwszy, daj szanse innym.", Color.Silver);
                        return;
                    }
                    if (sender.mute == true)
                    {
                        sender.SendMessage("[CodeReward] Jestes zmutowany, nie mozesz wpisywac kodu.", Color.Silver);
                        return;
                    }
                    if (sender.IsLoggedIn == false)
                    {
                        sender.SendMessage("[CodeReward] Musisz byc zalogowany aby moc pisac kod.", Color.Silver);
                        return;
                    }
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


                    TSPlayer.All.SendMessage("[CodeReward] Zwyciezca: " + sendername, Color.Silver);

                }



            }
        }
    }
}
