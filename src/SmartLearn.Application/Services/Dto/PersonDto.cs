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

        public int Age
        {
            get
            {
                if (!string.IsNullOrEmpty(IDNumber) && IDNumber.Length >= 6)
                {
                    string birthYearStr = IDNumber.Substring(0, 2);
                    int birthYear = int.Parse(birthYearStr);
                    int currentYear = DateTime.Now.Year % 100;
                    int age = currentYear - birthYear;
                    if (age < 0)
                        age += 100;
                    return age;
                }
                return 0; 
            }
        }

        public RefListGender? Gender { get; set; }

        public int UserId { get; set; }

        public string[] RoleNames { get; set; }

    }
}
