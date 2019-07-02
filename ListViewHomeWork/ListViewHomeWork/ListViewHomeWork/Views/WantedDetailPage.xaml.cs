﻿using ListViewHomeWork.Models;
using ListViewHomeWork.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ListViewHomeWork.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WantedDetailPage : ContentPage
    {
        public WantedDetailPage()
        {
            InitializeComponent();
        }


        public void SetModel(PersonWanted personWanted)
        {
            BindingContext = new WantedDetailViewModel(personWanted);
        }
    }
}