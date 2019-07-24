using GeoRealmApp.Models;
using Plugin.Geolocator.Abstractions;
using Prism.Navigation;
using Realms;
using System;
using System.Collections.ObjectModel;

namespace GeoRealmApp.ViewModels
{
    public class MainPageViewModel : ViewModelBase, IPageNavigationAware
    {

        private ObservableCollection<Coordinate> coordinates;
        public ObservableCollection<Coordinate> Coordinates
        {
            get { return coordinates; }
            set { SetProperty(ref coordinates, value); }
        }

        IGeolocator geolocatorInstance;
        Realm realmInstance;

        public MainPageViewModel(INavigationService navigationService, IGeolocator geolocator, Realm realm)
            : base(navigationService)
        {
            geolocatorInstance = geolocator;
            realmInstance = realm;

            Title = "Main Page";

            Coordinates = new ObservableCollection<Coordinate>();
            foreach (var coord in realmInstance.All<Coordinate>())
            {
                Coordinates.Add(coord);
            }

            if (IsLocationAvailable())
                StartListeningAsync();
        }

        private async void StartListeningAsync()
        {
            if (geolocatorInstance.IsListening)
                return;

            await geolocatorInstance.StartListeningAsync(TimeSpan.FromSeconds(5), 5);

            geolocatorInstance.PositionChanged += Current_PositionChanged;

        }

        private void Current_PositionChanged(object sender, PositionEventArgs e)
        {
            var position = e.Position;
            Coordinates.Add(new Coordinate()
            {
                Latitude = position.Latitude,
                Longitude = position.Longitude
            });

            realmInstance.Write(() => realmInstance.Add(new Coordinate()
            {
                Latitude = position.Latitude,
                Longitude = position.Longitude
            }));
        }

        public bool IsLocationAvailable()
        {
            if (!geolocatorInstance.IsGeolocationAvailable)
                return false;

            return geolocatorInstance.IsGeolocationAvailable;
        }

        private async void StopListeningAsync()
        {
            if (!geolocatorInstance.IsListening)
                return;

            await geolocatorInstance.StopListeningAsync();

            geolocatorInstance.PositionChanged -= Current_PositionChanged;
        }

        public void OnAppearing()
        {
            StartListeningAsync();
        }

        public void OnDisappearing()
        {
            StopListeningAsync();
        }
    }
}
