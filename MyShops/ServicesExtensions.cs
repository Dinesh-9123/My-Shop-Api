using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MyShops.Authentication;
using MyShops.Controllers;
using MyShopsData;
using MyShopsData.Interfaces;
using MyShopsData.Repositories;
using MyShopsModels;
using MyShopsServices;
using MyShopsServices.Infrastructure.Builders.MapperProfiles;
using MyShopsServices.Infrastructure.Interfaces;
using Scrutor;
using System.Text;
using System.Text.Json.Serialization;

namespace MyShops
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddCustomMvc(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                                  builder => builder
                                             .SetIsOriginAllowed((host) => true)
                                             .AllowAnyMethod()
                                             .AllowAnyHeader()
                                             .AllowCredentials());
            });
            services.AddHttpContextAccessor();

            return services;
        }
        public static IServiceCollection AddCustomAssemblies(this IServiceCollection services)
        {
            var types = new List<Type>() {
                typeof(IProductsService),
                typeof(ProductsService),
                typeof(IAuthRepository),
                typeof(AuthRepository),
                typeof(IDatabaseFactory),
                typeof(DatabaseFactory),
                typeof(AuthenticationController)
            };

            services.Scan(scan => scan
                .FromAssembliesOf(types)
                .AddClasses()
                .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                .AsMatchingInterface()
                .WithScopedLifetime());
            services.AddScoped<TokenManager>();
            return services;
        }

        public static IServiceCollection AddCustomAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(DtoToModelMappingProfile));
            services.AddAutoMapper(typeof(ModelToDtoMappingProfile));
            return services;
        }

        public static IServiceCollection AddCustomSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Admin Api", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' token in the text input below.",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = IdentityServerAuthenticationDefaults.AuthenticationScheme
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,

                        },
                        new List<string>()
                    }
                });
            });

            return services;
        }
    }
}
