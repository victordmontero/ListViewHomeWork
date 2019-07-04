using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using BeersList.Models;
using BeersList.Services;

namespace BeersList.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private ObservableCollection<Beer> beers;
        public ObservableCollection<Beer> Beers
        {
            get { return beers; }
            set { SetProperty(ref beers, value); }
        }

        private Beer selectedBeer;
        private IBeerService beerService;

        public Beer SelectedBeer
        {
            get { return selectedBeer; }
            set
            {
                SetProperty(ref selectedBeer, value);

                if (value != null)
                    OnSelectedBeer(selectedBeer);
            }
        }

        public MainPageViewModel(INavigationService navigationService, IBeerService beerService)
            : base(navigationService)
        {
            this.beerService = beerService;
            Title = "List of Beer";

            GetBeers();
        }

        private async void GetBeers()
        {
            Beers = await beerService.GetBeersAsync();
        }

        private async void OnSelectedBeer(Beer selectedBeer)
        {
            var parameters = new NavigationParameters();
            parameters.Add("model", selectedBeer);
            await NavigationService.NavigateAsync("DetailPage", parameters);
        }
    }
}
