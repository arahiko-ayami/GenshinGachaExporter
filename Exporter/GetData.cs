using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Models.GachaLogModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using static Exporter.Utils;

namespace Exporter
{
    public static class GetData
    {
        private static string _url;
        private static string gachaTypesUrl;
        private static string gachaLogBaseUrl;

        private static string ReadLog()
        {
            if (String.IsNullOrEmpty(GetGameLocation()))
            {
                return "";
            }

            using (StreamReader streamReader = new StreamReader(GetGameLocation()))
            {
                while (!streamReader.EndOfStream)
                {
                    var line = streamReader.ReadLine();

                    if (line.StartsWith("OnGetWebViewPageFinish:"))
                    {
                        line = line.Replace("OnGetWebViewPageFinish:", "");
                        _url = line;
                    }
                }
            }

            return _url;
        }

        public static async Task getData()
        {
            string str = ReadLog();
            if (str == null)
            {
                Console.WriteLine("Can't connect to miHoYo API, please open gacha history page in the game again!");
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
                return;
            }

            Uri uri = new Uri(str);
            var queryString = uri.Query;

            gachaTypesUrl = "https://hk4e-api.mihoyo.com/event/gacha_info/api/getConfigList" + queryString;
            gachaLogBaseUrl = "https://hk4e-api.mihoyo.com/event/gacha_info/api/getGachaLog" + queryString;
            var gachaTypeJson = JObject.Parse(GetJson(gachaTypesUrl));
            var gachaTypeList = gachaTypeJson["data"]["gacha_type_list"];

            foreach (var type in gachaTypeList)
            {
                string name = (string) type["name"];
                string key = (string) type["key"];
                var gachaLogs = await GetGachaLogs(key, name);
                JObject log = new JObject();

                foreach (var gachaLog in gachaLogs)
                {
                    log.Merge(gachaLog);
                }

                string stringlog = JsonConvert.SerializeObject(log);
                var objectLog = JsonConvert.DeserializeObject<GachaLogsMessage>(stringlog);
                WriteJsonFile(stringlog, name);
                WriteExcelFile(objectLog.data.list, name);

                Console.Clear();
                Console.WriteLine("Everything is done!");
            }
            Process.Start(AppDomain.CurrentDomain.BaseDirectory);
        }

        private static async Task<JObject> GetGachaLog(string key, int page)
        {
            JObject jObject = null;
            try
            {
                string gachaLogs = GetJson(gachaLogBaseUrl + "&gacha_type=" + key + "&page=" + page + "&size=20");
                jObject = JObject.Parse(gachaLogs);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return jObject;
        }

        private static async Task<List<JObject>> GetGachaLogs(string key, string name)
        {
            int page = 1;
            JObject log = null;
            List<JObject> gachaLogs = new List<JObject>();
            do
            {
                Console.Clear();
                Console.WriteLine("Fetching data from " + name + " page " + page + "...");
                log = await GetGachaLog(key, page);
                gachaLogs.Add(log);
                if (page % 10 == 0) Thread.Sleep(1000);
                page++;
            } while (log["data"]["list"].Any());

            gachaLogs.RemoveAt(gachaLogs.Count - 1);
            return gachaLogs;
        }
    }
}