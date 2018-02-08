using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Prototype
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ParentPortalWebView : ContentPage
	{
		public ParentPortalWebView ()
		{
			InitializeComponent ();
            
            //Attemped to use a custom renderer here so that the zoom would be at the proper levels, but it did not work.
            //So now only an iOS device will open this website "in-app", while an Android device opens it externally. 
        }
	}
}