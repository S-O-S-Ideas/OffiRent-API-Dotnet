using System;
using AutoMapper;
using OffiRent.API.Domain.Models;
using OffiRent.API.Resources;
<<<<<<< HEAD
using OffiRent.API.Resources.Account;

=======


>>>>>>> feature/Currency-CountryCurrency-Country
namespace OffiRent.API.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
<<<<<<< HEAD
            CreateMap <SaveAccountResource, AccountResource>();
=======
            CreateMap<SaveCountryResource, CountryResource>();
            CreateMap<SaveCurrencyResource, CurrencyResource>();
>>>>>>> feature/Currency-CountryCurrency-Country
        }
    }
}
