using FakeWebcomic.Client.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace FakeWebcomic.Client.Controllers
{
    [Route("[controller]")]
    public class AuthorController : Controller
    {
        private string _webcomicsUri = "https://localhost:5001/api/comicbook/";
        private HttpClientHandler _clientHandler = new HttpClientHandler();

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> AuthorHome()
        {
            _clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            var authorName = HttpContext.User.Identity.Name;
            ViewBag.name = authorName;
            var firstName = authorName.Split(" ")[0];

            using (var _http = new HttpClient(_clientHandler))
            {
                var response = await _http.GetAsync(_webcomicsUri + firstName);
                if (response.IsSuccessStatusCode)
                {

                    var model = new AuthorHomeViewModel();
                    model.ComicBooks = JsonConvert.DeserializeObject<List<ComicBookModel>>(await response.Content.ReadAsStringAsync());
                    return View("AuthorHomeView", model);
                }
                else
                {
                    return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
                }

            }
        }

        [HttpPost]
        public async Task<IActionResult> AddComic(AuthorHomeViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var authorName = HttpContext.User.Identity.Name;
                ViewBag.name = authorName;
                var firstName = authorName.Split(" ")[0];
                ComicBookModel model = new ComicBookModel();
                model.Title = viewModel.Title;
                model.Author = firstName;
                model.Genre = viewModel.Genre;
                model.EditionNumber = viewModel.EditionNumber;
                model.ComicPages = new List<ComicPageModel>();
                model.Description = viewModel.Description;

                _clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
                using (var _http = new HttpClient(_clientHandler))
                {
                    await _http.PostAsJsonAsync(_webcomicsUri, model);
                    var response = await _http.GetAsync(_webcomicsUri + firstName);

                    viewModel.ComicBooks = JsonConvert.DeserializeObject<List<ComicBookModel>>(await response.Content.ReadAsStringAsync());
                    return View("AuthorHomeView", viewModel);
                }
            }
            else
            {
                return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }

        }

        [HttpPost("{comicbook}")]
        public async Task<IActionResult> DeleteComic(string comicbook)
        {
            if (ModelState.IsValid)
            {
                var authorName = HttpContext.User.Identity.Name;
                ViewBag.name = authorName;
                var firstName = authorName.Split(" ")[0];

                _clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
                using (var _http = new HttpClient(_clientHandler))
                {
                    await _http.DeleteAsync(_webcomicsUri + comicbook);
                    var response = await _http.GetAsync(_webcomicsUri + firstName);

                    var viewModel = new AuthorHomeViewModel();
                    viewModel.ComicBooks = JsonConvert.DeserializeObject<List<ComicBookModel>>(await response.Content.ReadAsStringAsync());
                    return View("AuthorHomeView", viewModel);
                }
            }
            else
            {
                return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }

        }

    }
}
