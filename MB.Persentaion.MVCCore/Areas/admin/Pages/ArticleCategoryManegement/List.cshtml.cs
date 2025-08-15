using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MB.Application.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Persentaion.MVCCore.Areas.admin.Pages.ArticleCategoryManegement
{
    public class ListModel : PageModel
    {
        public List<ArticleCategoryViewModel> ArcileCategories { get; set; }
        private readonly IArticleCategoryApplication _articleCategoryApplicaton;
        public ListModel(IArticleCategoryApplication articleCategoryApplicaton)

        {
            _articleCategoryApplicaton = articleCategoryApplicaton;
        }


        public void OnGet()
        {
            ArcileCategories = _articleCategoryApplicaton.List();
        }

        public RedirectToPageResult OnPostRemove(long id)
        {
            _articleCategoryApplicaton.Remove(id);
             return RedirectToPage("./list");
        }
        public RedirectToPageResult OnPostActivete(long id)
        {
            _articleCategoryApplicaton.Activate(id);
            return RedirectToPage("./list");
        }
    }
}
