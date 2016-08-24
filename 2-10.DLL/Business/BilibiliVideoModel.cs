using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_10.Model.Business
{
    public class BilibiliVideoModel
    {
        public int code { get; set; }
        public BilibiliDataVideoModel data { get; set; }
        public string message { get; set; }
    }

    public class BilibiliDataVideoModel
    {
        public long view { get; set; }
        public long danmaku { get; set; }
        public long reply { get; set; }
        public long favorite { get; set; }
        public long coin { get; set; }
        public long share { get; set; }
        public long now_rank { get; set; }
        public long his_rank { get; set; }
    }
}
