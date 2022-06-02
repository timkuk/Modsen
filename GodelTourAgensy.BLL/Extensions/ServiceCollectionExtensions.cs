using GodelTourAgensy.BLL.Interfaces;
using GodelTourAgensy.BLL.Services;
using Microsoft.Extensions.DependencyInjection;
using GodelTourAgensy.DAL.Interfaces;
using GodelTourAgensy.DAL.Repositories;

namespace GodelTourAgensy.BLL.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IAdditionalsService, AdditionalsService>();
            services.AddScoped<IClientsService, ClientsService>();
            services.AddScoped<IPackagesService, PackagesService>();
            services.AddScoped<IRoomsService, RoomsService>();
            services.AddScoped<IStringComparerService, StringComparerService>();
            services.AddScoped<IAdditionalServiceRepository, AdditionalServiceRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IRoomRepository, RoomRepository>();
            services.AddScoped<ITravelPackageRepository, TravelPackageRepository>();
        }
    }
}
