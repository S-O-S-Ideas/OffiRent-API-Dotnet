using System;
using AutoMapper;
using OffiRent.API.Domain.Models;
using OffiRent.API.Extensions;
using OffiRent.API.Resources;

namespace OffiRent.API.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
         CreateMap<Account, AccountResource>();
        }
    }
}
