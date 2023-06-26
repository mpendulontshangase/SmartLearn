//using Abp.Domain.Entities.Auditing;
//using SmartLearn.Domain.Attributes;
//using SmartLearn.Domain.Enum;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations.Schema;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace SmartLearn.Domain
//{
//    [Entity(TypeShortAlias = "Sl.Record")]
//    [Table("Sl.Records")]
//    [DiscriminatorValue("Sl.Record")]

//    public class Homework:FullAuditedEntity<Guid>
//    {
       
//        public virtual DateTime Upload_Date{ get; set; }
//        public virtual RefListSubject Subject { get; set; }
//        public virtual RefListGrade Grade{ get; set; }
//        public virtual StoredFile File { get; set; }
//        public virtual Teacher Teacher { get; set; }

//    }
//}
