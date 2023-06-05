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
    [AutoMap(typeof(Parent))]

    public class ParentDto: PersonDto
    {
       
        public virtual string Child_Relationship { get; set; }
        public virtual Guid? Next_Of_Kin_Id { get; set; }
       


    }
}
