using AutoMapper;
using L2AccountPanel.Core.Domain;
using L2AccountPanel.Infrastructure.DTO;

namespace L2AccountPanel.Infrastructure.Mappers
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize()
             =>new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Account,AccountDTO>();
            })
            .CreateMapper();
        
}
}