using MB.Domain.ArticleCategoryAgg.Exceptions;

namespace MB.Domain.ArticleAgg.Services
{
    public class ArticleValidatorServices : IArticleValidatorServices
    {
        private readonly IArticleRepository _articleRepository;

        public ArticleValidatorServices(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public void CheekThatThisRecordAlreadyExist(string title)
        {
            if (_articleRepository.Exist(title))
                throw new DuplicatedRecordException("یکی مثل این هست");

        }
    }
}