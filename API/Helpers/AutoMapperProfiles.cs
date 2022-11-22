using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Extensions;
using AutoMapper;

namespace API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            Console.WriteLine("\n\n>>>> (API-Helpers)AutoMapperProfiles - Constructor() - create map - <AppUser, MemberDto>");
            CreateMap<AppUser, MemberDto>()
                    .ForMember( dest => dest.PhotoUrl, opt => opt.MapFrom(src => 
                                            src.Photos.FirstOrDefault(x => x.IsMain).Url
                                                                        )
                               )
                    .ForMember(dest => dest.Age, opt => opt.MapFrom(src =>src.DateOfBirth.CalculateAge()));

            Console.WriteLine("\n>>>> (API-Helpers)AutoMapperProfiles - Constructor() - create map - <Photo, PhotoDto>");
            CreateMap<Photo, PhotoDto>();

            Console.WriteLine("\n>>>> (API-Helpers)AutoMapperProfiles - Constructor() - create map - <MemberUpdateDto,AppUser>");
            CreateMap<MemberUpdateDto,AppUser> ();

            Console.WriteLine("\n>>>> (API-Helpers)AutoMapperProfiles - Constructor() - create map - <RegisterDto,AppUser>");
            CreateMap<RegisterDto,AppUser> ();


        }
    }
}