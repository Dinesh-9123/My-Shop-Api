using AutoMapper;
using MyShopsDomain;
using MyShopsModels;
using MyShopsServices.Infrastructure.Builders.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShopsServices.Infrastructure.Builders
{
    public class AuthBuilder : IAuthBuilder
    {
        private IMapper _mapper;
        public AuthBuilder(IMapper mapper)
        {
            _mapper = mapper;
        }
        public AuthDto Build(SignUpModel authItem)
        {
            return _mapper.Map<AuthDto>(authItem);
        }

        public SignUpModel Build(AuthDto authItem)
        {
            return _mapper.Map<SignUpModel>(authItem);
        }
    }
}
