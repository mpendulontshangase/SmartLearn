﻿using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLearn.Domain
{
    public class StoredFile:Entity<Guid>
    {
        [NotMapped]
        public virtual IFormFile File { get; set; }
        public virtual string FileName { get; set; }
        public virtual string FileType { get; set; }
    }
}
