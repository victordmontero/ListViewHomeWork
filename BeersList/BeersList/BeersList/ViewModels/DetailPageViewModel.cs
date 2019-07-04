using BeersList.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BeersList.ViewModels
{
    public class DetailPageViewModel : ViewModelBase
    {
        private Beer selectedBeer;
        public Beer SelectedBeer
        {
            get { return selectedBeer; }
            set { SetProperty(ref selectedBeer, value); }
        }

        public DetailPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {

        }

        public override void OnNavigatingTo(INavigationParameters parameters)
        {
            base.OnNavigatingTo(parameters);
            SelectedBeer = parameters.GetValue<Beer>("model");
            Title = SelectedBeer.Name;
        }

    }
}
