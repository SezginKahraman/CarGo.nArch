using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CarGo.Application.Features.Users.Commands.Create;
using Core.Security.Entities;

namespace CarGo.Application.Features.Users.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<User, CreateUserCommand>().ReverseMap();
            CreateMap<User, CreatedUserResponse>().ReverseMap();
        }
    }
}
