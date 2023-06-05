using Abp.Domain.Entities.Auditing;
using SmartLearn.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLearn.Domain
{
    [Entity(TypeShortAlias = "Sl.Record")]
    [Table("Sl.Records")]
    [DiscriminatorValue("Sl.Record")]

    public class Record:FullAuditedEntity<Guid>
    {
       
        public virtual DateTime Upload_Date{ get; set; }
        public virtual string Subject { get; set; }
        public virtual string Grade{ get; set; }
        public virtual Teacher Teacher { get; set; }

    }
}
