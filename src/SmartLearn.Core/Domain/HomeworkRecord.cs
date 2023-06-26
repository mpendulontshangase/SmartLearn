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
   
    public class HomeworkRecord:FullAuditedEntity<Guid>
    {
       

        public virtual string HomeworkDescription { get; set; }

        public virtual DateTime Due_Date { get; set; }
      

    
        public virtual RefListSubject Subject { get; set; }
        public virtual RefListGrade Grade { get; set; }
        public virtual StoredFile HomeworkFile { get; set; }
        public virtual Teacher Teacher { get; set; }



    }
}
