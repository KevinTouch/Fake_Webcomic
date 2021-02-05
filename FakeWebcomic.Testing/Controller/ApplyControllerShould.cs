using Xunit;
using Microsoft.AspNetCore.Mvc;
using FakeWebcomic.Client.Controllers;
using System.Threading.Tasks;
namespace FakeWebcomic.Testing.Controller
{
    public class ApplyControllerShould
    {
       [Fact]
        public void ReturnViewForMainArchive()
        {
            var sut = new MainController();
            Task<IActionResult> result = sut.Archive();
            Assert.IsType<Task<ViewResult>>(result);
        }

        [Fact]
        public void ReturnViewForMainAuthor()
        {
            var sut = new AuthorController();
            Task<IActionResult> result = sut.AuthorHome();
            Assert.IsType<Task<ViewResult>>(result);
        }

    }
}
