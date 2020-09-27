using System;
using AutoMapper;
using OffiRent.API.Domain.Models;
using OffiRent.API.Resources;
<<<<<<< HEAD
using OffiRent.API.Resources.Account;
=======
>>>>>>> feature/Departament-District-Office-models

namespace OffiRent.API.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
<<<<<<< HEAD
            CreateMap<SaveAccountResource, AccountResource>();
=======
            CreateMap<SaveCategoryResource, Category>();
>>>>>>> feature/Departament-District-Office-models
        }
    }
}
