using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NiceCode
{
    public class RequestHelper
    {
        public static string Request(string URL, Dictionary<string, object> dicArray, string xmlOrJson = "", string encoding = "utf-8", string method = "GET", CookieContainer cookie = null, WebHeaderCollection webHeaders = null, WebProxy proxy = null, string host = "", string referer = "", string accept = "", string contentType = "", string agent = "", string connection = "")
        {
            string text = string.Empty;
            try
            {
                StringBuilder prestr = new StringBuilder();
                if (dicArray != null)
                {
                    if (dicArray.Count > 0)
                    {
                        foreach (KeyValuePair<string, object> temp in dicArray)
                        {
                            prestr.Append(temp.Key + "=" + temp.Value.ToString() + "&");
                        }
                        int nLen = prestr.Length;
                        prestr.Remove(nLen - 1, 1);
                    }
                }

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);

                if (method == "GET")
                {
                    request = (HttpWebRequest)WebRequest.Create(URL + "?" + prestr.ToString());
                }

                request.Timeout = 5000;
                if (proxy != null)
                {
                    request.Proxy = proxy;
                }
                if (cookie != null)
                    request.CookieContainer = cookie;
                if (webHeaders != null)
                    request.Headers = webHeaders;
                if (!string.IsNullOrEmpty(host))
                    request.Host = host;
                if (!string.IsNullOrEmpty(referer))
                    request.Referer = referer;
                if (!string.IsNullOrEmpty(agent))
                    request.UserAgent = agent;

                request.Method = method;

                //request.UserAgent = "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/41.0.2272.89 Safari/537.36";

                if (!string.IsNullOrEmpty(contentType))
                {
                    request.ContentType = contentType;
                }

                if (!string.IsNullOrEmpty(accept))
                {
                    request.Accept = accept;
                }

                if (method == "POST")
                {
                    byte[] data = System.Text.Encoding.UTF8.GetBytes(prestr.ToString());
                    if (!string.IsNullOrEmpty(xmlOrJson))
                    {
                        data = System.Text.Encoding.UTF8.GetBytes(xmlOrJson);
                    }
                    request.ContentLength = data.Length;
                    var reqStream = request.GetRequestStream();
                    reqStream.Write(data, 0, data.Length);
                    reqStream.Close();
                }


                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                using (Stream dataStream = response.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(dataStream, Encoding.GetEncoding(encoding)))
                    {
                        text = reader.ReadToEnd();
                    }
                }
                request = null;
                response.Close();
            }
            catch (Exception ex)
            {
                new TxtLogHelper().Error(ex);
            }
            return text;
        }
    }
}
