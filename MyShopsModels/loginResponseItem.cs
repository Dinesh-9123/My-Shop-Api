using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShopsModels
{
    public class loginResponseItem
    {
        public string email { get; set; }
        public string token { get; set; }
        public int expiresIn { get; set; }
    }
}
