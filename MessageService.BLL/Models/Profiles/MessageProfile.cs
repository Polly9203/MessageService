using AutoMapper;
using MessageService.DAL.Models;

namespace MessageService.BLL.Models.Profiles
{
    public class MessageProfile : Profile
    {
        public MessageProfile()
        {
            CreateMap<MessageModel, MessageResult>();
        }
    }
}
