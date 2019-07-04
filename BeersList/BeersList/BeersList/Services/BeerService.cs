using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;
using BeersList.Models;

namespace BeersList.Services
{
    public class BeerService : IBeerService
    {
        public async Task<ObservableCollection<Beer>> GetBeersAsync()
        {
            HttpClient client = new HttpClient();

            var response = await client.GetStringAsync("https://api.punkapi.com/v2/beers");

            return JsonConvert.DeserializeObject<ObservableCollection<Beer>>(response);
        }
    }
}
