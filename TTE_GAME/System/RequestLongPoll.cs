using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xNet;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Threading;
using TTE_GAME.Classes;

namespace TTE_GAME.System
{
    class RequestLongPoll
    {

        private static string[] getLongPollServer()
        {
            var danni = new HttpRequest();
            danni.UserAgent = Http.OperaUserAgent();
            danni.Cookies = new CookieDictionary();
            danni.KeepAlive = true;
            string[] Danni = { };
            try
            {
                string response = danni.Get("https://api.vk.com/method/"
                    + "groups.getLongPollServer" + "?"
                    + "&" + "group_id=" + Variables_Static.GroupId
                    + "&" + "lp_version=" + 3
                    + "&" + "access_token=" + Variables_Static.Token
                    + "&" + "v=" + Variables_Static.v).ToString();
                JObject json = JObject.Parse(response);
                if (response.Contains("failed"))
                {
                    getLongPollServer();
                    Console.WriteLine("Failed");
                }
                if (response.Contains("error"))
                {
                    getLongPollServer();
                    Console.WriteLine("Failed");
                }

                Danni = new string[]
                {
                json["response"]["server"].ToString(),
                json["response"]["key"].ToString(),
                json["response"]["ts"].ToString()
                };

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                getLongPollServer();
            }

            return Danni;


        }



        public static string zaprossLongPoll()
        {
            string server, key;
            int ts;
            string[] Danni = getLongPollServer();
            try
            {
                server = Danni[0];
                key = Danni[1];
                ts = Convert.ToInt32(Danni[2]);
            }
            catch (Exception ex)
            {
                zaprossLongPoll();
                Console.WriteLine(ex);
            }
            finally
            {
                server = Danni[0];
                key = Danni[1];
                ts = Convert.ToInt32(Danni[2]);
            }


            HttpRequest danni = new HttpRequest();
            System.MessageSend MesSend = new System.MessageSend();
            while (true)
            {
                string response;
                try
                {
                    danni.Get($"{server}?act=a_check&key={key}&ts={ts}&wait=25").ToString();
                    Console.WriteLine("Try");
                }
                catch (Exception ex)
                {
                    zaprossLongPoll();
                    Console.WriteLine(ex);
                }
                finally
                {
                    response = danni.Get($"{server}?act=a_check&key={key}&ts={ts}&wait=25").ToString();
                    Console.WriteLine("Finally");
                }

                JObject json = JObject.Parse(response);

                if (response.Contains("failed"))
                {
                    if (Convert.ToInt32(json["failed"]) == 1) { ts = Convert.ToInt32(json["ts"]); }
                    else if (Convert.ToInt32(json["failed"]) == 2) { Danni = getLongPollServer(); key = Danni[1]; }
                    else if (Convert.ToInt32(json["failed"]) == 3) { Danni = getLongPollServer(); key = Danni[1]; ts = Convert.ToInt32(Danni[2]); }
                }
                else
                {
                    for (int i = 0; i < json["updates"].Count(); i++)
                    {

                        if (Convert.ToString(json["updates"][i]["type"]) == "message_new")
                        {
                            if (response.Contains("chat_invite_user"))
                            {
                                if (Convert.ToString(json["updates"][i]["object"]["action"]["type"]) == "chat_invite_user")
                                {

                                    if (Convert.ToString(json["updates"][i]["object"]["action"]["member_id"]) == "-195044271")
                                    {
                                        int id_beseda = Convert.ToInt32(json["updates"][i]["object"]["peer_id"]);
                                        //Rabota.AddedToBeseda.AddMe(id_beseda);
                                    }
                                    else
                                    {

                                    }
                                }
                            }
                            else


                            {


                              
                                int IdMes = Convert.ToInt32(json["updates"][i]["object"]["conversation_message_id"]);
                                int Time = Convert.ToInt32(json["updates"][i]["object"]["date"]);
                                string IdButton = "0";
                                if (json["updates"][i]["object"]["payload"] != null)
                                {
                                    IdButton = new String(json["updates"][i]["object"]["payload"].ToString().Where(Char.IsDigit).ToArray());
                                }
                                string Title = json["updates"][i]["object"]["text"].ToString();
                                int[] Razdelit = ExtraFunction.SettingDanniEf.SettingDanniBeseda(Convert.ToInt32(json["updates"][i]["object"]["from_id"]), Convert.ToInt32(json["updates"][i]["object"]["peer_id"]));

                                int IdPols = Razdelit[1];
                                int IdPolsBes = Razdelit[0];

                                Task.Run(() =>
                                {
                                    Task_Factory task = new Task_Factory();
                                    task.Processing_Command(Title, IdPols, IdPolsBes, IdMes, Time, Convert.ToInt32(IdButton));
                                });

                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine($@"1. ID пользователя: {IdPols}. {"\n"}2. id беседы: {IdPolsBes}. {"\n"}3. id сообщений: {IdMes}. {"\n"}4. Время сообщения: {Time}. {"\n"}5. Сообщение: {Title}");
                            }
                        }


                    }
                }
                ts = Convert.ToInt32(json["ts"]);


            }

        }

    }
}
