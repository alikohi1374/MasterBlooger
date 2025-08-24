using System;
using System.Collections.Generic;
using MB.Infrastracture.Query;

namespace MB.Infrastructure.Query
{
    public class ArticleQueryView
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string ArticleCategory { get; set; }
        public string CreateDate { get; set; }
        public string Image { get; set; }
        public string Content { get; set; }
        public long CommentCount { get; set; }
        public List<CommentQueryView> Comments { get; set; }

    }
}
