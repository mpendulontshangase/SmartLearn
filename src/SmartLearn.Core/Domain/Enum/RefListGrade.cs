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
        GradeEight = 8,
        [Description("Grade 9")]
        GradeNine = 9,
        [Description("Grade 10")]
        GradeTen = 10,
        [Description("Grade 11")]
        GradeELeven = 11,
        [Description("Grade 12")]
        GradeTwelve = 12
    }
}
