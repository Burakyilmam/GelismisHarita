using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Models;
using WebApplication1.Models.Context;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly IHttpClientFactory _clientFactory;

        public HomeController(DataContext dataContext, IHttpClientFactory clientFactory)
        {
            _dataContext = dataContext;
            _clientFactory = clientFactory;
        }
        public async Task<IActionResult> Index() {

            var client = _clientFactory.CreateClient();
            var apiUrl = "https://api.collectapi.com/health/dutyPharmacy?ilce=&il=Bursa";
            //var apiKey = "4EQNXyQGFje6jy1UYMP6V2:0C6EifM0zBqlOi6Dta9goe";
            var apiKey = "";

            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("apikey", apiKey);

            try
            {
                var response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    ViewBag.PharmaciesData = content;
                    return View();
                }
                else
                {
                    var errorMessage = $"API çaðrýsý baþarýsýz: {response.StatusCode} - {response.ReasonPhrase}";
                    ViewBag.ErrorMessage = errorMessage;
                    return View();
                }
            }
            catch (HttpRequestException)
            {
                ViewBag.ErrorMessage = "HTTP isteði sýrasýnda bir hata oluþtu.";
                return View();
            }
        }
    }
}
