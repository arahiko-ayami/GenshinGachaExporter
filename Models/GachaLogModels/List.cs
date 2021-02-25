namespace Models.GachaLogModels
{
    public class List
    {
        public string uid { get; set; } 
        public string gacha_type { get; set; } 
        public string item_id { get; set; } 
        public string count { get; set; } 
        public string time { get; set; } 
        public string name { get; set; } 
        public string lang { get; set; } 
        public string item_type { get; set; } 
        public string rank_type { get; set; }

        public override string ToString()
        {
            return "uid: " + uid
           + "\n" + "gacha_type: " + gacha_type
           + "\n" + "item_id: " + item_id
           + "\n" + "count: " + count
           + "\n" + "time: " + time
           + "\n" + "name: " + name
           + "\n" + "lang: " + lang
           + "\n" + "item_type: " + item_type
           + "\n" + "rank_type: " + rank_type + "\n\n";
        }
    }
}