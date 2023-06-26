using AutoMapper;
using SmartLearn.Authorization.Users;
using SmartLearn.Domain;
using SmartLearn.Domain.Enum;
using SmartLearn.Services.Dto;
using SmartLearn.Services.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
                .ForMember(x => x.Gender, m => m.MapFrom(x => x.Gender != null && x.Gender != 0 ? x.Gender.GetEnumDescription() : null))
                .ForMember(x => x.SubjectDisplay, m => m.MapFrom(x => RefListHelper.GetIndividualSubjects(x.Subject)))
                 .ForMember(x => x.GradeName, m => m.MapFrom(x => x.Grade != null && x.Grade != 0 ? x.Grade.GetEnumDescription() : null))
                 .ForMember(x => x.Subject, x => x.Ignore());



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
                .ForMember(e => e.Id, d => d.Ignore())
                .ForMember(a => a.Subject, opt => opt.MapFrom(b => (RefListSubject)RefListHelper.SetMultiValueReferenceList(b.Subject)));
        }

    }
}
