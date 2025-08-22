using System.Collections.Generic;
using MB.Application.Contracts.Article;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Persentaion.MVCCore.Areas.admin.Pages.ArticleManegement
{
    public class ListModel : PageModel
    {
        public List<ArticleViewModel> Articles { get; set; }
        private readonly IArticleApplication _articleapplication;

        public ListModel(IArticleApplication articleapplication)
        {
            _articleapplication = articleapplication;
        }

        public void OnGet()
        {
            Articles = _articleapplication.GetList();
        }

        public RedirectToPageResult OnPostActivate(long id)
        {
            _articleapplication.Activate(id);
            return RedirectToPage("./list");

        }

        public RedirectToPageResult OnPostRemove(long id)
        {
            _articleapplication.Remove(id);
            return RedirectToPage("./list");

        }
    }
}
