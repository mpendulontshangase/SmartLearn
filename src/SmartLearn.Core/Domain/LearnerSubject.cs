using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLearn.Domain
{
    public class LearnerSubject:FullAuditedEntity<Guid>
    {
        public virtual Learner Learner { get; set; }
        public virtual Subject Subject { get; set; }
    }
}
