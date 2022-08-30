using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShopsModels
{
    public class UserDataModel
    {
        public string country { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string district { get; set; }
        public int pinCode { get; set; }
        public int houseNo { get; set; }
    }
}
