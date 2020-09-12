using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TTE_GAME.Classes;
using xNet;

namespace TTE_GAME.System
{
    class MessageSend
    {
        
        public void Send(Variables data, string Message, string Media = "")
        {
            var danni = new HttpRequest();
            danni.Cookies = new CookieDictionary();
            danni.KeepAlive = true;
            danni.UserAgent = Http.FirefoxUserAgent();

            RequestParams reqParams = new RequestParams();
            reqParams["message"] = Message;
            reqParams["peer_id"] = data.IdPolsBes; //+1
            reqParams["dont_parse_links"] = 0;
            reqParams["attachment"] = Media;
            reqParams["forward_messages"] = "";
            reqParams["access_token"] = Variables_Static.Token;
            reqParams["v"] = Variables_Static.v;
            string response = danni.Post("https://api.vk.com/method/messages.send?", reqParams).ToString();

        }
        public void Send(Variables data, string Message, string Media = "", string keyboard = null)
        {
            var danni = new HttpRequest();
            danni.Cookies = new CookieDictionary();
            danni.KeepAlive = true;
            danni.UserAgent = Http.FirefoxUserAgent();

            RequestParams reqParams = new RequestParams();
            reqParams["message"] = Message;
            reqParams["keyboard"] = keyboard;
            reqParams["peer_id"] = data.IdPolsBes; //+1
            reqParams["dont_parse_links"] = 0;
            reqParams["attachment"] = Media;
            reqParams["forward_messages"] = "";
            reqParams["access_token"] = Variables_Static.Token;
            reqParams["v"] = Variables_Static.v;
            string response = danni.Post("https://api.vk.com/method/messages.send?", reqParams).ToString();
            Console.WriteLine(response);
        }
        



    }
}
