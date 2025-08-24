using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using MB.Domain.CommentAgg;
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
          return _context.Articles.Include(x => x.ArticleCategory)
              .Include(x=>x.Comments)
              .Select(x => new ArticleQueryView
          {
              ArticleCategory =x.ArticleCategory.Title,
              Title = x.Title,
              CreateDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
              Id = x.Id,
              Image = x.Image,
              ShortDescription = x.ShortDescription
              ,CommentCount = x.Comments.Count(z=>z.Status==Statuses.Confirmed)
              
          }).ToList();
      }

      public ArticleQueryView GetArticle(long id)
      {
          return _context.Articles.Include(x => x.ArticleCategory).Select(x => new ArticleQueryView
          {
              ArticleCategory = x.ArticleCategory.Title,
              Title = x.Title,
              CreateDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
              Id = x.Id,
              Image = x.Image,
              ShortDescription = x.ShortDescription,
              Content = x.Content,
              CommentCount = x.Comments.Count(z => z.Status == Statuses.Confirmed), 
              Comments = MapComment(x.Comments.Where(z=>z.Status==Statuses.Confirmed))
          }).FirstOrDefault(x=>x.Id==id);
        }

        private static List<CommentQueryView> MapComment(IEnumerable<Comment> comments)
        {
            return comments.Select(comment => new CommentQueryView {Name = comment.Name, Message = comment.Message, CreationDate = comment.CreateDate.ToString(CultureInfo.InvariantCulture)}).ToList();
        }

     
  }
}