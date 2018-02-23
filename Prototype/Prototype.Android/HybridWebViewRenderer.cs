using System;
using Android.Content;
using Android.Webkit;
using Prototype;
using Prototype.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(HybridWebView), typeof(HybridWebViewRenderer))]
namespace Prototype.Droid
{
    public class HybridWebViewRenderer : ViewRenderer<HybridWebView, Android.Webkit.WebView>
        {
            Context _context;

            public HybridWebViewRenderer(Context context) : base(context)
            {
                _context = context;
            }

        public HybridWebViewRenderer() : base(null)
        {
            // Default constructor needed for Xamarin Forms bug?
            throw new Exception("This constructor should not actually ever be used");
        }

        protected override void OnElementChanged(ElementChangedEventArgs<HybridWebView> e)
            {
                base.OnElementChanged(e);

                if (Control == null)
                {
                var webView = new Android.Webkit.WebView(_context);
                    webView.Settings.JavaScriptEnabled = true;
                    webView.Settings.AllowContentAccess = true;
                    webView.Settings.AllowFileAccess = true;
                    webView.Settings.AllowFileAccessFromFileURLs = true;
                    webView.Settings.AllowUniversalAccessFromFileURLs = true;
                    webView.Settings.DatabaseEnabled = true;
                    webView.Settings.DisplayZoomControls = true;
                    webView.Settings.DomStorageEnabled = true;
                    webView.Settings.LoadsImagesAutomatically = true;
                    webView.Settings.SaveFormData = true;
                    //webView.Settings.UseWideViewPort = true;//uses a meta tag if html has one
                    webView.Settings.SetSupportZoom(true);
                    //webView.Settings.LoadWithOverviewMode = true; //zooms the webpage out completely
                    webView.Settings.MixedContentMode = MixedContentHandling.CompatibilityMode;

                SetNativeControl(webView);
                }
                if (e.OldElement != null)
                {
                    var hybridWebView = e.OldElement as HybridWebView;
                }
                if (e.NewElement != null)
                {
                    Control.LoadUrl(Element.Url);
                }
            }

        }
    }
