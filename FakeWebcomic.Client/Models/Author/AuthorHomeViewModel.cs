using System.Collections.Generic;

namespace FakeWebcomic.Client.Models
{
    public class AuthorHomeViewModel
    {
        public string Name { get; set; }
        public List<ComicBookModel> ComicBooks { get; set; }

        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public int EditionNumber { get; set; }
        public List<ComicPageModel> ComicPages { get; set; }
        public string Description { get; set; }

    }
}
