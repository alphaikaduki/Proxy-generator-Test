using System;
using System.Text;

using System.Windows;

using System.IO;
using System.Net.Http;
using System.Net.Cache;

namespace proxygennew
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        static string proxy_get = "";
        private System.Net.HttpWebRequest HttpWReq;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void start_Click(object sender, RoutedEventArgs e)
        {
           
            if ((bool)socks5.IsChecked)
            {
                proxy_get = "https://api.proxyscrape.com/?request=getproxies&proxytype=socks5&timeout=9000&ssl=yes";
            }
            if ((bool)http.IsChecked)
            {
                proxy_get = "https://api.proxyscrape.com/?request=getproxies&proxytype=http&timeout=9000&ssl=yes";
            }

            try
            {
                using (var req = new HttpClient()
                {


                })
                {
                    Encoding enc = Encoding.UTF8;

                    HttpWReq = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(proxy_get);
                    HttpWReq.Method = "GET";           // GET or POST
                    HttpWReq.UserAgent = "useragent"; // ユーザエージェント
                    HttpWReq.ReadWriteTimeout = 5 * 1000; // 読み書き時のタイムアウト？
                    HttpWReq.Timeout = 5 * 1000;        // タイムアウト設定
                    HttpWReq.CachePolicy = new RequestCachePolicy(RequestCacheLevel.NoCacheNoStore);
                    HttpWReq.KeepAlive = true;





                    DateTime x1 = DateTime.Now;
                    System.Net.HttpWebResponse HttpWResp = (System.Net.HttpWebResponse)HttpWReq.GetResponse();
                    DateTime x2 = DateTime.Now;

                    Stream resStream = HttpWResp.GetResponseStream();
                    StreamReader sr = new StreamReader(resStream, enc);
                    string html = sr.ReadToEnd();
                    sr.Close();
                    resStream.Close();

                    // Insert code that uses the response object.
                    HttpWResp.Close();
                    proxylist.Text = html;
                    proxylist.AppendText(html);




                }
            }
            catch
            {


            }

        }
    }
    }

