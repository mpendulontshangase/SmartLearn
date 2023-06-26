using Abp.Domain.Entities.Auditing;
using SmartLearn.Authorization.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartLearn.Domain.Enum;
using Microsoft.EntityFrameworkCore.Infrastructure;
using SmartLearn.Domain.Attributes;

namespace SmartLearn.Domain
{
    [Entity(TypeShortAlias="Sl.Person")]
    [Table("Sl.Persons")]
    [DiscriminatorValue("Sl.Person")]
    public class Person:FullAuditedEntity<Guid>
    {
        public virtual string Name { get; set; }
        public virtual string SecondName { get; set; }
    
        public virtual string Surname { get; set; }

     
        [StringLength(13)]
        public virtual string IDNumber { get; set; }
        public virtual string Passport { get; set; }

        public virtual string Username { get; set; }


        public virtual string Password { get; set; }


        public virtual string PhoneNumber { get; set; }
    
        public virtual string EmailAddress { get; set; }

        public virtual string StreetAddress { get; set; }
      

        public virtual string Age { get; set; }
        public virtual DateTime DateOfBirth { get; set; }

        public virtual RefListGender? Gender { get; set; }
     
        public User User { get; set; }


        //[NotMapped]
        //public virtual string[] RoleNames { get; set; }
    }
}

