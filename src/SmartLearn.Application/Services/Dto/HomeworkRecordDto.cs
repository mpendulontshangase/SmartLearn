using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Microsoft.AspNetCore.Http;
using SmartLearn.Domain;
using SmartLearn.Domain.Enum;
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
      
        public IFormFile File { get; set; }

        public RefListGrade Grade { get; set; }
        public string GradeName { get; set; }

        public List<int> Subject { get; set; }
        public List<string> SubjectDisplay { get; set; }
        public Guid Teacher_Id { get; set; }
 
    public string HomeworkDescription { get; set; }
        public DateTime Due_Date { get; set; }
      

    }
}
