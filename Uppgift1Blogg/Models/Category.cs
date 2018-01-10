using System;
using System.Collections.Generic;

namespace Uppgift1Blogg.Models
{
    public partial class Category
    {
        public Category()
        {
            BlogPost = new HashSet<BlogPost>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<BlogPost> BlogPost { get; set; }
    }
}
