using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Prototype.Droid;
using Prototype.WebViews;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(TransparentWebView), typeof(TransparentWebViewRenderer))]
namespace Prototype.Droid
    {
        public class TransparentWebViewRenderer : WebViewRenderer
        {

            Context _context;

            public TransparentWebViewRenderer(Context context) : base(context)
            {
                _context = context;
            }
            protected override void OnElementChanged(ElementChangedEventArgs<WebView> e)
                {
                    base.OnElementChanged(e);

                // Setting the background as transparent
                Control.SetBackgroundColor(Android.Graphics.Color.Transparent);
                }
        }
    }