using CarteiraPet.Domain.Interfaces.Repositories;
using CarteiraPet.Domain.Interfaces.Services;
using CarteiraPet.Infra;
using CarteiraPet.Infra.Domain.Data;
using CarteiraPet.Infra.Domain.Repositories;
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
            
            services.AddScoped<CarteiraPetContext>();
        }
    }
}

    
