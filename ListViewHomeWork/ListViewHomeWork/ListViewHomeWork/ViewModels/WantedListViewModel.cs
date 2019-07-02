using ListViewHomeWork.Models;
using ListViewHomeWork.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ListViewHomeWork.ViewModels
{
    public class WantedListViewModel : BaseViewModel
    {
        INavigation navigation;
        private ObservableCollection<PersonWanted> peopleWanted;

        public ObservableCollection<PersonWanted> PeopleWanted
        {
            get { return peopleWanted; }
            set
            {
                if (peopleWanted == null)
                    peopleWanted = new ObservableCollection<PersonWanted>();

                foreach (var people in value)
                {
                    peopleWanted.Add(people);
                }
            }
        }

        private PersonWanted selectedPerson;

        public PersonWanted SelectedPerson
        {
            get { return selectedPerson; }
            set
            {

                if (value != null)
                {
                    selectedPerson = value;
                    OnViewDetail(selectedPerson);
                }
            }
        }

        public ICommand ViewDetailCommand { get; set; }


        public WantedListViewModel(INavigation navigation)
        {
            this.navigation = navigation;
            PeopleWanted = new ObservableCollection<PersonWanted>()
            {
                new PersonWanted()
                {
                    Name="Robert",
                    NickName="El Inquisidor",
                    PictureUrl="https://www.ajc.com/rf/image_large/Pub/p8/AJC/2017/09/27/Images/Young%20thug%20mug.JPG",
                    Age=35,
                    WantedReasons = new List<string>()
                    {
                        "Narcotráfico"
                    }
                },
                new PersonWanted()
                {
                    Name="Tony",
                    NickName="La Salamandra",
                    PictureUrl="https://nationalpostcom.files.wordpress.com/2017/07/meeks2.jpg",
                    Age=28,
                    WantedReasons = new List<string>()
                    {
                        "Robo a mano armada"
                    }
                }
            };

            ViewDetailCommand = new Command<PersonWanted>(OnViewDetail);
        }

        private void OnViewDetail(PersonWanted person)
        {
            var page = new WantedDetailPage();
            page.Title = person.NickName;
            page.SetModel(person);
            navigation.PushAsync(page);
        }
    }
}
