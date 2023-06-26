using Abp.Domain.Entities.Auditing;
using SmartLearn.Domain.Attributes;
using SmartLearn.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLearn.Domain
{
    [Entity(TypeShortAlias = "Sl.Message")]
    public class Message:FullAuditedEntity<Guid>
    {
        public virtual string Message_Description { get; set; }
        public virtual string Reply { get; set; }
       
        public virtual RefListSubject Subject { get; set; }
        public virtual RefListGrade? Grade { get; set; }
       


    }
}
