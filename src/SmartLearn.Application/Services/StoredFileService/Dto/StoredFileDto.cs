using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using SmartLearn.Domain;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLearn.Services.StoredFileService.Dto
{
    [AutoMap(typeof(StoredFile))]
    public class StoredFileDto : EntityDto<Guid?>
    {
        public IFormFile File { get; set; }
        public  string FileName { get; set; }
    }
}
