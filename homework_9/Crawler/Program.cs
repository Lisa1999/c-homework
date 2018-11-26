using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Crawler
{
    class Crawler
    {
        private Hashtable urls = new Hashtable();
        private int count = 0;
        static void Main(string[] args)
        {
            Crawler crawler = new Crawler();
            string startUrl1 = "http://www.cnblogs.com/dstang2000/";
            string startUrl2 = "http://www.cnblogs.com/dstang2000/archive/";
            crawler.urls.Add(startUrl1, false);
            crawler.urls.Add(startUrl2, false);
            Parallel.Invoke(new Action[]{
                () => crawler.Crawl(),
                () => crawler.Crawl()});
        }

        private void Crawl()
        {
            Console.WriteLine($"爬虫{Thread.CurrentThread.ManagedThreadId}开始爬行了...");
            while (true)
            {
                string current = null;
                foreach (string url in urls.Keys)
                {
                    if ((bool)urls[url]) continue;//已经下载过的不再下载
                    current = url;
                    urls[current] = true;
                    break;
                }
                if (current == null || count > 50)
                    break;
                Console.WriteLine($"爬虫{Thread.CurrentThread.ManagedThreadId}爬行" + current + "页面");
                string html = Download(current);
                Parse(html);
            }
            Console.WriteLine($"爬虫{Thread.CurrentThread.ManagedThreadId}爬行结束");
        }

        public string Download(string url)
        {
            try
            {
                WebClient wc = new WebClient();
                wc.Encoding = Encoding.UTF8;
                string html = wc.DownloadString(url);
                string filename = (count++).ToString() + ".html";
                File.WriteAllText(filename, html, Encoding.UTF8);
                return html;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        public void Parse(string html)
        {
            try
            {
                string strRef = @"(href|HREF)[]* = []*[""'][^""'#>]+[""']";
                MatchCollection matches = new Regex(strRef).Matches(html);
                foreach (Match match in matches)
                {
                    strRef = match.Value.Substring(match.Value.IndexOf('=') + 1).Trim('"', '\"', '#', ' ', '>');
                    if (strRef.Length == 0) continue;
                    if (urls[strRef] == null) urls[strRef] = false;
                }

            }
            catch (Exception e)
            {
                return;
            }
        }


    }
}
