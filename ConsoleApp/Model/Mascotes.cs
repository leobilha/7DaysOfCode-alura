using System.Collections.Generic;

namespace ConsoleApp.Model
{
    public class Mascotes
    {
        public int count { get; set; }
        public string next { get; set; }
        public object previous { get; set; }
        public List<Result> results { get; set; }

        public class Result
        {
            public string name { get; set; }
            public string url { get; set; }
        }
    }
}
