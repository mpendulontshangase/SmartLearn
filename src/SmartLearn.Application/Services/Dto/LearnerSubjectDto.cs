using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLearn.Services.Dto
{
    public class LearnerSubjectDto:EntityDto<Guid>
    {
        public Guid Learner_Id { get; set; }
        public Guid Subject_Id { get; set; }
    }
}
