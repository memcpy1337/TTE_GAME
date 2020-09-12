using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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

                                action = new action()
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


            //ТУТ МЫ УЖЕ РЕГИСТРИРУЕМ ЧЕЛА, ВНОСИМ ЕГО АЙДИ ВК И Т.Д. ДАЛЕЕ ПОЛУЧАЕМ КНОПКУ (ВЫБРАННОГО ПЕРСА) В СЛЕД СООБЩЕНИИ, И ДЕЛАЕМ ДЕЙСТВИЯ ДАЛЬНЕЙШИЕ.


            MesSend.Send(data, "{BD}", "", json);

        }
    }
}

