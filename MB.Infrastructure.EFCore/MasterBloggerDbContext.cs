using MB.Domain.ArticleCategoryAgg;
using MB.Infrastructure.EFCore.Mapping;
using Microsoft.EntityFrameworkCore;


namespace MB.Infrastructure.EFCore
{
   public class MasterBloggerDbContext:DbContext
   {
       public DbSet<ArticleCategory> ArticleCategories { get; set; }

       public MasterBloggerDbContext(DbContextOptions<MasterBloggerDbContext> options) : base(options)
       {

       }

       protected override void OnModelCreating(ModelBuilder modelBuilder)
       {
           modelBuilder.ApplyConfiguration(new ArticleCategoryMapping());
           base.OnModelCreating(modelBuilder);
       }
   }
}
