using Xunit;
using Microsoft.AspNetCore.Mvc;
using FakeWebcomic.Client.Views.Main;
namespace FakeWebcomic.Testing.Controller
{
    public class ApplyControllerShould
    {
       [Fact]
        public void ReturnViewForMainArchive()
        {
            var sut = new MainArchiveView();
            IActionResult result = sut.Archive();
            Asser.IsType<ViewResult>(result);
        }

        [Fact]
        public void ReturnViewForMainAuthor()
        {
            var sut = new AuthorHomeView();
            IActionResult result = sut.AuthorHome();
            Asser.IsType<ViewResult>(result);
        }

        [Fact]
        public void ReturnViewForMainAuthor()
        {
            var sut = new AuthorHomeView();
            IActionResult result = sut.AuthorHome();
            Asser.IsType<ViewResult>(result);
        }
    }
}
