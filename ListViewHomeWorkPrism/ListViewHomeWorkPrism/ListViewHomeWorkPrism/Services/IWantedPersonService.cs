using ListViewHomeWorkPrism.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ListViewHomeWorkPrism.Services
{
    public interface IWantedPersonService
    {
        ObservableCollection<PersonWanted> GetPeople();
    }
}
