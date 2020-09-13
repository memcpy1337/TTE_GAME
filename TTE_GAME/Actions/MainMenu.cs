using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using TTE_GAME.Classes;
using TTE_GAME.ExtraFunction;
using TTE_GAME.System;

namespace TTE_GAME.Actions
{
    class MainMenu
    {
        
        public void Show(Variables data)
        {
            //string[] rows = { "vkid", "vkname" };
            //string[] data_user = { data.IdPols.ToString(), data.IdPols.ToString() };
            //MysqlQuerry mysqlQuerry = new MysqlQuerry();
            //mysqlQuerry.Execute_Insert(rows, data_user, "users", true);

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
                                label = "Игра «‎Жизнь»‎",
                                payload = "{\"button\": \"1005\"}"
                                },
                                color = "primary"
                       }

                   },
                   new List<buttons>()
                   {
                       new buttons()
                       {

                                action = new action() //найти рандомного врага твоего уровня
                                {
                                type = "text",
                                label = "Бойцовский клуб",
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
                                label = "Ветка развития",
                                payload = "{\"button\": \"1010\"}"
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
                                label = "Магазин",
                                payload = "{\"button\": \"1011\"}"
                                },
                                color = "secondary"
                       }

                    },
                    new List<buttons>()
                    {
                        new buttons()
                        {
                        action = new action()
                                {
                                type = "text",
                                label = "Помощь",
                                payload = "{\"button\": \"1007\"}"
                                },
                                color = "positive"
                        },
                        new buttons()
                        {
                        action = new action()
                                {
                                type = "text",
                                label = "ТОП игроков",
                                payload = "{\"button\": \"1008\"}"
                                },
                                color = "positive"
                        },
                        new buttons()
                        {
                        action = new action()
                                {
                                type = "text",
                                label = "Статистика",
                                payload = "{\"button\": \"1009\"}"
                                },
                                color = "positive"
                        }

                    }
                }
            };
            string json = JsonConvert.SerializeObject(Keyboard_obj, Formatting.Indented);
            List<string> res = new List<string>();
            res = mysqlQuerry.Execute_Select_Multi(new string[] { "vkid", "vkname", "vksurname", "hero", "money", "join_time", "lvl", "winning_duels" }, "vkid", data.IdPols.ToString(), "users");
            string character_name = "";
            //ТУТ МЫ УЖЕ РЕГИСТРИРУЕМ ЧЕЛА, ВНОСИМ ЕГО АЙДИ ВК И Т.Д. ДАЛЕЕ ПОЛУЧАЕМ КНОПКУ (ВЫБРАННОГО ПЕРСА) В СЛЕД СООБЩЕНИИ, И ДЕЛАЕМ ДЕЙСТВИЯ ДАЛЬНЕЙШИЕ.
            switch (res[3])
            {
                case "1":
                    character_name = "Take The Elevator";
                    break;
                case "2":
                    character_name = "Richi King";
                    break;
            }

            MesSend.Send(data, "💬Номер: " + res[0] + "\n" + "👤Имя: " + res[1] + " " + res[2] + "\n" + "🚶‍♂Твой персонаж: " + character_name + "\n" + "💶Деньги: " + res[4] + "\n" + "📆Дата регистрации: " + res[5] + "\n" + "👑Уровень: " + res[6] + "\n" + "🏆Выиграно дуэлей: " + res[7] + "\n", "", json);
           
        }
    }
}

