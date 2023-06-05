using Abp.Application.Services;
using Abp.Domain.Repositories;
using AutoMapper;
using SmartLearn.Domain;
using SmartLearn.Services.Dto;
using SmartLearn.Services.PersonServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLearn.Services.TeacherServices
{
    public class TeacherAppService : ApplicationService, ITeacherAppService
    {
        private readonly IRepository<Teacher, Guid> _teacherRepository;

        public TeacherAppService(IRepository<Teacher, Guid> teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        public async Task<TeacherDto> CreateAsync(TeacherDto input)
        {
            var teacher = ObjectMapper.Map<Teacher>(input);
            await _teacherRepository.InsertAsync(teacher);
            return ObjectMapper.Map<TeacherDto>(teacher);
        }

        public async Task<List<TeacherDto>> GetAllAsync()
        {
            var teachers = await _teacherRepository.GetAllListAsync();
            return ObjectMapper.Map<List<TeacherDto>>(teachers);
        }

        public async Task<TeacherDto> GetAsync(Guid id)
        {
            var teacher = await _teacherRepository.GetAsync(id);
            return ObjectMapper.Map<TeacherDto>(teacher);
        }

        public async Task UpdateAsync(TeacherDto input)
        {
            var teacher = await _teacherRepository.GetAsync(input.Id);
            ObjectMapper.Map(input, teacher);
            await _teacherRepository.UpdateAsync(teacher);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _teacherRepository.DeleteAsync(id);
        }
    }
}