using AutoMapper;
using NetAngularList.Communication;
using NetAngularList.Domain;

namespace NetAngularList.Application
{
    public interface IMapperService
    {
        TDest Map<TDest>(object o);
    }

    public class MapperService : IMapperService
    {
        private readonly Mapper _mapper;

        public MapperService()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ClientInfo, ClientInfoDto>());
            _mapper = new Mapper(config);
        }

        public TDest Map<TDest>(object o)
        {
            return _mapper.Map<TDest>(o);
        }
    }
}