using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SchoolLifeClient.Controllers
{
    public class StudentsController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:44381/api");   //Port No.
        HttpClient client;
        public StudentsController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;

        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
