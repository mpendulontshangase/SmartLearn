using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using SmartLearn.Domain;
using SmartLearn.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLearn.Services.Dto
{
    [AutoMap(typeof(Person))]

    public class PersonDto:EntityDto<Guid>
    {
        public  string Name { get; set; }
        public  string SecondName { get; set; }

        public  string Surname { get; set; }

        [StringLength(13)]
        public  string IDNumber { get; set; }
        public  string Username { get; set; }

        public string Password { get; set; }


        public string PhoneNumber { get; set; }

        public  string EmailAddress { get; set; }

        public string StreetAddress { get; set; }

        public  string Age { get; set; }

        public RefListGender? Gender { get; set; }

        public int UserId { get; set; }

        public string[] RoleNames { get; set; }

    }
}
