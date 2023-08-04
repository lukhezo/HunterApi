namespace HunterConsole.Hunter.Response
{
    /// <summary>
    /// This is the JSON object that is returned from the following URL 
    /// https://hunter.io/api/email-verifier that has been converted to C#
    /// </summary> 

    public class Data
    {
        public string status { get; set; }
        public string result { get; set; }
        public string _deprecation_notice { get; set; }
        public int score { get; set; }
        public string email { get; set; }
        public bool regexp { get; set; }
        public bool gibberish { get; set; }
        public bool disposable { get; set; }
        public bool webmail { get; set; }
        public bool mx_records { get; set; }
        public bool smtp_server { get; set; }
        public bool smtp_check { get; set; }
        public bool accept_all { get; set; }
        public bool block { get; set; }
        public List<object> sources { get; set; }
    }

    public class Meta
    {
        public Params @params { get; set; }
    }

    public class Params
    {
        public string email { get; set; }
    }

    public class Root
    {
        public Data data { get; set; }
        public Meta meta { get; set; }
    }
}
