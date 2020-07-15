using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace task1_p.Controllers
{
    [Route("[controller]")]
    public class HomeController : Controller
    {

        static HttpClient client = new HttpClient();

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Post([FromForm] JsonAppointment jsa)
        {
            client.BaseAddress = new Uri("http://localhost:44353/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            ViewBag.JsonText = JsonConvert.SerializeObject(jsa).ToString();
            return View("~/Views/Home/AddJson.cshtml");
        }
    }
}
