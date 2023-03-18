using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using PortFolio.Core.DAL.ViewModels;
using Portfolio.Core.BLL.Helpers;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Newtonsoft.Json;
using System.Text;

namespace Portfolio.React.Controllers
{
    public class _CurriculumGeneratorController : Controller
    {
        private readonly IWebHostEnvironment _env;

        public _CurriculumGeneratorController(IWebHostEnvironment env)
        {
            _env = env;
        }

        [HttpGet]
        public ActionResult Index(string json = null)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Post(Curriculum1 curriculum)
        {
            try
            {
                string contentRootPath = _env.ContentRootPath;
                string filePath = Path.Combine(contentRootPath, "Assets/files/", "Curriculumtemplate.html");

                var file = CurriculumGeneratorHelper.ImpostaOggettoCV(curriculum, filePath);

                return File(file.Content, file.ContentType, file.NomeConEstensione);
            }
            catch (Exception exc)
            {
                return View();
                //return View(new Email { 
                //alert = new Alert
                //{
                //    Intestazione = "Errore",
                //    Messaggio = "Errore durante l'invio della mail.",
                //    Tipo = Alerts.Errore
                //}
                //});
            }
        }

        [HttpPost]
        public ActionResult LeggiDatiDaXmlFile(IFormFile FileRecuperaCV)
        {
            try
            {
                var cv = CurriculumGeneratorHelper.LeggiValoriDaFileXml(FileRecuperaCV);

                return View("Index", cv);
            }
            catch (Exception exc)
            {
                return View(new Email
                {
                    alert = new Alert
                    {
                        Intestazione = "Errore",
                        Messaggio = "Errore durante l'invio della mail.",
                        Tipo = Core.DAL.Enums.Alerts.Errore
                    }
                });
            }
        }
    }
}