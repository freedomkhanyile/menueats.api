namespace menueats.api.API.ServicesExtensions
{
    using menueats.api.DAL.Contracts.IRepositoryWrapper;
    using menueats.api.DAL.DbContext;
    using menueats.api.DAL.Entities;
    using menueats.api.DAL.Repository.RepositoryWrapper;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;

    public static class ServicesExtentions
    {
        //Cross origins here left light for demo purposes consult on Business case.
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(o =>
            {
                o.AddPolicy("CorsPolicy",
                 builder => builder.AllowAnyOrigin()
                                   .AllowAnyHeader()
                                   .AllowAnyMethod()
                                   .AllowCredentials());
            });
        }

        //Necessary for IIS deployments on Windows machines
        public static void ConfigureIISIntegration(this IServiceCollection services)
        {
            services.Configure<IISOptions>(options =>
            {
            });
        }

        public static void ConfigurSQLServerContext(this IServiceCollection services)
        {
            services.AddDbContext<RepositoryContext>(ServiceLifetime.Scoped);
            services.AddTransient<DBInitializer>();
        }

        public static void ConfigureUserIdentity(this IServiceCollection services){
            services.AddIdentity<User, IdentityRole>()
                    .AddEntityFrameworkStores<RepositoryContext>();
        }

        public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddSingleton<IRepositoryWrapper, RepositoryWrapper>();
        }

    }
}