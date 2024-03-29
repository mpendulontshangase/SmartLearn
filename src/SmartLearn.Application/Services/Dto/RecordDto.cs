﻿using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using SmartLearn.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLearn.Services.Dto
{
    [AutoMap(typeof(Record))]

    public class RecordDto:EntityDto<Guid>
    {
        
        public  DateTime UploadDate { get; set; }
        
        public  string Grade { get; set; }
        public  string Subject { get; set; }
        public Guid Teacher_Id { get; set; }
    }
}
