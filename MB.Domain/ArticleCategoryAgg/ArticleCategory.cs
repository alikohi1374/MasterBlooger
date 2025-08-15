using System;
using MB.Domain.ArticleCategoryAgg.Services;


namespace MB.Domain.ArticleCategoryAgg
{
 public   class ArticleCategory
    {
        public long Id { get; private set; }
        public string Title { get; private set; }
        public bool IsDelete { get; private set; }
        public DateTime CreateDate { get; private set; }


        public ArticleCategory(string title, IArticleCategoryValidatorService articleCategoryValidatorService)
        {
            GuardAgainEmptyTitle(title);
            articleCategoryValidatorService.CheekThatThisRecordAlreadyExist(title);
            Title = title;
            IsDelete = false;
            CreateDate=DateTime.Now;
        }

        public void GuardAgainEmptyTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentNullException();
        }
        public void Rename(string title)
        {
            GuardAgainEmptyTitle(title);
            Title = title;
        }

        public void Remove()
        {
            IsDelete = true;
        }
        public void Active()
        {
            IsDelete = false;
        }

    }
}
