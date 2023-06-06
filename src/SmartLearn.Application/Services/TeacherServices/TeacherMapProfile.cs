﻿using AutoMapper;
using SmartLearn.Authorization.Users;
using SmartLearn.Domain;
using SmartLearn.Services.Dto;
using SmartLearn.Services.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLearn.Services.TeacherServices
{
    public class TeacherMapProfile : Profile
    {
        public TeacherMapProfile()
        {
            CreateMap<Teacher, TeacherDto>()
                 .ForMember(x => x.UserId, m => m.MapFrom(x => x.User != null ? x.User.Id : (long?)null))
                .ForMember(x => x.Gender, m => m.MapFrom(x => x.Gender != null ? x.Gender.GetEnumDescription() : null)); ;

            CreateMap<TeacherDto, User>()
                .ForMember(x => x.Name, m => m.MapFrom(x => x.Name))
                .ForMember(x => x.PhoneNumber, m => m.MapFrom(x => x.PhoneNumber))
                .ForMember(x => x.EmailAddress, m => m.MapFrom(x => x.EmailAddress))
                .ForMember(x => x.FullName, m => m.MapFrom(x => x.Name + " " + x.Surname))
                .ForMember(x => x.Password, m => m.MapFrom(x => x.Password))
                .ForMember(x => x.Surname, m => m.MapFrom(x => x.Surname))
                .ForMember(x => x.UserName, m => m.MapFrom(x => x.EmailAddress));

            CreateMap<TeacherDto, User>()
                .ForMember(e => e.Id, d => d.Ignore());

            CreateMap<TeacherDto, Teacher>()
                .ForMember(e => e.Id, d => d.Ignore());
        }

    }
}
