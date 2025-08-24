using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MB.Infrastructure.Query;

namespace MB.Infrastracture.Query
{
   public interface IArticleQuery
   {
       List<ArticleQueryView> GetArticle();
       ArticleQueryView GetArticle(long id);

   }
}
