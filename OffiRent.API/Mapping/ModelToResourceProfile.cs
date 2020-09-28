using System;
using AutoMapper;
using OffiRent.API.Domain.Models;
using OffiRent.API.Extensions;
using OffiRent.API.Resources;

using OffiRent.API.Resources.Account;




namespace OffiRent.API.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {

            CreateMap <Account, AccountResource>();
            CreateMap <OffiUser, AccountResource>();

            CreateMap<Country, CountryResource>();
            CreateMap<Currency, CurrencyResource>();

        }
    }
}
