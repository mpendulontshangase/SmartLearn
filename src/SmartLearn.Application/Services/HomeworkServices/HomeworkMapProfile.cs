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

namespace SmartLearn.Services.HomeworkServices
{
    public class HomeworkMapProfile : Profile
    {
        public HomeworkMapProfile()
        {
            CreateMap<HomeworkRecord, HomeworkRecordDto>()
                .ForMember(x => x.Teacher_Id, m => m.MapFrom(x => x.Teacher != null ? x.Teacher.Id : Guid.Empty))
                .ForMember(x => x.GradeName, m => m.MapFrom(x => x.Grade.GetEnumDescription()))
                .ForMember(x => x.SubjectDisplay, m => m.MapFrom(x => RefListHelper.GetIndividualSubjects(x.Subject)))
                .ForMember(x => x.Subject, x => x.Ignore());

                //.ForMember(x => x.Subject, m => m.MapFrom(x => x.Subject != null && x.Subject != 0 ? x.Subject.GetEnumDescription() : null));



            CreateMap<HomeworkRecordDto, HomeworkRecord>()
                .ForMember(e => e.Id, d => d.Ignore())
                .ForMember(a => a.Subject, opt => opt.MapFrom(b => (RefListSubject)RefListHelper.SetMultiValueReferenceList(b.Subject)));
        }

    }
}
