using System.Collections.Generic;

namespace Models.GachaTypeListModels
{
    public class Data
    {
        public List<GachaTypeList> gacha_type_list { get; set; }
        public string region { get; set; }

        public string getGachaTypeList()
        {
            string str = string.Empty;
            foreach (var gachaType in gacha_type_list)
            {
                str += (gachaType.id + "-" + gachaType.key + "-" + gachaType.name + "\n");
            }

            return str;
        }
    }
}