using Microsoft.EntityFrameworkCore;
using SmartLearn.Domain.Attributes;
using SmartLearn.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLearn.Domain
{
    [Entity(TypeShortAlias = "Sl.Teacher")]
    [DiscriminatorValue("Sl.Teacher")]

    public class Teacher:Person
    {
        public virtual RefListSubject Subject { get; set; }
        public virtual RefListGrade Grade { get; set; }

    }
}
