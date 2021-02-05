using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FakeWebcomic.Storage.Models
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ComicPageController : ControllerBase
    {
        private readonly FakeWebcomicRepository _ctx;
        public ComicPageController(FakeWebcomicRepository context)
        {
            _ctx = context;
        }

        // Gets all comic pages from a comic book
        // api/comicpage/{comicbook}
        [HttpGet("{comicbook}")]
        public async Task<IActionResult> GetComicPages(string comicbook)
        {
            var comicPages = _ctx.GetComicBooks().Where(b => b.Title == comicbook)
                .Include(b => b.ComicPages).Select(x => x.ComicPages);
            return await Task.FromResult(Ok(comicPages));
        }

        // Gets 1 comic page from a comic book
        // api/comicpage/{comicbook}/{pagenumber}
        [HttpGet("{comicbook}/{pagenumber}")]
        public async Task<IActionResult> GetComicPage(string comicbook, int pagenumber)
        {
            var comicPage = _ctx.GetComicBooks().Where(b => b.Title == comicbook)
                .Include(b => b.ComicPages).Select(x => x.ComicPages.Where(p => p.PageNumber == pagenumber));
            return await Task.FromResult(Ok(comicPage));
        }

        // Count Number of Pages
        // api/comicpage/total
        [HttpGet("total")]
        public async Task<IActionResult> GetTotalComicPage()
        {
            var total = _ctx.GetComicPages().Count();
            return await Task.FromResult(Ok(total));
        }


        // TODO: Get First Comic Page -> Input: Comic Book
        // [HttpGet("total")]
        // public async Task<IActionResult> GetTotalComicPage()
        // {
        //     var total = _ctx.GetComicPages().Count();
        //     return await Task.FromResult(Ok(total));
        // }

        // TODO: Get Last Comic Page

        // TODO: Randomize Comic Page

        // TODO: Add Pages

        // TODO: Remove Page

    }
}
