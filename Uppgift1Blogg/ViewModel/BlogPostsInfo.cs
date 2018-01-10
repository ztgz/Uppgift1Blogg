using System.Collections.Generic;
using Uppgift1Blogg.Models;

namespace Uppgift1Blogg.ViewModel
{
    public class BlogPostsInfo
    {
        public List<BlogPost> BlogPosts { get; set; }
        public List<Category> Categories { get; set; }
        public BlogPost BlogPost { get; set; }

        public BlogPostsInfo()
        {
            BlogPosts = new List<BlogPost>();
            Categories = new List<Category>();
            BlogPost = new BlogPost();
        }
    }
}
