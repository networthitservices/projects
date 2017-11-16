using System;
using System.Collections.Generic;

namespace networthitservices.models
{
    public partial class Posts
    {
        public int PostId { get; set; }
        public int? CategoryId { get; set; }
        public string PostTitle { get; set; }
        public string Slug { get; set; }
        public string FeaturedImage { get; set; }
        public string PostMessage { get; set; }
        public DateTime? DatePublished { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? DateModified { get; set; }
        public int? ModifiedBy { get; set; }

        public Categories Category { get; set; }
    }
}
