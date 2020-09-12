using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using TTE_GAME.Classes;
using TTE_GAME.ExtraFunction;
using TTE_GAME.System;

namespace TTE_GAME.Actions.Shop_Worker
{
    class Get_Summ
    {
        public void SendOrder(Variables data)
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
                            label = "Назад",
                            payload = "{\"button\": \"1005\"}"
                        },
                        color = "primary"
                    }

                    }
               

                }

            };

            string json = JsonConvert.SerializeObject(Keyboard_obj, Formatting.Indented);
            MysqlQuerry mysqlQuerry = new MysqlQuerry();
             if (mysqlQuerry.Execute_Select_One("id", "vkid", data.IdPols.ToString(), "shop_worker") == "error")
             {
                Send_Cart send_Cart = new Send_Cart();
                send_Cart.SendOrder(data, false);
             }    
            List<string> res = new List<string>();
            res = mysqlQuerry.Execute_Select_Multi(new string[] { "pivo", "vodka", "chipsi" }, "vkid", data.IdPols.ToString(), "shop_worker");

            string msg = "В корзине у клиента: " + "\n" + "🍺" + res[0] + " банка(-ок) пива (100 за шт)" + "\n" + "🍸" + res[1] + " бутылка(-ок/-ки) водки (200 за шт)" + "\n" + "🍟" + res[2] + " пачек чипсов (30 за шт)";
           

            MesSend.Send(data, msg + "\n" + "Ваша сумма покупки составила: ", "", json);
        }
    }
}
