using System.Collections.Generic;

namespace FakeWebcomic.Client.Models
{
    public class AuthorHomeViewModel
    {
        public string Name {get;set;}
        public List<ComicBookModel> ComicBooks {get;set;}

        public AuthorHomeViewModel(string name, List<ComicBookModel> comicbooks)
        {
            Name = name;
            ComicBooks = comicbooks;
        }
    }
}
