

namespace MB.Domain.ArticleCategoryAgg.Services
{
   public interface IArticleCategoryValidatorService
   {
       void CheekThatThisRecordAlreadyExist(string title);
   }
}
