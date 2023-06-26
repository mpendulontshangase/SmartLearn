//using Abp.Application.Services.Dto;
//using Abp.Application.Services;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Abp.Domain.Repositories;
//using SmartLearn.Domain;
//using SmartLearn.Services.Dto;

//namespace SmartLearn.Services.SubjectServices
//{
//    public class SubjectAppService: CrudAppService<Subject, SubjectDto, Guid, PagedAndSortedResultRequestDto>
//    {
//        private readonly IRepository<Subject, Guid> _subjectRepository;
//        public SubjectAppService(IRepository<Subject, Guid> subjectRepository) : base(subjectRepository)
//        {
//            _subjectRepository = subjectRepository;
//        }
//    }
//}
