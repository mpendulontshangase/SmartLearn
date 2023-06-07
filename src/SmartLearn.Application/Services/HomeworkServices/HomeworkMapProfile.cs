using AutoMapper;
using SmartLearn.Domain;
using SmartLearn.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLearn.Services.HomeworkServices
{
    public class HomeworkMapProfile : Profile
    {
        public HomeworkMapProfile()
        {
            CreateMap<HomeworkRecord, HomeworkRecordDto>()
                .ForMember(x => x.Teacher_Id, m => m.MapFrom(x => x.Teacher != null ? x.Teacher.Id : Guid.Empty));

            CreateMap<HomeworkRecordDto, HomeworkRecord>()
                .ForMember(e => e.Id, d => d.Ignore());
        }

    }
}
