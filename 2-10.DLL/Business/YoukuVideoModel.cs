using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_10.Model.Business
{
    public class YoukuPlayCountModel
    {
        public int vv { get; set; }
        public string ss { get; set; }
    }

    public class YoukuSubscribeData
    {
        public int subscribe { get; set; }
        public int user_type { get; set; }
        public int anonym_subscribe { get; set; }
        public int sumCount { get; set; }
        public bool followed { get; set; }
    }

    public class YoukuSubscribeE
    {
        public string desc { get; set; }
        public string provider { get; set; }
        public int code { get; set; }
    }

    public class YoukuSubscribe
    {
        public int total { get; set; }
        public YoukuSubscribeE e { get; set; }
        public YoukuSubscribeData data { get; set; }
        public int cost { get; set; }
    }
}
