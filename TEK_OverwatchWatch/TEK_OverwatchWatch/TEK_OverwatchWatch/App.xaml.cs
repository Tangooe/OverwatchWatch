using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Xamarin.Forms;

namespace TEK_OverwatchWatch
{
    public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();
			MainPage = new Views.MainPage();
		}

        protected override void OnStart ()
		{
		    AppCenter.Start("android=405e6656-c4f1-48ca-a3be-eb8bfd010566;" + "uwp=732bd9a6-b900-43f1-9409-53496e757e3b;",
		        typeof(Analytics), typeof(Crashes));
        }

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
