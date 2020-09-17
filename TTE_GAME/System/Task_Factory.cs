
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using TTE_GAME.Actions.Shop_Worker;
using TTE_GAME.Classes;
using TTE_GAME.ExtraFunction;

namespace TTE_GAME.System
{
    public class Text_Formatting

    {
        public void SettText(Variables data)
        {
            
            data.Title_Lower = data.Title.ToLower();
            data.Razdeli = data.Title.Split(' ');
            data.RazdeliLower = data.Title.ToLower().Split(' ');


        }
    }
   public class Task_Factory
   {
        public void Processing_Command(string title, int idPols, int IdPolsBes, int IdMes, int Time, int IdButton)
        {
            Variables data = new Variables();
            data.Title = title;
            data.IdMes = IdMes;
            data.Time = Time;
            data.IdButton = IdButton;
            data.IdPols = idPols;
            data.IdPolsBes = IdPolsBes;
            Text_Formatting text_Formatting = new Text_Formatting();
            text_Formatting.SettText(data);


            MysqlQuerry mysqlQuerry = new MysqlQuerry();
            
            if (mysqlQuerry.Execute_Select_One("id", "vkid", data.IdPols.ToString(), "users") == "error") //проверям регистрацию
            {
                Console.WriteLine("Не Зареган");
                RegNewAcc regNewAcc = new RegNewAcc();
                regNewAcc.RegNewAccount(data);
                return;
               
            }
            if ((mysqlQuerry.Execute_Select_One("vkid", "last_keyboard", "order_keyboard", "users") != "error") && (Extension.IsNumeric(data.Title_Lower)))
            {
                Check_Answer check_Answer = new Check_Answer();
                check_Answer.CheckAnsw(data);
            }

            Command_Router command_Router = new Command_Router();
            command_Router.Router_Buttons(data);

        }

        


   }
    public static class Extension
    {
        public static bool IsNumeric(this string s)
        {
            float output;
            return float.TryParse(s, out output);
        }
    }
}
