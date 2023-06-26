using Abp.Application.Services;
using Abp.Dependency;
using Abp.Domain.Repositories;
using AutoMapper;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartLearn.Domain;
using SmartLearn.Domain.Enum;
using SmartLearn.Services.Dto;
using SmartLearn.Services.Helper;
using SmartLearn.Services.StoredFileService;
using SmartLearn.Services.StoredFileService.Dto;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SmartLearn.Services.HomeworkServices
{
    public class HomeworkAppService : ApplicationService, IHomeworkAppService
    {
        private readonly IRepository<HomeworkRecord, Guid> _homeworkRepository;
        private readonly IRepository<Teacher, Guid> _teacherRepository;

        public HomeworkAppService(IRepository<HomeworkRecord, Guid> homeworkRepository, IRepository<Teacher, Guid> teacherRepository)
        {
            _homeworkRepository = homeworkRepository;
            _teacherRepository = teacherRepository;
        }


        [Consumes("multipart/form-data")]

        public async Task<HomeworkRecordDto> CreateAsync([FromForm]HomeworkRecordDto input)
        {

            if (!Utils.IsImage(input.File))
                throw new ArgumentException("The file is not a valid image.");
            var homework = ObjectMapper.Map<HomeworkRecord>(input);
           
         
            if (input.File != null)
            {
                var storedFileService = IocManager.Instance.Resolve<StoredFileAppService>();
                var storedFileDto = new StoredFileDto() { File = input.File };
                homework.HomeworkFile = await storedFileService.CreateStoredFile(storedFileDto);
            }
            homework.Teacher = _teacherRepository.Get(input.Teacher_Id);
            homework = await _homeworkRepository.InsertAsync(homework);
            

            var result = ObjectMapper.Map<HomeworkRecordDto>(homework);
            var decomposed = RefListHelper.DecomposeIntoBitFlagComponents((int)homework.Subject);
            var lists = new List<string>();

            foreach (var item in decomposed)
            {
                var name = RefListHelper.GetEnumDescription((RefListSubject)item);
            }

            result.SubjectDisplay = lists;
            result.Subject = decomposed.ToList();

            return result;
        }

        public async Task<List<HomeworkRecordDto>> GetAllAsync()
        {
            var homeworks = await _homeworkRepository.GetAllIncluding(x => x.Teacher).ToListAsync();


            return ObjectMapper.Map<List<HomeworkRecordDto>>(homeworks);
        }

        public async Task<HomeworkRecordDto> GetAsync(Guid id)
        {
            var homework = await _homeworkRepository.GetAsync(id);
            return ObjectMapper.Map<HomeworkRecordDto>(homework);
        }

        public async Task UpdateAsync(HomeworkRecordDto input)
        {
            var homework = await _homeworkRepository.GetAsync(input.Id);
            ObjectMapper.Map(input, homework);
            await _homeworkRepository.UpdateAsync(homework);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _homeworkRepository.DeleteAsync(id);
        }
    }
}
