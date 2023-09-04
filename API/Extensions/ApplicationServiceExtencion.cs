using Aplicacion;
using AspNetCoreRateLimit;
using Dominio.Interfaces;

namespace API.Extensions;

    public static class ApplicationServiceExtencion
    {
        public static void ConfigureCors(this IServiceCollection services) =>
            services.AddCors(options =>
            options.AddPolicy("CorsPolicy", builder =>
            builder.AllowAnyMethod()
            .AllowAnyOrigin()
            .AllowAnyHeader()
            ));
        public static void AddAplicationServices(this IServiceCollection services) 
        {
            services.AddScoped<IUnitOfWork,UnitOfWork>();
        }

          public static void ConfigureRateLimiting(this IServiceCollection services) 
        {
            services.AddMemoryCache();
            services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
            services.AddInMemoryRateLimiting();
            services.Configure<IpRateLimitOptions>(options =>
            {
                options.EnableEndpointRateLimiting = true;
                options.StackBlockedRequests = false;
                options.HttpStatusCode = 429;
                options.RealIpHeader = "X-Real-IP";
                options.GeneralRules = new List<RateLimitRule>
                {
                    new RateLimitRule
                    {
                        Endpoint = "*",
                        Period = "10s",
                        Limit = 2
                    }
                };

            });
        }
    }
