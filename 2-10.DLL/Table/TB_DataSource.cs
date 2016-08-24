using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _2_10.Model
{
    [Table("DataSource")]
    public class TB_DataSource : BaseModel
    {
        [Key]
        public int Id { get; set; }
        public int ItemId { get; set; }
        public Platform Platform { get; set; }
        public string Url { get; set; }
        public DateTime CreateDate { get; set; }
    }

    public enum Platform : int
    {
        优酷 = 1,
        土豆 = 2,
        爱奇艺动漫 = 3,
        腾讯视频 = 4,
        暴风影音 = 5,
        pptv = 6,
        搜狐视频 = 7,
        乐视 = 8,
        风行 = 9,
        响巢看看 = 10,
        哔哩哔哩 = 11,
        Acfun = 12,
        芒果TV = 13,
        _17173视频 = 14,
        华数 = 15,
        动漫之家 = 16,
        龙珠 = 17,
        游戏风云 = 18
    }
}
