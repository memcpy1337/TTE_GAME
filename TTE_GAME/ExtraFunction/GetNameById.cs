using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using TTE_GAME.Classes;
using xNet;

namespace TTE_GAME.ExtraFunction
{
    class GetNameById
    {
        public string[] GetName(Variables data)
        {
            var danni = new HttpRequest();
            danni.Cookies = new CookieDictionary();
            danni.KeepAlive = true;
            danni.UserAgent = Http.FirefoxUserAgent();

            RequestParams reqParams = new RequestParams();
            reqParams["user_ids"] = data.IdPols;
            reqParams["fields"] = "first_name, last_name"; //+1
           
            reqParams["access_token"] = Variables_Static.Token;
            reqParams["v"] = Variables_Static.v;
            string response = danni.Post("https://api.vk.com/method/users.get?", reqParams).ToString();
            JObject json = JObject.Parse(response);

            string[] name = new string[2];
            name[0] = json["response"][0]["first_name"].ToString();
            name[1] = json["response"][0]["last_name"].ToString();

            return name;

        }

    }
}
