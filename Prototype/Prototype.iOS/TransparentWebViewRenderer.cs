using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using Prototype.iOS;
using Prototype.WebViews;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(TransparentWebView), typeof(TransparentWebViewRenderer))]
namespace Prototype.iOS
{
        public class TransparentWebViewRenderer : WebViewRenderer
        {
            protected override void OnElementChanged(VisualElementChangedEventArgs e)
            {
                base.OnElementChanged(e);

                // Setting the background as transparent
                this.Opaque = false;
                this.BackgroundColor = Color.Transparent.ToUIColor();
            }
        }
}

