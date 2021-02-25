namespace Models.GachaLogModels
{
    public class GachaLogsMessage
    {
        public int retcode { get; set; } 
        public string message { get; set; } 
        public Data data { get; set; }

        public override string ToString()
        {
            string dataString = data.ToString();
            return "retcode: " + retcode
                               + "\n" + "message: " + message
                               + "\n" + dataString;
        }
    }
}