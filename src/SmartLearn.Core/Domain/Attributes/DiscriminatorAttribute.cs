using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLearn.Domain.Attributes
{
    public class DiscriminatorAttribute : ;
    {

        public string DiscriminatorColumn { get; set; }
      public bool UseDiscriminator { get;set;} 
      public bool FilterUnkownDiscriminator { get;set; }

        public DiscriminatorAttribute()
        {
            DiscriminatorColumn = "Frwk_Discriminator";
            UseDiscriminator = true;
            FilterUnkownDiscriminator = false;

        }
    }
}
