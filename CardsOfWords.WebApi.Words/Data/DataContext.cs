using CardsOfWords.WebApi.Words.Data.Entities;
using Microsoft.EntityFrameworkCore;


namespace CardsOfWords.WebApi.Words.Data
{
    public class DataContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(Configuration.GetConnectionString("WordsDbConnectionString"), b =>
            {
                b.EnableRetryOnFailure(maxRetryCount: 3, maxRetryDelay: TimeSpan.FromSeconds(2), errorCodesToAdd: null);    
            });
        }
        public DbSet<AppVersion> AppVersions { get; set; }
        public DbSet<WordGroup> WordGroups { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Word> Words { get; set; }
        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    builder.Entity<Word>().
        //        HasOne(w => w.WordGroup).
        //        WithMany(g => g.Words);
        //    builder.Entity<WordGroup>().
        //        HasOne(w => w.Language).
        //        WithMany(l => l.WordGroups);
        //    builder.Entity<Language>().HasMany<WordGroup>(x=>x.WordGroups);
        //}
    }
}
