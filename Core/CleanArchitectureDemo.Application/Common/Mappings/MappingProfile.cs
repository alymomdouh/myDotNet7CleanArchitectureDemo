using AutoMapper;
using System.Reflection;

namespace CleanArchitectureDemo.Application.Common.Mappings
{
    /// <summary>
    /// We can simply implement IMapForm<T> interface on any class we want to map with the T class 
    /// and AutoMapper will do the rest. Once we have all those classes ready to map, 
    /// we don’t want to register them all manually so let’s add some automation in our MappingProfile class we created above.
    
    /// In the belaw code, we are using the .NET reflection framework 
    /// to scan the assembly and looking for all classes that are implementing the IMapFrom interface. 
    /// Once we have all those types available, we are simply invoking their Mapping method. 
    /// We have already seen the default implementation of the Mapping method above 
    /// which is calling the CreateMap method for the current type
    /// </summary>
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            ApplyMappingsFromAssembly(Assembly.GetExecutingAssembly());
        }

        private void ApplyMappingsFromAssembly(Assembly assembly)
        {
            var mapFromType = typeof(IMapFrom<>);

            var mappingMethodName = nameof(IMapFrom<object>.Mapping);

            bool HasInterface(Type t) => t.IsGenericType && t.GetGenericTypeDefinition() == mapFromType;

            var types = assembly.GetExportedTypes().Where(t => t.GetInterfaces().Any(HasInterface)).ToList();

            var argumentTypes = new Type[] { typeof(Profile) };

            foreach (var type in types)
            {
                var instance = Activator.CreateInstance(type);

                var methodInfo = type.GetMethod(mappingMethodName);

                if (methodInfo != null)
                {
                    methodInfo.Invoke(instance, new object[] { this });
                }
                else
                {
                    var interfaces = type.GetInterfaces().Where(HasInterface).ToList();

                    if (interfaces.Count > 0)
                    {
                        foreach (var @interface in interfaces)
                        {
                            var interfaceMethodInfo = @interface.GetMethod(mappingMethodName, argumentTypes);

                            interfaceMethodInfo.Invoke(instance, new object[] { this });
                        }
                    }
                }
            }
        }
    }
}
