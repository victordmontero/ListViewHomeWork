using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using ListViewHomeWorkPrism.Models;

namespace ListViewHomeWorkPrism.Services
{
    public class WantedPersonService : IWantedPersonService
    {
        public ObservableCollection<PersonWanted> GetPeople()
        {
            return new ObservableCollection<PersonWanted>()
            {
                new PersonWanted()
                {
                    Name = "Kendri",
                    NickName = "Manigota",
                    Age = 29,
                    ReasonWanted = "I don't know",
                    PictureUrl="https://nationalpostcom.files.wordpress.com/2017/07/meeks2.jpg"
                }
            };
        }
    }
}
