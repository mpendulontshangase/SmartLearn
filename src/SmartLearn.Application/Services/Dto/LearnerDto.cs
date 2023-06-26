using Abp.Application.Services.Dto;
using SmartLearn.Domain.Enum;
using SmartLearn.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.AutoMapper;
using System.ComponentModel.DataAnnotations;

namespace SmartLearn.Services.Dto
{
    [AutoMap(typeof(Learner))]
    public class LearnerDto:PersonDto
    {
        public List<int> Subject { get; set; }

        public List<string> SubjectDisplay { get; set; }

        public  RefListGrade Grade { get; set; }
        public  string GradeName { get; set; }

        public Guid Parent_Id { get; set; }
    

    }
}
