using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;
using static PortFolio.DAL.Models.GetSoluzioneViaggio;

namespace Portfolio.API.Controllers
{
    public class StazioniTreniController : ApiController
    {
        public List<Stazione> Get(string nome)
        {
            try
            {
                var cookie = Request.Headers.GetCookies("RicercaTreni").FirstOrDefault();

                // estrepolo la stazione in base al nome indicato
                string api = "https://www.lefrecce.it/Channels.Website.BFF.WEB/website/locations/search?name=" + nome + "&limit=100";
                var request = (HttpWebRequest)WebRequest.Create(api);
                request.ContentType = "application/json";
                request.Method = "GET";

                WebResponse response = request.GetResponse() as HttpWebResponse;
                var stream = response.GetResponseStream();
                StreamReader reader2 = new StreamReader(stream);
                // Leggo la risposta.
                string streamJson2 = reader2.ReadToEnd();
                var listaStazioni = new JavaScriptSerializer().Deserialize<List<Stazione>>(streamJson2);

                return listaStazioni;
            }
            catch (Exception exc)
            {
                return null;
            }
        }
    }
}
