﻿using Prism;
using Prism.Ioc;
using BeersList.ViewModels;
using BeersList.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BeersList.Services;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace BeersList
{
    public partial class App
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<DetailPage, DetailPageViewModel>();

            containerRegistry.RegisterInstance<IBeerService>(new BeerService());
            containerRegistry.RegisterForNavigation<DetailPage, DetailPageViewModel>();
        }
    }
}
