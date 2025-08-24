using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MB.Application.Contracts.Comment;
using MB.Domain.CommentAgg;
using Microsoft.EntityFrameworkCore;

namespace MB.Infrastructure.EFCore.Repositores
{
 public   class CommentRepository:ICommentRepository
 {
     private readonly MasterBloggerDbContext _context;

     public CommentRepository(MasterBloggerDbContext context)
     {
         _context = context;
     }


     public void CreateAndSave(Comment entity)
     {
         _context.Add(entity);
         Save();
     }

     public List<CommentViewModel> GetList()
     {
         return _context.Comments.Include(x=>x.Article).Select(x=>new CommentViewModel
         {
             Id=x.Id,
             Name = x.Name,
             Message = x.Message,
             Status = x.Status,
             CreationDate = x.CreateDate.ToString(CultureInfo.InvariantCulture),
             Article = x.Article.Title,
             Email = x.Email,
         }).ToList();
     }

     public Comment Get(long id)
     {
         return _context.Comments.FirstOrDefault(x => x.Id == id);
     }

     public void Save()
     {
         _context.SaveChanges();
     }
 }
}
