using System;
using System.Collections.Generic;
using System.Text;
using TTE_GAME.Actions;
using TTE_GAME.Actions.Characters_Info;
using TTE_GAME.Classes;
using TTE_GAME.System;

namespace TTE_GAME.ExtraFunction
{
    class Command_Router
    {
        public void Router_Buttons(Variables data)
        {
            switch (data.IdButton)
            {
                case 1000:
                    TTE_info tTE_Info = new TTE_info();
                    tTE_Info.SendInfo(data);
                    return;
                case 1001:
                    RK_info rK_Info = new RK_info();
                    rK_Info.SendInfo(data);
                    return;
                case 1002:
                    TTE_info tTE_Info1 = new TTE_info();
                    tTE_Info1.Choose(data);
                    return;
                case 1003:
                    RegNewAcc regNewAcc = new RegNewAcc();
                    regNewAcc.RegNewAccount(data);
                    return;
                case 1004:
                    RK_info rK_Info1 = new RK_info();
                    rK_Info1.Choose(data);
                    return;
                case 1014:
                    MainMenu mainMenu = new MainMenu();
                    mainMenu.Show(data);
                    return;
                case 1005:
                    Work_places work_Places = new Work_places();
                    work_Places.Show_work(data);
                    return;


            }
        }

    }
}
