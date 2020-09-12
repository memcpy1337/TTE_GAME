using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using TTE_GAME.Classes;
using TTE_GAME.ExtraFunction;
using TTE_GAME.System;

namespace TTE_GAME.Actions.Shop_Worker
{
    class Send_Cart
    {
        public void SendOrder(Variables data, bool seen)
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
                            type = "callback",
                            label = "Свободная касса!",
                            payload = "{\"button\": \"1015\"}"
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
                            payload = "{\"button\": \"1005\"}"
                        },
                        color = "primary"
                    }

                },
                
            }

            };
            string json = JsonConvert.SerializeObject(Keyboard_obj, Formatting.Indented);
            MysqlQuerry mysqlQuerry = new MysqlQuerry();
            if (mysqlQuerry.Execute_Select_One("id", "vkid", data.IdPols.ToString(), "shop_worker") == "error")
            {
                Random random = new Random();
                int pivo = random.Next(1, 15);
                int vodka = random.Next(0, 3);
                int chipsi = random.Next(1, 5);
                mysqlQuerry.Execute_Insert(new string[] { "vkid", "pivo", "vodka", "chipsi" }, new string[] { data.IdPols.ToString(), pivo.ToString(), vodka.ToString(), chipsi.ToString() }, "shop_worker", true);
                
                //generate cart

            }

            if (seen == true)
            {
                MesSend.Send(data, "Нажми «Свободная касса» чтобы подозвать клиента", "", json);
            }
            else
            {
                MesSend.Send(data, "Ты устроился на работу кассиром.\n Нажми «Свободная касса» чтобы подозвать клиента", "", json);
            }





        }
    }
}
