using System;
using System.Collections.Generic;
using System.Text;
using TTE_GAME.Classes;
using TTE_GAME.ExtraFunction;
using TTE_GAME.System;

namespace TTE_GAME.Actions.Shop_Worker
{
    class Check_Answer
    {
        public bool CheckAnsw(Variables data)
        {
            MysqlQuerry mySqlQuerry = new MysqlQuerry();
            MessageSend messageSend = new MessageSend();
            Send_Cart send_Cart = new Send_Cart();
            List<string> res = new List<string>();
            res = mySqlQuerry.Execute_Select_Multi(new string[] { "pivo", "vodka", "chipsi" }, "vkid", data.IdPols.ToString(), "shop_worker");

            int summ = (Convert.ToInt32(res[0]) * 100) + (Convert.ToInt32(res[1]) * 200) + (Convert.ToInt32(res[2]) * 30);

            if (summ == Convert.ToInt32(data.Title_Lower))
            {
                Random random = new Random();
                int money = random.Next(5, 10);

                mySqlQuerry.Execute_Delete_One("vkid", data.IdPols.ToString(), "shop_worker");
                mySqlQuerry.Execute_Increase_By_Where(new string[] { "money" }, new string[] { money.ToString() }, "users", true, true, "vkid", data.IdPols.ToString());
                messageSend.Send(data, "Верно. Ты заработал: 💶" + money.ToString() + " рублей" + "\n", "");


               
                send_Cart.SendOrder(data, true);

                return true;
            }
            mySqlQuerry.Execute_Delete_One("vkid", data.IdPols.ToString(), "shop_worker");
            messageSend.Send(data, "НЕ верно", "");
            
            send_Cart.SendOrder(data, true);
            return false;
        }

    }
}
