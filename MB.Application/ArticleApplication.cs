using System.Collections.Generic;
using MB.Application.Contracts.Article;
using MB.Domain.ArticleAgg;


namespace MB.Application
{
    public class ArticleApplication: IArticleApplication
    {
        private readonly IArticleRepository _articleRepository;

        public ArticleApplication(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public List<ArticleViewModel> GetList()
        {
            return _articleRepository.GetList();
        }

        public void Ctrate(CreateArticle command)
        {
            var article = new Articles(command.Title, command.ShortDescription, command.Image, command.Content,
                command.ArticleCategoryId);
            _articleRepository.CreateArticle(article);
        }
    }
}
