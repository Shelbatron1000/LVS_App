using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Foundation;
using Prototype;
using Prototype.iOS;
using UIKit;
using WebKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer (typeof(HybridWebView), typeof(HybridWebViewRenderer))]
namespace Prototype.iOS
{
    public class HybridWebViewRenderer : ViewRenderer<HybridWebView, UIWebView>
    {
        protected override void OnElementChanged(ElementChangedEventArgs<HybridWebView> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
            {
                var webView = new UIWebView();
                SetNativeControl(webView);
            }
            if (e.OldElement != null)
            {
                var hybridWebView = e.OldElement as HybridWebView;

            }
            if (e.NewElement != null)
            {
                //Control.ScalesPageToFit = true;
                //Control.Frame = this.Frame;
                string url = Element.Url;
                Control.LoadRequest(new NSUrlRequest(new NSUrl(url)));
            }
        }
    }
}
