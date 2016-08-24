using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_10.Model.Business
{
    public class MGVideoModel
    {
        public int code { get; set; }
        public MGDataVideoModel data { get; set; }
        public string msg { get; set; }
        public string seqid { get; set; }
    }

    public class MGDataVideoModel
    {
        public long all { get; set; }
        public string allStr { get; set; }
        public long allVV { get; set; }
        public string allVVStr { get; set; }
        public long id { get; set; }
        public long like { get; set; }
        public long macClientVV { get; set; }
        public long mobileVV { get; set; }
        public long msitePadVV { get; set; }
        public long msitePhoneVV { get; set; }
        public long outsideVV { get; set; }
        public long padVV { get; set; }
        public long pcClientVV { get; set; }
        public long pcWebVV { get; set; }
        public long unlike { get; set; }
        public long weightVV { get; set; }
        public long win10ClientVV { get; set; }
    }
}
