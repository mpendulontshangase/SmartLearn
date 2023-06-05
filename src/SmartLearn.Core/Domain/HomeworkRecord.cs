using SmartLearn.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLearn.Domain
{ 
    [Entity(TypeShortAlias = "Sl.HomeworkRecord")]
    [DiscriminatorValue("Sl.HomeworkRecord")]
    public class HomeworkRecord:Record
    {
        public virtual Guid Homework_Id { get; set; }

        public virtual string Homework_Description { get; set; }

        public virtual DateOnly Due_Date { get; set; }
        public virtual int Homework_Mark { get; set; }


    }
}
