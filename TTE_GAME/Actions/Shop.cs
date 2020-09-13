using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using TTE_GAME.Classes;
using TTE_GAME.ExtraFunction;
using TTE_GAME.System;

namespace TTE_GAME.Actions
{
    class Shop_Mag
    {
        public void Show_Shop(Variables data)
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
                                label = "Изучить способности",
                                payload = "{\"button\": \"1017\"}"
                                },
                                color = "positive"
                       }

                   },
                   new List<buttons>()
                   {
                       new buttons()
                       {

                                action = new action() //найти рандомного врага твоего уровня
                                {
                                type = "text",
                                label = "Улучшить характеристики",
                                payload = "{\"button\": \"1018\"}"
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
                                payload = "{\"button\": \"1014\"}"
                                },
                                color = "secondary"
                       }

                   }
            }

            };
            string json = JsonConvert.SerializeObject(Keyboard_obj, Formatting.Indented);
            MesSend.Send(data, "🏪Тут можно купить способности или характеристики для персонажа", "", json);

        }

    }
}
