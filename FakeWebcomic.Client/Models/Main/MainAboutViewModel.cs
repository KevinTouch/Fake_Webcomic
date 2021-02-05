namespace FakeWebcomic.Client.Models
{
    public class MainAboutViewModel
    {
        public string NumberOfComicBooks { get; set; }
        public string NumberOfPages { get; set; }

        public MainAboutViewModel(string numberofcomicbooks, string numberofpages)
        {
            NumberOfComicBooks = numberofcomicbooks;
            NumberOfPages = numberofpages;
        }
    }
}
