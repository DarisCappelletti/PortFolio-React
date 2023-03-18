using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Web;

namespace Portfolio.React.Controllers
{
    public class TestController : Controller
    {
        public ActionResult Index()
        {
            //var client = new HttpClient();
            //var response = client.GetAsync("https://api.instantwebtools.net/v1/airlines	").Result;
            ////var employees = response.Content.ReadAsAsync<List<Employee>>().Result;
            //var boh = response.Content.ReadAsStream();
            //var employees = JsonConvert.DeserializeObject<List<Employee>>(boh.ToString());
            return View();
        }
    }

    public class Employee
    {
        public string id { get; set; }
        public string name { get; set; }
        public string country { get; set; }
        public string logo { get; set; }
        public string slogan { get; set; }
        public string head_quaters { get; set; }
        public string website { get; set; }
        public string established { get; set; }
    }
}
