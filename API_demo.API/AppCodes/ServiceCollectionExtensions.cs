using System.Reflection;

namespace API_demo.API.AppCodes
{
    public static class ServiceCollectionExtensions
    {
        public static void AddServicesFromAssembly(this IServiceCollection services, Assembly assembly)
        {
            var serviceTypes = assembly.GetTypes()
                .Where(t => t.IsClass && !t.IsAbstract && t.Name.EndsWith("Service"));

            foreach (var type in serviceTypes)
            {
                services.AddScoped(type); // Đăng ký chính service đó mà không cần interface
            }
        }
    }
}

