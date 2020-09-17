using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using TTE_GAME.Classes;
using TTE_GAME.ExtraFunction;
using TTE_GAME.System;

namespace TTE_GAME.Actions
{
    class Battle
    {
        public void FindEnemy(Variables data)
        {
            MysqlQuerry mysqlQuerry = new MysqlQuerry();
            MessageSend MesSend = new System.MessageSend();
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
                                label = "Атаковать",
                                payload = "{\"button\": \"1011\"}"
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
                                label = "Поиск другого",
                                payload = "{\"button\": \"1006\"}"
                                },
                                color = "primary"
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
                                payload = "{\"button\": \"1014\"}"
                                },
                                color = "secondary"
                       }

                   }
            }

            };
            string json = JsonConvert.SerializeObject(Keyboard_obj, Formatting.Indented);
            List<string> res = new List<string>();
            string lvl = mysqlQuerry.Execute_Select_One("lvl", "vkid", data.IdPols.ToString(), "users");
            res = mysqlQuerry.Execute_Select_Multi_Battle(new string[] { "vkid", "vkname", "vksurname", "hero", "hero_strength", "hero_agility", "hero_intelligence", "lvl" }, lvl, data.IdPols.ToString(), "users");
            string msg = "Нашли тебе оппонента: \n\n 💬Имя: @id" + res[0] + " (" + res[1] + " " + res[2] + ") \n" + "🤠Герой: " + res[3] + "\n 🏋Сила героя: " + res[4] + "\n 🤺Ловкость героя: " + res[5] + "\n ‍🎓Интеллект героя: " + res[6] + "\n 👑Уровень: " + res[7];
            MesSend.Send(data, msg, "", json);
        }

    }
}
