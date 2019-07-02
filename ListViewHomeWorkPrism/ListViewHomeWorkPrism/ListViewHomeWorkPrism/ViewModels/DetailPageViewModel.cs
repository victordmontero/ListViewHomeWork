using ListViewHomeWorkPrism.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListViewHomeWorkPrism.ViewModels
{
    public class DetailPageViewModel : ViewModelBase
    {
        private PersonWanted personWanted;
        public PersonWanted PersonWanted
        {
            get { return personWanted; }
            set { SetProperty(ref personWanted, value); }
        }

        public IPageDialogService pageDialogService { get; private set; }

        public DelegateCommand SendAlertCommand { get; set; }

        public DetailPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService)
            : base(navigationService)
        {
            this.pageDialogService = pageDialogService;
            SendAlertCommand = new DelegateCommand(() => OnSendAlert());
        }

        private async void OnSendAlert()
        {
            IsBusy = true;

            await Task.Delay(3000);
            await pageDialogService.DisplayAlertAsync("Alert!", "Sent Alert", "Ok");

            IsBusy = false;
        }

        public override void OnNavigatingTo(INavigationParameters parameters)
        {
            base.OnNavigatingTo(parameters);
            PersonWanted = parameters.GetValue<PersonWanted>("model");
            Title = $"{PersonWanted.Name} \"{PersonWanted.NickName}\"";
        }


    }
}
