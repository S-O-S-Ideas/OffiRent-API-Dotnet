using System;
using AutoMapper;
using OffiRent.API.Domain.Models;
using OffiRent.API.Resources;
<<<<<<< HEAD
=======

>>>>>>> a92fdd7fc6f25a560078d3cb7b4e5cadda3a5ff7
using OffiRent.API.Resources.Account;



<<<<<<< HEAD
=======


>>>>>>> a92fdd7fc6f25a560078d3cb7b4e5cadda3a5ff7
namespace OffiRent.API.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
<<<<<<< HEAD
            CreateMap <SaveAccountResource, AccountResource>();
            CreateMap<SaveCountryResource, CountryResource>();
            CreateMap<SaveCurrencyResource, CurrencyResource>();
=======

            CreateMap <SaveAccountResource, AccountResource>();

            CreateMap<SaveCountryResource, CountryResource>();
            CreateMap<SaveCurrencyResource, CurrencyResource>();

>>>>>>> a92fdd7fc6f25a560078d3cb7b4e5cadda3a5ff7
        }
    }
}
