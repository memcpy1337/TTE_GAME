using System;
using System.Collections.Generic;
using System.Text;
using TTE_GAME.Actions;
using TTE_GAME.Actions.Characters_Info;
using TTE_GAME.Actions.Shop;
using TTE_GAME.Actions.Shop_Worker;
using TTE_GAME.Classes;
using TTE_GAME.System;

namespace TTE_GAME.ExtraFunction
{
    class Command_Router
    {
        public void Router_Buttons(Variables data)
        {
            MysqlQuerry mysqlQuerry = new MysqlQuerry();
            switch (data.IdButton)
            {
                
                case 1000:
                    TTE_info tTE_Info = new TTE_info();
                    tTE_Info.SendInfo(data);
                    mysqlQuerry.Execute_Update_Where(new string[] { "last_keyboard" }, new string[] { "tte_info_keyboard" }, "users", true, true, "vkid", data.IdPols.ToString());
                    return;
                case 1001:
                    RK_info rK_Info = new RK_info();
                    rK_Info.SendInfo(data);
                    mysqlQuerry.Execute_Update_Where(new string[] { "last_keyboard" }, new string[] { "richo_info_keyboard" }, "users", true, true, "vkid", data.IdPols.ToString());
                    return;
                case 1002:
                    TTE_info tTE_Info1 = new TTE_info();
                    tTE_Info1.Choose(data);
                    mysqlQuerry.Execute_Update_Where(new string[] { "last_keyboard" }, new string[] { "choose_tte_keyboard" }, "users", true, true, "vkid", data.IdPols.ToString());
                    return;
                case 1003:
                    RegNewAcc regNewAcc = new RegNewAcc();
                    regNewAcc.RegNewAccount(data);
                    mysqlQuerry.Execute_Update_Where(new string[] { "last_keyboard" }, new string[] { "back_to_info_keyboard" }, "users", true, true, "vkid", data.IdPols.ToString());
                    return;
                case 1004:
                    RK_info rK_Info1 = new RK_info();
                    rK_Info1.Choose(data);
                    mysqlQuerry.Execute_Update_Where(new string[] { "last_keyboard" }, new string[] { "choose_richi_keyboard" }, "users", true, true, "vkid", data.IdPols.ToString());
                    return;
                case 1014:
                    MainMenu mainMenu = new MainMenu();
                    mainMenu.Show(data);
                    mysqlQuerry.Execute_Update_Where(new string[] { "last_keyboard" }, new string[] { "main_menu_keyboard" }, "users", true, true, "vkid", data.IdPols.ToString());
                    return;
                case 1005:
                    Work_places work_Places = new Work_places();
                    work_Places.Show_work(data);
                    mysqlQuerry.Execute_Update_Where(new string[] { "last_keyboard" }, new string[] { "show_work_places_keyboard" }, "users", true, true, "vkid", data.IdPols.ToString());
                    return;
                case 1012:
                    Send_Cart send_Cart = new Send_Cart();
                    send_Cart.SendOrder(data, false);
                    mysqlQuerry.Execute_Update_Where(new string[] { "last_keyboard" }, new string[] { "send_order_keyboard" }, "users", true, true, "vkid", data.IdPols.ToString());
                    return;
                case 1015:
                    Get_Summ get_Summ = new Get_Summ();
                    get_Summ.SendOrder(data);
                    mysqlQuerry.Execute_Update_Where(new string[] { "last_keyboard" }, new string[] { "order_keyboard" }, "users", true, true, "vkid", data.IdPols.ToString());
                    return;
                case 1011:
                    Shop_Mag shop = new Shop_Mag();
                    shop.Show_Shop(data);
                    mysqlQuerry.Execute_Update_Where(new string[] { "last_keyboard" }, new string[] { "shop_keyboard" }, "users", true, true, "vkid", data.IdPols.ToString());
                    return;
                case 1017:
                    Ability_Shop ability_Shop = new Ability_Shop();
                    ability_Shop.ShowShop(data);
                    mysqlQuerry.Execute_Update_Where(new string[] { "last_keyboard" }, new string[] { "ability_shop_keyboard" }, "users", true, true, "vkid", data.IdPols.ToString());
                    return;
                case 1006:
                    Battle battle = new Battle();
                    battle.FindEnemy(data);
                    mysqlQuerry.Execute_Update_Where(new string[] { "last_keyboard" }, new string[] { "battle_search_keyboard" }, "users", true, true, "vkid", data.IdPols.ToString());
                    return;

            }
        }

    }
}
