using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLearn.Domain.Enum
{
    public enum RefListSubject : int
    {
        [Description("IsiZulu Hl")]
        IsiZulu = 1,
        [Description("English FAL")]
        English = 2,
        [Description("Life Orientation")]
        LO = 3,
        [Description("Mathematics")]
        Mathematics = 4,
        [Description("Life Sciences")]
        LifeSciences = 5,
        [Description("Physical Sciences")]
        PhysicalSciences = 6,
        [Description("Accounting")]
        Accounting = 7,
        [Description("History")]
        History = 8,
        [Description("Tourism")]
        Tourism = 9,
        [Description("Geograph")]
        Geograph = 10,
        [Description("Commerce")]
        Commerce = 11,
        [Description("Business Study")]
        BusinessStudy = 12
    }
}
