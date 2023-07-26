using AutoMapper;
using MessageService.BLL.Models.Profiles;

namespace MessageService.BLL
{
    public static class AutoMapperInitialization
    {
        public static IMapper CreateMapper()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AllowNullCollections = true;
                cfg.AllowNullDestinationValues = true;

                cfg.AddProfile<MessageProfile>();
            }).CreateMapper();
        }
    }
}
