using CarteiraPet.Domain.Interfaces.Repositories;
using CarteiraPet.Domain.Interfaces.Services;
using CarteiraPet.Domain.Interfaces.UnitOfWork;
using CarteiraPet.Infra;
using CarteiraPet.Infra.Domain.Repositories;
using CarteiraPet.Infra.Domain.UnitOfWork;
using CarteiraPet.Service;
using Microsoft.Extensions.DependencyInjection;

namespace CarteiraPet.Ioc
{
    public static class DependencyInjection
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IProfileRepository, ProfileRepository>();
            services.AddScoped<IPetRepository, PetRepository>();
            services.AddScoped<IIdentityUserRepository, IdentityUserRepository>();
            
            services.AddScoped<IProfileService, ProfileService>();
            services.AddScoped<IPetService, PetService>();
            services.AddScoped<IIdentityUserService, IdentityUserService>();
            services.AddScoped<IImageHandlerService, ImageHandlerService>();
            
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            
            //services.AddSingleton<CarteiraPetContext>();
        }
    }
}

    
