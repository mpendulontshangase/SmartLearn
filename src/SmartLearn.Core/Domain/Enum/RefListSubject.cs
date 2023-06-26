using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLearn.Domain.Enum
{
    [Flags]
    public enum RefListSubject : int
    {
        [Description("IsiZulu")]
        IsiZulu = 1,
        [Description("English")]
        English = 2,
        [Description("Mathematics")]
        Mathematics = 4,
        [Description("Life Orientation")]
        LO = 8,
        [Description("Technology")]
        Technology = 16,
        [Description("NS")]
        NS = 32,
        [Description("EMS")]
        EMS = 64,
        [Description("Sepedi")]
        Sepedi = 128,
        [Description("Afrikaans")]
        Afrikaans = 256,

    }

    
}
