using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShopsDomain
{
    [Table("[auth].[Users]")]
    public class AuthDto
    {
        [Key]
        public int userId { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string mobNo { get; set; }
        public int roles { get; set; }
    }
}
