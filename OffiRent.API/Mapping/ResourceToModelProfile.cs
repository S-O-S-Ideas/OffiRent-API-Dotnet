using AutoMapper;
using OffiRent.API.Domain.Models;
using OffiRent.API.Resources;

using OffiRent.API.Resources.Account;


namespace OffiRent.API.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveAccountResource, Account>();
            CreateMap<SaveCountryResource, CountryResource>();
            CreateMap<SaveCurrencyResource, CurrencyResource>();
            CreateMap<SaveDepartamentResource, DepartamentResource>();
            CreateMap<SaveDistrictResource, DistrictResource>();
            CreateMap<SaveOfficeResource, Office>();
        }
    }
}
