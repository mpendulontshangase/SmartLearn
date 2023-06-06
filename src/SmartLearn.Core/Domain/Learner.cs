using SmartLearn.Domain.Attributes;
using SmartLearn.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLearn.Domain
{
    [Entity(TypeShortAlias = "Sl.Learner")]
    [DiscriminatorValue("Sl.Learner")]
    public class Learner :Person
    {
        public virtual RefListSubject Learner_Subject { get; set; }
        public virtual RefListGrade Learner_Grade { get; set; }

        public virtual Parent Parent { get; set; }
    }
}
