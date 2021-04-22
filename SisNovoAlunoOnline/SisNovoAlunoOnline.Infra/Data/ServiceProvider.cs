using Microsoft.Extensions.DependencyInjection;
using SisNovoAlunoOnline.Infra.Data.Interface;
using SisNovoAlunoOnline.Infra.Data.Interfaces;
using SisNovoAlunoOnline.Infra.Data.Repository;
using System.Linq;

namespace SisNovoAlunoOnline.Infra.Data
{
    public static class ServiceProvider
    {
        public static void Register(IServiceCollection services)
        {
            //System.Reflection.Assembly.GetExecutingAssembly()
            //.GetTypes()
            //.Where(item => item.GetInterfaces()
            //.Where(i => i.IsGenericType).Any(i => i.GetGenericTypeDefinition() == typeof(IBaseRepository<>)) && !item.IsAbstract && !item.IsInterface)
            //.ToList()
            //.ForEach(assignedTypes =>
            //{
            //    var serviceType = assignedTypes.GetInterfaces().First(i => i.GetGenericTypeDefinition() == typeof(IBaseRepository<>));
            //    services.AddScoped(serviceType, assignedTypes);
            //});
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<ITelefoneUserRepository, TelefoneUserRepository>();
        }
    }
}
