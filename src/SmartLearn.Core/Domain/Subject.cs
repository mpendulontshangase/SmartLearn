using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLearn.Domain
{
    public class Subject : FullAuditedEntity<Guid>
    {
        public virtual string Subject_Name { get; set; }

    }
}
