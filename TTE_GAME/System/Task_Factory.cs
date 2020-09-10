using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TTE_GAME.Classes;

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
        public void Processing_Command(string title, int idPols, int IdPolsBes, int IdMes, int Time)
        {
            Variables data = new Variables();
            data.Title = title;
            data.IdMes = IdMes;
            data.Time = Time;
            data.IdPols = idPols;
            data.IdPolsBes = IdPolsBes;
            Text_Formatting text_Formatting = new Text_Formatting();
            text_Formatting.SettText(data);

            MessageSend MesSend = new MessageSend();
            
            bool register = false;
            if (register != true) RegNewAcc(data);
            

        }
        void RegNewAcc(Variables data)
        {
            MessageSend MesSend = new MessageSend();
            //ТУТ МЫ УЖЕ РЕГИСТРИРУЕМ ЧЕЛА, ВНОСИМ ЕГО АЙДИ ВК И Т.Д. ДАЛЕЕ ПОЛУЧАЕМ КНОПКУ (ВЫБРАННОГО ПЕРСА) В СЛЕД СООБЩЕНИИ, И ДЕЛАЕМ ДЕЙСТВИЯ ДАЛЬНЕЙШИЕ.
            var jsonText = File.ReadAllText("buttons_characters.txt");
            JObject json = JObject.Parse(jsonText);
            MesSend.Send(data, "Ты не был до этого тут, так что выбери своего бойца! Он будет с тобой до конца.", "", json);

        }
        


   }
}
