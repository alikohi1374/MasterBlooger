using MB.Domain.ArticleAgg;


namespace MB.Infrastructure.EFCore.Repositores
{

  public  class ArticleRepository: IArticleRepository
  {
      private readonly MasterBloggerDbContext _context;

      public ArticleRepository(MasterBloggerDbContext context)
      {
          _context = context;
      }
  }
}
