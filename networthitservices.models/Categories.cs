using System;
using System.Collections.Generic;

namespace networthitservices.models
{
    public partial class Categories
    {
        public Categories()
        {
            Posts = new HashSet<Posts>();
        }

        public int CategoryId { get; set; }
        public string Category { get; set; }
        public string Slug { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? DateModified { get; set; }
        public int? ModifiedBy { get; set; }

        public ICollection<Posts> Posts { get; set; }
    }
}
