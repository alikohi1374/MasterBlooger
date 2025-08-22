using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using MB.Application.Contracts.Article;
using MB.Domain.ArticleAgg;
using Microsoft.EntityFrameworkCore;


namespace MB.Infrastructure.EFCore.Repositores
{

  public  class ArticleRepository: IArticleRepository
  {
      private readonly MasterBloggerDbContext _context;

      public ArticleRepository(MasterBloggerDbContext context)
      {
          _context = context;
      }

      public List<ArticleViewModel> GetList()
      {
          return _context.Articles.Include(x => x.ArticleCategory).Select(x => new ArticleViewModel()
          {
              Id = x.Id,
              Title = x.Title,
              ArticleCategory = x.ArticleCategory.Title,
              CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
              IsDelete = x.IsDeleted
          }).ToList();
      }

      public void CreateArticle(Articles entity)
      {
          _context.Articles.Add(entity);
          Save();
      }

      public Articles Get(long id)
      {
        return  _context.Articles.FirstOrDefault(x => x.Id == id);
      }

      public void Save()
      {
          _context.SaveChanges();
      }
  }
}
