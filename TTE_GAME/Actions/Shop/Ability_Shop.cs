using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using TTE_GAME.Classes;
using TTE_GAME.ExtraFunction;
using TTE_GAME.System;

namespace TTE_GAME.Actions.Shop
{
    class Ability_Shop
    {
        public void ShowShop(Variables data)
        {
            MysqlQuerry mysqlQuerry = new MysqlQuerry();
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
                                label = "Назад",
                                payload = "{\"button\": \"1011\"}"
                                },
                                color = "secondary"
                       }

                   }
            }

            };
            string json = JsonConvert.SerializeObject(Keyboard_obj, Formatting.Indented);
            string hero = mysqlQuerry.Execute_Select_One("hero", "vkid", data.IdPols.ToString(), "users");
            List<string> res = new List<string>();
            res = mysqlQuerry.Execute_Select_Multi(new string[] { "name", "description", "damage_min", "damage_max", "hero", "chance", "cost" }, "hero", hero, "ability");
            string msg = "";
            int counter = 1;
           //ЧИСЛО ПОЛЕЙ ОДНОЙ СПОСОБНОСТИ
            for (int i = 0; i < res.Count; i += 7)
            {
                msg += counter + ") " + res[i] + ". \n" + "📖Описание: " + res[i+1] + ". \n" + "🔫Урон (от-до): " + res[i+2] + "-" + res[i+3] + ". \n" + "🎲Шанс в бою: " + res[i+5] + "%. \n" + "💶Цена: " + res[i+6] + "\n\n";
                counter++;
            }

            MesSend.Send(data, "🧬Введи номер способности, которую хочешь изучить. \n Твоему персонажу доступны следующие: \n\n" + msg, "", json);


        }

    }
}
