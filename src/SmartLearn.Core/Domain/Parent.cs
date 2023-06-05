using SmartLearn.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLearn.Domain
{
    [Entity(TypeShortAlias = "Sl.Parent")]
    [DiscriminatorValue("Sl.Parent")]
    public class Parent :Person
    {
        public virtual Guid Parent_Id { get; set; }
        public virtual string Child_Relationship { get; set; }
        public virtual Next_Of_Kin? Next_Of_Kin { get; set; }

    }
}
