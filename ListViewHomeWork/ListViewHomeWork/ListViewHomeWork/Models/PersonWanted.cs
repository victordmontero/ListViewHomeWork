using System;
using System.Collections.Generic;
using System.Text;

namespace ListViewHomeWork.Models
{
    public class PersonWanted
    {
        public string Name { get; set; }
        public string NickName { get; set; }
        public byte Age { get; set; }
        public List<string> WantedReasons { get; set; }
        public string PictureUrl { get; set; }
    }
}
