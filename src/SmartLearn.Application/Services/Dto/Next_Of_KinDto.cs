using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using SmartLearn.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLearn.Services.Dto
{
    [AutoMap(typeof(Next_Of_Kin))]

    public class Next_Of_KinDto: PersonDto
    {

        public  string Relationship { get; set; }

        public Guid Next_Of_Kin_Id { get; set; } = Guid.NewGuid();




    }
}
