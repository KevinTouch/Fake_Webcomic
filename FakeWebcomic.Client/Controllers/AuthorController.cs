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
        private string _webcomicsUri = "https://localhost:5001/api/comicbook";
        private HttpClientHandler _clientHandler = new HttpClientHandler();

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> AuthorHome()
        {
            _clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            using (var _http = new HttpClient(_clientHandler))
            {
                var response = await _http.GetAsync(_webcomicsUri);
                if (response.IsSuccessStatusCode)
                {
                    List<ComicBookModel> AuthorsComicBooks = new List<ComicBookModel>{};
                    var ComicBooks = JsonConvert.DeserializeObject<List<ComicBookModel>>(await response.Content.ReadAsStringAsync());
                    if (ComicBooks != null)
                    {
                        AuthorsComicBooks = ComicBooks.FindAll(c => c.Title == User.Identity.Name);
                        AuthorsComicBooks.OrderBy(c => c.Title);
                    }
                    return View("AuthorHomeView", new AuthorHomeViewModel(User.Identity.Name, AuthorsComicBooks));
                }
                return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }

        // [HttpPost]
        // public async Task<IActionResult> NewAuthor()
        // {
        //     //add account to Okto, add authour to Storage API
        //     return await AuthorHome();
        // }
    }
}
