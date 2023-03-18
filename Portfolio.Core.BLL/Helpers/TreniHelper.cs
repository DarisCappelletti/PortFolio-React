using System.IO;
using System.Net;
using System.Web.Script.Serialization;
using static PortFolio.Core.DAL.Models.PostSoluzioneViaggio;

namespace Portfolio.Core.BLL.Helpers
{
    public static class TreniHelper
    {
        public static RootPostSoluzioneViaggio ricercoSoluzioni(string json)
        {
            string api = "https://www.lefrecce.it/Channels.Website.BFF.WEB/website/ticket/solutions";
            var request = (HttpWebRequest)WebRequest.Create(api);
            request.ContentType = "application/json";
            request.Headers.Add("accept-language", "it-IT");
            request.Method = "POST";
            //request.CookieContainer = cookieContainer;

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(json);
            }

            WebResponse response = request.GetResponse() as HttpWebResponse;
            var stream = response.GetResponseStream();
            StreamReader reader2 = new StreamReader(stream);
            // Leggo la risposta.
            string streamJson2 = reader2.ReadToEnd();

            var listaSoluzioni = new JavaScriptSerializer().Deserialize<RootPostSoluzioneViaggio>(streamJson2);

            return listaSoluzioni;
        }
    }
}
