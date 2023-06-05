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
    [AutoMap(typeof(Teacher))]

    public class TeacherDto : PersonDto
    {

        public RefListSubject Teacher_Subject { get; set; }
        public RefListGrade Teacher_Grade { get; set; }

    }
    
}
