using MyShopsDomain;
using MyShopsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShopsServices.Infrastructure.Builders.Interfaces
{
    public interface IAuthBuilder
    {
        AuthDto Build(SignUpModel authItem);
        SignUpModel Build(AuthDto authItem);
    }
}
