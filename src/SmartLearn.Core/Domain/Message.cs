using Abp.Domain.Entities.Auditing;
using SmartLearn.Domain.Attributes;
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
        public virtual DateTime Time_sent { get; set; }
        public virtual Teacher? Teacher { get; set; }
        public virtual Parent? Parent { get; set; }


    }
}
