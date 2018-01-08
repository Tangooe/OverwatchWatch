using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using TEK_OverwatchWatch.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TEK_OverwatchWatch.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HeroesPage : ContentPage
    {
        private readonly List<Hero> _heroes;
        public HeroesPage()
        {
            InitializeComponent();

            var overwatchFacade = new OverwatchFacade();
            _heroes = overwatchFacade.GetAllHeroes().ToList();
            MyListView.ItemsSource = _heroes;
        }

        private void SearchBar_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            var keyword = MySearchBar.Text.ToLower();
            var searchResult = _heroes.Where(h => h.Name.ToLower().Contains(keyword));

            MyListView.ItemsSource = searchResult;
        }

        private async void MyListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem is Hero selectedHero)
            {
                var page = new HeroDetailsPage(selectedHero.Id);
                await Navigation.PushAsync(page);
            }
        }
    }
}
