using Abp.Application.Services;
using Abp.Domain.Repositories;
using AutoMapper;
using SmartLearn.Domain;
using SmartLearn.Services.Dto;
using SmartLearn.Services.HomeworkServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLearn.Services.MessageService
{
    public class MessageAppService : ApplicationService, IMessageAppService
    {
        private readonly IRepository<Message, Guid> _messageRepository;
        private readonly IRepository<Teacher, Guid> _teacherRepository;

        public MessageAppService (IRepository<Message, Guid> messageRepository, IRepository<Teacher, Guid> teacherRepository)
        {
            _messageRepository = messageRepository;
            _teacherRepository = teacherRepository;
        }

        public async Task<MessageDto> CreateAsync(MessageDto input)
        {

            var message = ObjectMapper.Map<Message>(input);
            //message.Teacher = _teacherRepository.Get(input.Teacher_Id);
            await _messageRepository.InsertAsync(message);
            return ObjectMapper.Map<MessageDto>(message);
        }

        public async Task<List<MessageDto>> GetAllAsync()
        {
            var homeworks = await _messageRepository.GetAllListAsync();
            return ObjectMapper.Map<List<MessageDto>>(homeworks);
        }

        public async Task<MessageDto> GetAsync(Guid id)
        {
            var message = await _messageRepository.GetAsync(id);
            return ObjectMapper.Map<MessageDto>(message);
        }

        public async Task UpdateAsync(MessageDto input)
        {
            var message = await _messageRepository.GetAsync(input.Id);
            ObjectMapper.Map(input, message);
            await _messageRepository.UpdateAsync(message);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _messageRepository.DeleteAsync(id);
        }
    }
}
