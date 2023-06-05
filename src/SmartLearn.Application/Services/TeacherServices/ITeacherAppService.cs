using Abp.Application.Services;
using SmartLearn.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLearn.Services.TeacherServices
{
    public interface ITeacherAppService : IApplicationService
    {
        Task<TeacherDto> CreateAsync(TeacherDto input);
        Task<List<TeacherDto>> GetAllAsync();
        Task<TeacherDto> GetAsync(Guid id);
        Task UpdateAsync(TeacherDto input);
        Task DeleteAsync(Guid id);
        //Task<List<TeacherDto>> GetTeachersBySubjectAsync(string subject);
        //Task<List<TeacherDto>> GetTeachersByGradeAsync(string grade);


    }
}
