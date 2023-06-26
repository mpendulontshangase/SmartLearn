using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using SmartLearn.Domain;
using SmartLearn.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLearn.Services.Dto
{
    [AutoMap(typeof(Message))]

    public class MessageDto:EntityDto<Guid>
    {
        public  string Message_Description { get; set; }
        public  string Reply { get; set; }
       
        public List<int> Subject { get; set; }
        public List<string> SubjectDisplay { get; set; }

        public  RefListGrade Grade { get; set; }
        public string GradeName { get; set; }

    }
}
