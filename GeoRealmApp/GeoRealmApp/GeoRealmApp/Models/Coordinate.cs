using Realms;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeoRealmApp.Models
{
    public class Coordinate : RealmObject
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public string LatitudeLongitude { get => this.ToString(); }

        public override string ToString()
        {
            return $"{Latitude}, {Longitude}";
        }
    }
}
