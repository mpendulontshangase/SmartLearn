using AutoMapper;
using SmartLearn.Authorization.Users;
using SmartLearn.Domain;
using SmartLearn.Services.Dto;
using SmartLearn.Services.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLearn.Services.NextOfKinServices
{
    public class Next_Of_KinMapProfile : Profile
    {
        public Next_Of_KinMapProfile()
        {
            CreateMap<Next_Of_Kin, Next_Of_KinDto>()
                 .ForMember(x => x.UserId, m => m.MapFrom(x => x.User != null ? x.User.Id : (long?)null))
                .ForMember(x => x.Gender, m => m.MapFrom(x => x.Gender != null ? x.Gender.GetEnumDescription() : null)); ;

            CreateMap<Next_Of_KinDto, User>()
                .ForMember(x => x.Name, m => m.MapFrom(x => x.Name))
                .ForMember(x => x.PhoneNumber, m => m.MapFrom(x => x.PhoneNumber))
                .ForMember(x => x.EmailAddress, m => m.MapFrom(x => x.EmailAddress))
                .ForMember(x => x.FullName, m => m.MapFrom(x => x.Name + " " + x.Surname))
                .ForMember(x => x.Password, m => m.MapFrom(x => x.Password))
                .ForMember(x => x.Surname, m => m.MapFrom(x => x.Surname))
                .ForMember(x => x.UserName, m => m.MapFrom(x => x.EmailAddress));

            CreateMap<Next_Of_KinDto, User>()
                .ForMember(e => e.Id, d => d.Ignore());

            CreateMap<Next_Of_KinDto, Next_Of_Kin>()
                .ForMember(e => e.Id, d => d.Ignore());
        }

    }
}
