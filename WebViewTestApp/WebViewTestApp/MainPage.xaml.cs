using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace WebViewTestApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            HtmlWebViewSource localhtml = new HtmlWebViewSource();


            string text = "<html><body><h1>Xamarin.Forms</h1><p>Welcome to WebView.<a href= \"https://en.wikipedia.org/wiki/Xamarin\">Xamarin</a></p></body></html>";

            //string html_text = Content.Replace(@"\", string.Empty);
            localhtml.Html = text.Replace(@"\", string.Empty);
            _webview.Source = localhtml;
            _webview.Navigating += async (s, e) =>
            {
                if (e.Url.StartsWith("http"))
                {
                    try
                    {
                        var uri = new Uri(e.Url);
                        await Launcher.OpenAsync(uri);
                    }
                    catch (Exception ex)
                    {

                    }
                    finally
                    {
                        e.Cancel = true;
                    }

                }
            };
        }
    }
}


