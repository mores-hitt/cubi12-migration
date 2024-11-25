using Google.Protobuf.Collections;

namespace user_microservice.Src.Services.Interfaces
{
    public interface IMapperService
    {
        public TDestination Map<TSource, TDestination>(TSource source);

        public List<TDestination> MapList<TSource, TDestination>(List<TSource> sourceItems);

        public RepeatedField<TDestination> MapRepeatedField<TSource, TDestination>(List<TSource> sourceItems);
    }
}