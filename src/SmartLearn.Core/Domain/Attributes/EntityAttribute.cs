using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLearn.Domain.Attributes
{
    public class EntityAttribute: Attribute
    {
        public string FriendName { get; set; }
        public string TypeShortAlias { get; set; }
    }
}
