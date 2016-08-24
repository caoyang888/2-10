using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                var da = new _2_10.Admin.BLL.DataAcquisition();
                //var aaa = da.Youku("http://v.youku.com/v_show/id_XMTQ1ODkxMzMzNg==.html?from=y1.2-2.4.11");
                //var aaa = da.Tudou("http://www.tudou.com/albumplay/9k2ea75oKDg.html");
                //var aaa = da.Iqiyi("http://www.iqiyi.com/v_19rrlbx3lk.html");
                //var aaa = da.Tencent("http://v.qq.com/cover/c/c4c8vgv33u0b5rl.html?vid=v01826u2lo4&ptag=v_qq_com");
                //var aaa = da.Sohu("http://tv.sohu.com/20160128/n436156516.shtml");
                //var aaa = da.LeTV("http://www.le.com/ptv/vplay/24518673.html");
                //var aaa = da.FunTV("http://www.fun.tv/vplay/g-118759.v-504267/");
                //var aaa = da.Kankan("http://vod.kankan.com/v/88/88129.shtml#5431588");
                //var aaa = da.Bilibili("http://www.bilibili.com/video/av3688163/");
                //var aaa = da.Acfun("http://www.acfun.tv/v/ac2496522");
                //var aaa = da.MGTV("http://www.mgtv.com/v/7/156214/f/2965759.html");
                var aaa = da._17173("http://v.17173.com/v_1_1000177/MzE4MDk1NzU.html");
                //var aaa = da.Dmzj("http://donghua.dmzj.com/donghua_play/253959.html");
                //var aaa = da.Longzhu("http://v.longzhu.com/210/v/342840");
                //var aaa = da.Gamefy("http://www.gamefy.cn/vplay.php?id=85392&class_id=30&album_id=547");
                string key = Console.ReadLine();
            }
        }
    }
}
