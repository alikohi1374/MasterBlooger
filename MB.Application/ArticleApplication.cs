using System.Collections.Generic;
using MB.Application.Contracts.Article;
using MB.Domain.ArticleAgg;
using MB.Domain.ArticleAgg.Services;


namespace MB.Application
{
    public class ArticleApplication: IArticleApplication
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IArticleValidatorServices _articleValidator;

        public ArticleApplication(IArticleRepository articleRepository,IArticleValidatorServices articleValidatorServices)
        {
            _articleRepository = articleRepository;
            _articleValidator = articleValidatorServices;
        }

        public List<ArticleViewModel> GetList()
        {
            return _articleRepository.GetList();
        }

        public void Create(CreateArticle command)
        {
            var article = new Articles(command.Title, command.ShortDescription, command.Image, command.Content,
                command.ArticleCategoryId,_articleValidator);
            _articleRepository.CreateArticle(article);
        }

        public void Edit(EditArticle command)
        {
          var article=  _articleRepository.Get(command.Id);
          article.Edit(command.Title, command.ShortDescription, command.Image, command.Content,
              command.ArticleCategoryId);
          _articleRepository.Save();
        }

        public EditArticle Get(long id)
        {
            var article = _articleRepository.Get(id);
            return new EditArticle()
            {
                Id = article.Id,
                Title = article.Title,
                ShortDescription = article.ShortDescription,
                Content = article.Content,
                Image = article.Image,
                ArticleCategoryId = article.ArticleCategoryId
            };

        }

        public void Remove(long id)
        {
            var articles = _articleRepository.Get(id);
            articles.Remove();
            _articleRepository.Save();
        }

        public void Activate(long id)
        {
            var articles = _articleRepository.Get(id);
            articles.Activate();
            _articleRepository.Save();
        }
    }
}
