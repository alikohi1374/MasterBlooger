using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using MB.Infrastructure.EFCore;
using MB.Infrastructure.Query;
using Microsoft.EntityFrameworkCore;

namespace MB.Infrastracture.Query
{
  public  class ArticleQuery : IArticleQuery
  {
      private readonly MasterBloggerDbContext _context;

      public ArticleQuery(MasterBloggerDbContext context)
      {
          _context = context;
      }

      public List<ArticleQueryView> GetArticle()
      {
          return _context.Articles.Include(x => x.ArticleCategory).Select(x => new ArticleQueryView
          {
              ArticleCategory =x.ArticleCategory.Title,
              Title = x.Title,
              CreateDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
              Id = x.Id,
              Image = x.Image,
              ShortDescription = x.ShortDescription


          }).ToList();
      }
    }
}