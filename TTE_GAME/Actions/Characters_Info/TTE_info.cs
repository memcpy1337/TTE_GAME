using MySql.Data.Types;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using TTE_GAME.Classes;
using TTE_GAME.ExtraFunction;
using TTE_GAME.System;

namespace TTE_GAME.Actions.Characters_Info
{
    class TTE_info
    {
        public void SendInfo(Variables data)
        {
            MysqlQuerry mysqlQuerry = new MysqlQuerry();
            List<string> info = mysqlQuerry.Execute_Select_Multi(new string[] { "description", "agility", "intelligence", "strength" }, "id", "1", "characters");
            if (!(info.Contains("error")))
            {
                string msg = "🤺Ловкость: " + info[1] + "\n" + "🏋‍Сила: " + info[3] + "\n" + "👨‍🎓Интеллект: " + info[2] + "\n" + "📕Биография:\n" + info[0];


                MessageSend MesSend = new MessageSend();
                var Keyboard_obj = new Keyboard()
                {
                    one_time = false,
                    buttons = new List<List<buttons>>()
                {
                   new List<buttons>()
                   {
                       new buttons()
                       {

                                action = new action()
                                {
                                type = "text",
                                label = "Выбрать",
                                payload = "{\"button\": \"1002\"}"
                                },
                                color = "positive"
                       }

                    },

                    new List<buttons>()
                    {
                        new buttons()
                        {
                        action = new action()
                                {
                                type = "text",
                                label = "Назад",
                                payload = "{\"button\": \"1003\"}"
                                },
                                color = "secondary"
                        }
                    }
                }
                };
                string json = JsonConvert.SerializeObject(Keyboard_obj, Formatting.Indented);


               


                MesSend.Send(data, msg, "", json);

            }


        }

        public void Choose(Variables data)
        {
            MysqlQuerry mysqlQuerry = new MysqlQuerry();
            List<string> info = mysqlQuerry.Execute_Select_Multi(new string[] { "agility", "intelligence", "strength" }, "id", "1", "characters");
            string[] rows = { "hero", "hero_strength", "hero_agility", "hero_intelligence" };
            string[] hero_pick = { "1", info[2], info[0], info[1] };
            
            if (mysqlQuerry.Execute_Select_One("hero", "vkid", data.IdPols.ToString(), "users") == "error")
            {
                mysqlQuerry.Execute_Update_Where(rows, hero_pick, "users", true, true, "vkid", data.IdPols.ToString());

                MainMenu mainMenu = new MainMenu();
                mainMenu.Show(data);
            }else
            {
                MessageSend messageSend = new MessageSend();
                messageSend.Send(data, "Ты уже выбрал героя до этого", "");
                MainMenu mainMenu1 = new MainMenu();
                mainMenu1.Show(data);
            }
        }
    }
}
