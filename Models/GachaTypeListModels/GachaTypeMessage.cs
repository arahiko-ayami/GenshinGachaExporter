namespace Models.GachaTypeListModels
{
    public class GachaTypeMessage
    {
        public int retcode { get; set; }
        public string message { get; set; }
        public Data data { get; set; }

        public override string ToString()
        {
            return "retcode: " + retcode + "\n"
                   + "message: " + message + "\n"
                   + "region: " + data.region + "\n"
                   + "gacha_type_list: " + data.getGachaTypeList();
        }
    }
}