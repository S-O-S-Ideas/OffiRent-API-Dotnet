using System;
using AutoMapper;
using OffiRent.API.Domain.Models;
<<<<<<< HEAD
using OffiRent.API.Extensions;
using OffiRent.API.Resources;
using OffiRent.API.Resources.Account;
=======
using OffiRent.API.Resources;
>>>>>>> feature/Departament-District-Office-models

namespace OffiRent.API.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
<<<<<<< HEAD
            CreateMap<Account, AccountResource>();
=======
            CreateMap<Category, CategoryResource>();
>>>>>>> feature/Departament-District-Office-models
        }
    }
}
