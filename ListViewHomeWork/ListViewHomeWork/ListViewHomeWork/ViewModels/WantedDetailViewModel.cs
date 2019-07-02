using ListViewHomeWork.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ListViewHomeWork.ViewModels
{
    public class WantedDetailViewModel : BaseViewModel
    {
        private PersonWanted personWanted;

        public PersonWanted PersonWanted
        {
            get { return personWanted; }
            set
            {
                if (personWanted != value)
                {
                    personWanted = value;
                    OnPropertyChanged(nameof(PersonWanted));
                }
            }
        }

        public ICommand SendAlertCommand { get; set; }

        public WantedDetailViewModel(PersonWanted person)
        {
            PersonWanted = person;
            SendAlertCommand = new Command(OnSendAlertCommandAsync);
        }

        private async void OnSendAlertCommandAsync(object obj)
        {
            IsBusy = true;
            await Task.Delay(3000);
            await Application.Current.MainPage.DisplayAlert("Message", "Alert Sent", "Ok");
            IsBusy = false;
        }
    }
}
