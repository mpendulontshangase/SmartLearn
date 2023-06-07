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
        public RefListSubject Learner_Subject { get; set; }
        public  RefListGrade Learner_Grade { get; set; }
        public Guid Parent_Id { get; set; }
    

    }
}
