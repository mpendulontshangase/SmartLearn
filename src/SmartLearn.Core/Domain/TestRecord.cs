using SmartLearn.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLearn.Domain
{
    [Entity(TypeShortAlias = "Sl.TestRecord")]
    [DiscriminatorValue("Sl.TestRecord")]
    public class TestRecord:Record
    {
        public virtual Guid Test_Id { get; set; }
        public virtual string Test_Description { get; set; }
        public virtual DateTime Test_Date { get; set; }
        public virtual int Test_Mark{ get; set; }
        public virtual Teacher Teacher{ get; set; }

    }
}
