using MB.Domain.ArticleAgg;
using MB.Domain.ArticleCategoryAgg;
using MB.Domain.CommentAgg;
using MB.Infrastructure.EFCore.Mapping;
using Microsoft.EntityFrameworkCore;


namespace MB.Infrastructure.EFCore
{
   public class MasterBloggerDbContext:DbContext
   {
       public DbSet<ArticleCategory> ArticleCategories { get; set; }
       public DbSet<Articles>Articles { get; set; }
       public DbSet<Comment>Comments { get; set; }

       public MasterBloggerDbContext(DbContextOptions<MasterBloggerDbContext> options) : base(options)
       {

       }

       protected override void OnModelCreating(ModelBuilder modelBuilder)
       {
           var assembly = typeof(ArticleMapping).Assembly;
           modelBuilder.ApplyConfigurationsFromAssembly(assembly);
     

           base.OnModelCreating(modelBuilder);
       }
   }
}
