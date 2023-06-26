using Abp.Application.Services;
using Abp.Domain.Repositories;
using AutoMapper;
using SmartLearn.Domain;
using SmartLearn.Domain.Enum;
using SmartLearn.Services.Dto;
using SmartLearn.Services.Helper;
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
     

        public MessageAppService (IRepository<Message, Guid> messageRepository)
        {
            _messageRepository = messageRepository;
    
        }

        public async Task<MessageDto> CreateAsync(MessageDto input)
        {

            var message = ObjectMapper.Map<Message>(input);
      
            await _messageRepository.InsertAsync(message);
         

            var result = ObjectMapper.Map<MessageDto>(message);
            var decomposed = RefListHelper.DecomposeIntoBitFlagComponents((int)message.Subject);
            var lists = new List<string>();

            foreach (var item in decomposed)
            {
                var name = RefListHelper.GetEnumDescription((RefListSubject)item);
            }

            result.SubjectDisplay = lists;
            result.Subject = decomposed.ToList();

            return result;

        }

        public async Task<List<MessageDto>> GetAllAsync()
        {
            var messages= await _messageRepository.GetAllListAsync();
            return ObjectMapper.Map<List<MessageDto>>(messages);
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
