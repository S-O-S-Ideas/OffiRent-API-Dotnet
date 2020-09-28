using System;
using AutoMapper;
using OffiRent.API.Domain.Models;
using OffiRent.API.Resources;


namespace OffiRent.API.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveCountryResource, CountryResource>();
            CreateMap<SaveCurrencyResource, CurrencyResource>();
        }
    }
}
