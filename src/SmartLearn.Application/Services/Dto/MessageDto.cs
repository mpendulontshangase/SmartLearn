using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using SmartLearn.Domain;
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
        public  DateTime Time_sent { get; set; }
        public  Guid Teacher_Id { get; set; }
        public  Guid Parent_Id { get; set; }
    }
}
