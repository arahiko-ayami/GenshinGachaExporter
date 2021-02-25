using System;
using System.Collections.Generic;

namespace Models.GachaLogModels
{
    public class Data
    {
        public string page { get; set; } 
        public string size { get; set; } 
        public string total { get; set; } 
        public List<List> list { get; set; } 
        public string region { get; set; }


        public string GetList()
        {
            string gachaLogs = String.Empty;
            foreach (var gachaLog in list)
            {
                gachaLogs += gachaLog.ToString();
            }

            return gachaLogs;
        }

        public override string ToString()
        {
            return  "page: " + page
                    + "\n" + "size: " + size
                    + "\n" + "total: " + total
                    + "\n" + "list: " + GetList()
                    + "\n" + "region: " + region + "\n";
        }
    }
}