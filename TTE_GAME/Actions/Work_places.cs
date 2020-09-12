using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using TTE_GAME.Classes;
using TTE_GAME.System;

namespace TTE_GAME.Actions
{
    class Work_places
    {
        public void Show_work(Variables data)
        {
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
                                label = "Кассир",
                                payload = "{\"button\": \"1012\"}"
                                },
                                color = "primary"
                       },
                        new buttons()
                       {

                                action = new action()
                                {
                                type = "text",
                                label = "Гайкокрут",
                                payload = "{\"button\": \"1013\"}"
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


            //ТУТ МЫ УЖЕ РЕГИСТРИРУЕМ ЧЕЛА, ВНОСИМ ЕГО АЙДИ ВК И Т.Д. ДАЛЕЕ ПОЛУЧАЕМ КНОПКУ (ВЫБРАННОГО ПЕРСА) В СЛЕД СООБЩЕНИИ, И ДЕЛАЕМ ДЕЙСТВИЯ ДАЛЬНЕЙШИЕ.


            MesSend.Send(data, "Выбери работу себе по душе", "", json);
        }

    }
}
