using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using TTE_GAME.Classes;
using TTE_GAME.ExtraFunction;

namespace TTE_GAME.System
{
    public class RegNewAcc
    {
        public void RegNewAccount(Variables data)
        {
            string[] rows = { "vkid", "vkname" };
            string[] data_user = { data.IdPols.ToString(), data.IdPols.ToString() };
            MysqlQuerry mysqlQuerry = new MysqlQuerry();
            mysqlQuerry.Execute_Insert(rows, data_user, "users", true);


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
                                label = "🍺Take The Elevator🍺",
                                payload = "{\"button\": \"1000\"}"
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
                                label = "♿Richi King♿",
                                payload = "{\"button\": \"1001\"}"
                                },
                                color = "secondary"
                        }
                    }
                }
            };
            string json = JsonConvert.SerializeObject(Keyboard_obj, Formatting.Indented);


            //ТУТ МЫ УЖЕ РЕГИСТРИРУЕМ ЧЕЛА, ВНОСИМ ЕГО АЙДИ ВК И Т.Д. ДАЛЕЕ ПОЛУЧАЕМ КНОПКУ (ВЫБРАННОГО ПЕРСА) В СЛЕД СООБЩЕНИИ, И ДЕЛАЕМ ДЕЙСТВИЯ ДАЛЬНЕЙШИЕ.


            MesSend.Send(data, "Ты не был до этого тут, так что выбери своего бойца! Он будет с тобой до конца.", "", json);

        }
    }
}
