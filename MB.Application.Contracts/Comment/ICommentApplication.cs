using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Application.Contracts.Comment
{
   public interface ICommentApplication
   {
       void Add(AddComment command);
       List<CommentViewModel> GetList();
       public void Confirm(long id);
       public void Cancel(long id);


   }
}
