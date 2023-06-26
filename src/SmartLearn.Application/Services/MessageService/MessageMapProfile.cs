using AutoMapper;
using SmartLearn.Domain;
using SmartLearn.Domain.Enum;
using SmartLearn.Services.Dto;
using SmartLearn.Services.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLearn.Services.MessageService
{
    public class MessageMapProfile : Profile
    {
        public MessageMapProfile()
        {
            CreateMap<Message, MessageDto>()
                  .ForMember(x => x.GradeName, m => m.MapFrom(x => x.Grade != null && x.Grade != 0 ? x.Grade.GetEnumDescription() : null))
                .ForMember(x => x.SubjectDisplay, m => m.MapFrom(x => RefListHelper.GetIndividualSubjects(x.Subject)))
                 .ForMember(x => x.Subject, x => x.Ignore());
                

            CreateMap<MessageDto, Message>()
                .ForMember(e => e.Id, d => d.Ignore())
                .ForMember(a => a.Subject, opt => opt.MapFrom(b => (RefListSubject)RefListHelper.SetMultiValueReferenceList(b.Subject))); 
        }

    }
}
