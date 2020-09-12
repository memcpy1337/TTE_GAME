using System;
using System.Collections.Generic;
using System.Text;

namespace TTE_GAME.Classes
{
    public class Variables
    {
        //public string Token = "6798bf0284d10928d0be5e7eee71a8e7a8ef31332c5e2fc5c6587adce55a6a4ee40e00a8f665ee126ed54";
        //public string Token = "035b0bb4cb0bc349730fa77cdf60ecd5c4a63b5f6eb5f4cb39f68519b6704fd3173646a307b333db878a2";//приватный токен группы
       // public string RucaptchKey = "";
       // public string v = "5.80";
        //public string GroupId = "198606784";
        public int Time { get; set; }
        public int IdPols { get; set; }
        public int IdPolsBes { get; set; }
        public int IdButton { get; set; }
        public int IdMes { get; set; }
        public string Title { get; set; }
        public string Title_Lower { get; set; }
     
        public string[] Razdeli { get; set; }
        public string[] RazdeliLower { get; set; }
    
    }
}
