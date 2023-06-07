using AutoMapper;
using SmartLearn.Domain;
using SmartLearn.Services.Dto;
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
                .ForMember(x => x.Teacher_Id, m => m.MapFrom(x => x.Teacher != null ? x.Teacher.Id : Guid.Empty));

            CreateMap<MessageDto, Message>()
                .ForMember(e => e.Id, d => d.Ignore());
        }

    }
}
