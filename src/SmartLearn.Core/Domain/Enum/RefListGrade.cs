using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLearn.Domain.Enum
{
    public enum RefListGrade : int
    {
        [Description("Grade 8")]
        Grade8 = 1,
        [Description("Grade 9")]
        Grade9 = 2,
        [Description("Grade 10")]
        Grade10 = 3,
        [Description("Grade 11")]
        Grade11 = 4,
        [Description("Grade 12")]
        Grade12 = 5
    }
}
