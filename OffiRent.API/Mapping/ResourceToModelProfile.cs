using System;
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
            CreateMap<SaveAccountResource, AccountResource>();
        }
    }
}
