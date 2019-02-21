namespace menueats.api.DAL.DbContext
{
    using menueats.api.DAL.Entities;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    public class RepositoryContext : IdentityDbContext
    {
        private IConfiguration _config;

        public RepositoryContext(DbContextOptions<RepositoryContext> options, IConfiguration config)
            : base(options)
        {
            _config = config;
        }

        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(_config["Data:ConnectionString"]);
        }
    }
}