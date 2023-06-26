//using AutoMapper;
//using SmartLearn.Authorization.Users;
//using SmartLearn.Domain;
//using SmartLearn.Services.Dto;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace SmartLearn.Services.TestRecordServices
//{
//    public class TestRecordMapProfile : Profile
//    {
//        public TestRecordMapProfile()
//        {
//            CreateMap<TestRecord, TestRecordDto>()
//                .ForMember(x => x.Teacher_Id, m => m.MapFrom(x => x.Teacher != null ? x.Teacher.Id : Guid.Empty));

//            //CreateMap<TestRecordDto, TestRecord>()
//            //    .ForMember(e => e.Id, d => d.Ignore());
//        }

//    }
//}
