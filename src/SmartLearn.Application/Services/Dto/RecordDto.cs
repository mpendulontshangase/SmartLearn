//using Abp.Application.Services.Dto;
//using Abp.AutoMapper;
//using Microsoft.AspNetCore.Http;
//using SmartLearn.Domain;
//using SmartLearn.Domain.Enum;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace SmartLearn.Services.Dto
//{
//    [AutoMap(typeof(Record))]

//    public class RecordDto:EntityDto<Guid>
//    {
        
//        public  DateTime UploadDate { get; set; }
//        public  IFormFile File { get; set; }

//        public RefListGrade Grade { get; set; }
//        public RefListSubject Subject { get; set; }
//        public Guid Teacher_Id { get; set; }
//    }
//}
