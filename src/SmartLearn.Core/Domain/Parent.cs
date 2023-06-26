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
      
     

      

    }
}
