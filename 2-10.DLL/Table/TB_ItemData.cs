using System;


namespace _2_10.Model
{
    public class TB_ItemData : BaseModel
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public int Data { get; set; }
        public VideoViewType VideoViewType { get; set; }
        public DataCategory DataCategory { get; set; }
        public DateTime CreateDate { get; set; }
    }

    public enum DataCategory : int
    {
        播放量 = 1,
        评论量 = 2,
        点赞 = 3,
    }

    public enum VideoViewType : int
    {
        全部 = 1,
        单集 = 2,
    }
}
