using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using static PortFolio.Core.DAL.ViewModels.WikiData;

namespace PortFolioMvc.Controllers
{
    public class _MappaComuniItalianiController : Controller
    {
        private readonly IWebHostEnvironment _env;

        public _MappaComuniItalianiController(IWebHostEnvironment env)
        {
            _env = env;
        }

        public ActionResult Index()
        {
            // Carico le coordinate dal file json
            string contentRootPath = _env.ContentRootPath;
            string filePath = Path.Combine(contentRootPath, "Assets/files/", "CoordinateComuniItaliani_2022-08-31.json");
            //var path = Path.Combine(System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Views/_MappaComuniItaliani/CoordinateComuniItaliani_2022-08-31.json"));

            using (StreamReader sr = new StreamReader(filePath))
            {
                var treatments = JsonConvert.DeserializeObject<List<DettagliWikiData>>(sr.ReadToEnd());

                return View(treatments);
            }

        }
    }
}