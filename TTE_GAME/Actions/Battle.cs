using MySqlX.XDevAPI.CRUD;
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
            string msg = "Твой оппонент: \n Имя: ";

        }

    }
}
