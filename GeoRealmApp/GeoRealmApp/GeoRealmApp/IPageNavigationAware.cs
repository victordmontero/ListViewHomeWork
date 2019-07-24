using System;
using System.Collections.Generic;
using System.Text;

namespace GeoRealmApp
{
    public interface IPageNavigationAware
    {
        void OnAppearing();
        void OnDisappearing();
    }
}
