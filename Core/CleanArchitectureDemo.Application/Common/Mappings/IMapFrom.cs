using AutoMapper;

namespace CleanArchitectureDemo.Application.Common.Mappings
{
    /// <summary>
    ///  The interface has a single method called Mapping and 
    ///  it has a default implementation that simply calls the same CreateMap method 
    ///  we used above to define mapping configuration
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IMapFrom<T>
    {
        void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
    }
}
