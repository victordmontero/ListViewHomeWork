using BeersList.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace BeersList.Services
{
    public interface IBeerService
    {
        Task<ObservableCollection<Beer>> GetBeersAsync();
    }
}
