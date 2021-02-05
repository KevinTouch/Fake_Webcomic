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
        public async Task<IActionResult> NewAuthor()
        {

        }


        // [HttpPost]
        // public async Task<IActionResult> NewAuthor()
        // {
        //     //add account to Okto, add authour to Storage API
        //     return await AuthorHome();
        // }
    }
}
