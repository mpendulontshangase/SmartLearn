using Abp.Domain.Entities.Auditing;
using SmartLearn.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLearn.Domain
{
    [Entity(TypeShortAlias = "Sl.NextOfKin")]
    [DiscriminatorValue("Sl.NextOfKin")]
    public class Next_Of_Kin:Person
    {
        public virtual Guid Next_OF_Kin_Id{ get; set; }
        public virtual string Relationship{ get; set; }

    }
}
