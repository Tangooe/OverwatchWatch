using System.Linq;
using TEK_OverwatchWatch.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TEK_OverwatchWatch.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HeroDetailsPage : ContentPage
    {
        private readonly Hero _hero;
		public HeroDetailsPage (int heroId)
		{
			InitializeComponent ();

            var overwatchFacade = new OverwatchFacade();
		    _hero = overwatchFacade.GetHero(heroId);
		    BindingContext = _hero;
		    MyListView.ItemsSource = _hero.Abilities;
		    _hero.Video = "https://d1u1mce87gyfbn.cloudfront.net/hero/hanzo/intro-video.webm";

            MyListView.ItemTapped += (object sender, ItemTappedEventArgs e) => {
		        // don't do anything if we just de-selected the row
		        if (e.Item == null) return;
		        // do something with e.SelectedItem
		        ((ListView)sender).SelectedItem = null; // de-select the row
		    };
        }
	}
}