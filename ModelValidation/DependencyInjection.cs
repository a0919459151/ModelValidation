using ModelValidation.ModelValidators;
using ModelValidation.Providers;
using ModelValidation.Serivces;

namespace Microsoft.Extensions.DependencyInjection
{
    /* 
     * 簡易的示範專案沒有遵守 Dependency inversion principle，
     * Production code 應該要讓這些類別實作介面，然後透過介面注入。
     */
    public static class DependencyInjection
    {
        // Add model validators
        public static IServiceCollection AddModelValidators(this IServiceCollection services)
        {
            services.AddScoped<AuthModelValidator>();
            services.AddScoped<ActivityModelValidator>();
            services.AddScoped<CheckboxModelValidator>();
            services.AddScoped<DateTimeModelValidator>();
            services.AddScoped<DropdownModelValidator>();
            return services;
        }

        // Add providers
        public static IServiceCollection AddProviders(this IServiceCollection services)
        {
            services.AddScoped<PagerProvider>();
            services.AddScoped<ToastrProvider>();
            return services;
        }

        // Add services
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ActivityService>();
            services.AddScoped<DropdownService>();
            return services;
        }
    }
}
