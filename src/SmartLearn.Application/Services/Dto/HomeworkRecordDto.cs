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
    [AutoMap(typeof(HomeworkRecord))]

    public class HomeworkRecordDto:EntityDto<Guid>
    {
        //public  Guid Homework_Id { get; set; }
        public string Homework_Description { get; set; }
        public DateTime Due_Date { get; set; }
        public  int Homework_Mark { get; set; }

    }
}
