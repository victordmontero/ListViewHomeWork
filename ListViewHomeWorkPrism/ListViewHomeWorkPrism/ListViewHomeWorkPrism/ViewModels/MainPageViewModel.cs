using ListViewHomeWorkPrism.Models;
using ListViewHomeWorkPrism.Services;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace ListViewHomeWorkPrism.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private PersonWanted selectedPerson;
        public PersonWanted SelectedPerson
        {
            get { return selectedPerson; }
            set
            {
                SetProperty(ref selectedPerson, value);

                if (selectedPerson == null)
                    return;

                ViewDetails(selectedPerson);
            }
        }

        private IWantedPersonService _wantedPersonService;

        private ObservableCollection<PersonWanted> peopleWanted;
        public ObservableCollection<PersonWanted> PeopleWanted
        {
            get { return peopleWanted; }
            set { SetProperty(ref peopleWanted, value); }
        }

        public MainPageViewModel(INavigationService navigationService, IWantedPersonService wantedPersonService)
            : base(navigationService)
        {
            Title = "List of the Most Wanted";
            _wantedPersonService = wantedPersonService;

            PeopleWanted = _wantedPersonService.GetPeople();
        }

        private async void ViewDetails(PersonWanted selectedPerson)
        {
            var parameters = new NavigationParameters();
            parameters.Add("model", selectedPerson);
            await NavigationService.NavigateAsync("DetailPage", parameters);
        }

    }
}
