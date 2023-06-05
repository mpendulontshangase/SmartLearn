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
    [AutoMap(typeof(TestRecord))]

    public class TestRecordDto:EntityDto<Guid>
    {
        //public  Guid Test_Id { get; set; }
        public  string Test_Description { get; set; }
        public  DateTime Test_Date { get; set; }
        public  int Test_Mark{ get; set; }
    }
}
