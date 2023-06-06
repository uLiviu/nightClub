using AutoMapper;

namespace nightClub.Helpers
{
    public static class MappingHelper
    {
        public static IMapper Configure<TSource, TDestination>()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TSource, TDestination>();
            });

            IMapper mapper = config.CreateMapper();
            return mapper;
        }
    }
}
