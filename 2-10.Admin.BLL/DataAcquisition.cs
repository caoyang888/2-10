using _2_10.Model.Business;
using System.Web.Script;
using NiceCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_10.Admin.BLL
{
    public class DataAcquisition
    {
        private Dictionary<string, object> dic = new Dictionary<string, object>();
        public ItemData Youku(string url)
        {
            //http://v.youku.com/QVideo/~ajax/getVideoPlayInfo?__rt=1&__ro=&id=364728334&sid=297453&type=vv&catid=100
            //http://yws.youku.com/friendships/js_get_podcast_fans_count.json?callback=Subscribe.checkFollowStatusCallback&cid=UMjg5NzUzMzI1Mg==&uid=UMjk0NzcwNjA2OA==
            string url1 = "http://v.youku.com/QVideo/~ajax/getVideoPlayInfo?id={0}&sid={1}&type=vv";
            int showId = 0;
            int videoId = 0;

            var html1 = RequestHelper.Request(url, dic);

            if (string.IsNullOrEmpty(html1))
            {
                return new ItemData();
            }

            showId = substring(html1, "showid=\"", "\"").ToInt();
            string h1 = substring(html1, "videoId", ";");
            videoId = substring(h1, "'", "'").ToInt();

            //var support = substring(html1, "id=\"upVideoTimes\" data-stat-role=\"ck\">", "</span>").ToInt();

            var html2 = RequestHelper.Request(string.Format(url1, videoId, showId), dic);
            var playModel = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<YoukuPlayCountModel>(html2);

            return new ItemData { PlayCount = playModel.vv };
        }

        public ItemData Tudou(string url)
        {
            //http://www.tudou.com/albumplay/9k2ea75oKDg.html
            //http://www.tudou.com/crp/itemSum.action?jsoncallback=page_play_model_itemSumModel__find&app=4&showArea=true&iabcdefg=132754441&uabcdefg=736926517&juabcdefg=01ap7ci9np2njc

            string url1 = "http://www.tudou.com/crp/itemSum.action?jsoncallback=aaabbbcc123&app=4&iabcdefg={0}&juabcdefg=1";
            int iid = 0;
            var html1 = RequestHelper.Request(url, dic);
            iid = substring(html1, ",iid: ", "\n").ToInt();

            var html2 = RequestHelper.Request(string.Format(url1, iid), dic).Replace("aaabbbcc123", "").Replace("(", "").Replace(")", "");
            var playModel = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<TudouVideoModel>(html2);

            return new ItemData()
            {
                PlayCount = playModel.playNum,
            };
        }

        public ItemData Iqiyi(string url)
        {
            //http://www.iqiyi.com/v_19rrlbx3lk.html#vfrm=2-3-0-1
            //http://mixer.video.iqiyi.com/jp/mixin/videos/445921300?callback=window.Q.__callbacks__.cbao8cu&status=1

            string url1 = "http://mixer.video.iqiyi.com/jp/mixin/videos/{0}";
            string tvId = string.Empty;
            var html1 = RequestHelper.Request(url, dic);
            tvId = substring(html1, "tvId:", ",");

            var html2 = RequestHelper.Request(string.Format(url1, tvId), dic);
            string playCount = substring(html2, "\"playCount\":", ",");

            return new ItemData()
            {
                PlayCount = playCount.ToInt(),
            };
        }

        public ItemData Tencent(string url)
        {
            //http://v.qq.com/cover/c/c4c8vgv33u0b5rl.html?vid=v01826u2lo4&ptag=v_qq_com
            //http://data.video.qq.com/fcgi-bin/data?tid=70&&appid=10001007&appkey=e075742beb866145&callback=1&idlist=c4c8vgv33u0b5rl&otype=json

            string url1 = "http://data.video.qq.com/fcgi-bin/data?tid=70&&appid=10001007&appkey=e075742beb866145&callback=aaabbbcc123&low_login=1&idlist={0}&otype=json&_={1}";

            string id = string.Empty;
            var html1 = RequestHelper.Request(url, dic);
            id = substring(html1, " target=\"_blank\" href=\"/detail/c/", ".html");

            var html2 = RequestHelper.Request(string.Format(url1, id, DateTime.Now.GetJsTimeString()), dic).Replace("aaabbbcc123", "").Replace("(", "").Replace(")", "");
            var playModel = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<TencentVideoModel>(html2);

            return new ItemData()
            {
                PlayCount = playModel.results[0].fields.allnumc,
            };
        }

        public ItemData PPTV()
        {
            //http://apis.web.pptv.com/show/videoList?from=web&version=1.0.0&format=jsonp&pid=9038468&cat_id=3&vt=22&cb=pplive_callback_1
            //固定地址 一次性获取所有数据

            return new ItemData();
        }

        public ItemData Sohu(string url)
        {
            //http://tv.sohu.com/20160128/n436156516.shtml
            //http://count.vrs.sohu.com/count/queryext.action?vids=2862964&plids=8991122&callback=playCountVrs
            //http://pl.hd.sohu.com/videolist?playlistid=8991122&o_playlistId=9009702&vid=2862964&pianhua=0&pageRule=undefined&pagesize=100&order=0&cnt=1&callback=__get_videolist

            string url1 = "http://count.vrs.sohu.com/count/queryext.action?vids={0}&callback=playCountVrs";

            string vid = string.Empty;
            string plids = string.Empty;
            var html1 = RequestHelper.Request(url, dic);
            vid = substring(html1, "var vid=\"", "\";");
            //plids = substring(html1, "var playlistId=\"", "\";");

            var html2 = RequestHelper.Request(string.Format(url1, vid), dic, referer: url);

            var total = substring(html2, "\"total\":", ",");
            var today = substring(html2, "\"today\":", "}");

            return new ItemData()
            {
                PlayCount = 0
            };
        }

        public ItemData LeTV(string url)
        {
            //http://www.le.com/ptv/vplay/24518673.html#vid=24518673
            //http://v.stat.letv.com/vplay/queryMmsTotalPCount?callback=jQuery17106894622628759721_1471934952003&pid=10009495&cid=5&vid=24518673&_=1471934952615

            string url1 = "http://v.stat.letv.com/vplay/queryMmsTotalPCount?callback=aaabbbcc123&pid={0}&cid=5&vid={1}&_={2}";

            string vid = string.Empty;
            string pid = string.Empty;
            var html1 = RequestHelper.Request(url, dic);
            pid = substring(html1, "pid: ", ",");
            vid = substring(html1, "vid: ", ",");

            var html2 = RequestHelper.Request(string.Format(url1, pid, vid, DateTime.Now.GetJsTimeString()), dic).Replace("aaabbbcc123", "").Replace("(", "").Replace(")", "");
            var playModel = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<LeVideoModel>(html2);

            return new ItemData()
            {
                PlayCount = playModel.plist_play_count
            };
        }

        public ItemData FunTV(string url)
        {
            //http://www.fun.tv/vplay/g-118759.v-504267/
            var html1 = RequestHelper.Request(url, dic);
            var playnum = substring(html1, "\"playnum\":\"", "\"");

            return new ItemData()
            {
                PlayCount = playnum.ToLong()
            };
        }

        public ItemData Kankan(string url)
        {
            //http://vod.kankan.com/v/88/88129.shtml
            var html1 = RequestHelper.Request(url, dic);
            var playnum = substring(html1, "total:\"", "\"").Replace(",", "");

            return new ItemData()
            {
                PlayCount = playnum.ToLong()
            };
        }

        public ItemData Bilibili(string url)
        {
            //http://www.bilibili.com/video/av3688163/
            //http://api.bilibili.com/archive_stat/stat?callback=jQuery1720022923355739189244_1471936490018&aid=3688163&type=jsonp&_=1471936490607

            string url1 = "http://api.bilibili.com/archive_stat/stat?callback=aaabbbcc123&aid={0}&type=jsonp&_={1}";

            string aid = substring(url, "av", "/");

            var html2 = RequestHelper.Request(string.Format(url1, aid, DateTime.Now.GetJsTimeString()), dic).Replace("aaabbbcc123", "").Replace("(", "").Replace(")", "").Replace(";", "");
            var playModel = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<BilibiliVideoModel>(html2);

            return new ItemData()
            {
                PlayCount = playModel.data.view
            };
        }

        public ItemData Acfun(string url)
        {
            //http://www.acfun.tv/v/ac2496522
            //http://www.acfun.tv/content_view.aspx?contentId=2496522&channelId=120

            string url1 = "http://www.acfun.tv/content_view.aspx?contentId={0}&channelId=120"; //channelId=120表示在[国产动画]栏目

            string aid = substring(url, "/ac", "/");

            var html2 = RequestHelper.Request(string.Format(url1, aid), dic);
            var playModel = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<long[]>(html2);

            return new ItemData()
            {
                PlayCount = playModel[0]
            };
        }

        public ItemData MGTV(string url)
        {
            //http://www.mgtv.com/v/7/156214/f/2965759.html
            //http://videocenter-2039197532.cn-north-1.elb.amazonaws.com.cn//dynamicinfo?callback=jQuery18207888498664228616_1471938160146&vid=2965759&_=1471938160495

            string url1 = "http://videocenter-2039197532.cn-north-1.elb.amazonaws.com.cn/dynamicinfo?callback=aaabbbcc123&vid={0}&_={1}";

            string aid = substring(url, "/f/", ".html");

            var html2 = RequestHelper.Request(string.Format(url1, aid, DateTime.Now.GetJsTimeString()), dic).Replace("aaabbbcc123", "").Replace("(", "").Replace(")", "").Replace(";", "");
            var playModel = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<MGVideoModel>(html2);

            return new ItemData()
            {
                PlayCount = playModel.data.all
            };
        }

        public ItemData _17173(string url)
        {
            //http://v.17173.com/v_1_1000177/MzE4MDk1NzU.html
            //http://v.17173.com/japi/video/getPlayCount?ids=31809575

            string url1 = "http://v.17173.com/japi/video/getPlayCount?ids={0}";

            var html1 = RequestHelper.Request(url, dic);
            var vid = substring(html1, "videoId: ", ",").ToLong();

            var html2 = RequestHelper.Request(string.Format(url1, vid), dic, method: "POST");

            var playModel = substring(html2, "\"data\":{\"" + vid + "\":", "}").ToLong();

            return new ItemData()
            {
                PlayCount = playModel
            };
        }

        public ItemData Dmzj(string url)
        {
            //http://donghua.dmzj.com/donghua_play/253959.html
            var html1 = RequestHelper.Request(url, dic);
            var playnum = substring(html1, "var play_count = '", "'");

            return new ItemData()
            {
                PlayCount = playnum.ToLong()
            };
            //var play_count = '
        }

        public ItemData Longzhu(string url)
        {
            //http://v.longzhu.com/210/v/342840
            var html1 = RequestHelper.Request(url, dic);
            var playnum = substring(html1, "播放量 : ", "</span>");

            return new ItemData()
            {
                PlayCount = playnum.ToLong()
            };
        }

        public ItemData Gamefy(string url)
        {
            //http://www.gamefy.cn/vplay.php?id=85392&class_id=30&album_id=547
            var html1 = RequestHelper.Request(url, dic);
            var playnum = substring(html1, "播放:<a style=\"color:red;text-decoration:none;\">", "&nbsp;");

            return new ItemData()
            {
                PlayCount = playnum.ToLong()
            };
        }

        public string substring(string source, string start, string end)
        {
            string s = string.Empty;
            if (!string.IsNullOrEmpty(source))
            {
                string h1 = source.Substring(source.IndexOf(start) + start.Length);
                string h2 = string.Empty;
                if (h1.IndexOf(end) > 0)
                    h2 = h1.Substring(0, h1.IndexOf(end));
                else
                    return h1;
                return h2;
            }

            return s;
        }
    }
}
