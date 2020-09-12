using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
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
            Command_Router command_Router = new Command_Router();
            command_Router.Router_Buttons(data);

        }
      
        


   }
}
