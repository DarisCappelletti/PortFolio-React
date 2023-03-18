using PortFolio.BLL.Helpers;
using PortFolio.DAL.Models;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace Portfolio.API.Controllers
{
    public class IgController : ApiController
    {
        // GET api/Ig
        public RicercaUtenteIg.Root Get(string utente = null)
        {
            string api = $"https://i.instagram.com/api/v1/web/search/topsearch/?query={utente}";
            var request = (HttpWebRequest)WebRequest.Create(api);

            request.ContentType = "application/json";
            request.Headers.Add("accept-encoding", " gzip, deflate, br");
            request.Headers.Add("accept-language", " it-IT,it;q=0.6");
            request.Headers.Add("cookie", " ig_did=F0CF4A4B-65B2-4006-8DC4-627E607D0E26; mid=YzxiTgALAAHNAoZtQUqgcWZJAjqU; datr=uy9sY0gDS725BOIJUPJKNJf-; ds_user_id=268542472; csrftoken=U2gA3U4DYuVhxzXKoI7aWV4cyqlC8poU; dpr=1.25; shbid=\"11945\\054268542472\\0541710232451:01f7a48fa27fd7a3d23ca4bd8de8796574c62dfcf42618445783b6d4f4d848e3aac26136\"; shbts=\"1678696451\\054268542472\\0541710232451:01f7d329f997d52e10a5af771dd068bdcaebaeb4547107ab6f6573ded9190534715cf291\"; sessionid=268542472%3AWpYWPaJMz84C1s%3A21%3AAYc9JuC9rlMSAgjiO9G1ElDbwY_06J80-WYx2N-E0g; rur=\"CLN\\054268542472\\0541710344652:01f75bfbe9c1520fbd904c1910e10ef68dbf78f3a824baa42b2592fdf64dcb41944800b4\"; csrftoken=U2gA3U4DYuVhxzXKoI7aWV4cyqlC8poU; ds_user_id=268542472; ig_did=0D50786E-A68F-4733-939A-522AAA398C66; mid=ZBAutAALAAH5BuY39pEsoGL0_jhD; rur=\"CLN\\054268542472\\0541710344757:01f725f0081ec8d7ff541da93c3c71c9150bb2943f96a0d5070642fdd91b1131fca61eed\"");
            request.Headers.Add("sec-ch-ua", " \"Brave\";v=\"111\", \"Not(A:Brand\";v=\"8\", \"Chromium\";v=\"111\"");
            request.Headers.Add("sec-ch-ua-mobile", " ?0");
            request.Headers.Add("sec-ch-ua-platform", " \"Windows\"");
            request.Headers.Add("sec-fetch-dest", " empty");
            request.Headers.Add("sec-fetch-mode", " cors");
            request.Headers.Add("sec-fetch-site", " same-origin");
            request.Headers.Add("sec-gpc", " 1");
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/111.0.0.0 Safari/537.36";
            request.Headers.Add("x-asbd-id", " 198387");
            request.Headers.Add("x-csrftoken", " U2gA3U4DYuVhxzXKoI7aWV4cyqlC8poU");
            request.Headers.Add("x-ig-app-id", " 936619743392459");
            request.Headers.Add("x-ig-www-claim", " hmac.AR2VsJz-RWrU-GsQrRTpQJFYs3vexseuqXnpTPNl95I5pE--");
            request.Headers.Add("x-reque", "");

            request.Method = "GET";
            //request.CookieContainer = cookieContainer;

            WebResponse response = request.GetResponse() as HttpWebResponse;
            var stream = response.GetResponseStream();

            // Controllo se la risposta è codificata con GZIP
            if (response.Headers["Content-Encoding"]?.ToLower().Contains("gzip") == true)
            {
                // Creo uno stream per la decompressione GZIP
                stream = new GZipStream(stream, CompressionMode.Decompress);
            }

            StreamReader reader2 = new StreamReader(stream);
            // Leggo la risposta.
            string streamJson2 = reader2.ReadToEnd();

            var listaUtenti = new JavaScriptSerializer().Deserialize<RicercaUtenteIg.Root>(streamJson2);

            return listaUtenti;
        }

        // GET api/Ig
        public ChiamataUserIg.Root Get(bool ig, string username = null)
        {
            string api = $"https://www.instagram.com/api/v1/users/web_profile_info/?username={username}";
            var request = (HttpWebRequest)WebRequest.Create(api);

            request.ContentType = "application/json";
            request.Headers.Add("accept-encoding", " gzip, deflate, br");
            request.Headers.Add("accept-language", " it-IT,it;q=0.6");
            request.Headers.Add("sec-ch-ua", " \"Brave\";v=\"111\", \"Not(A:Brand\";v=\"8\", \"Chromium\";v=\"111\"");
            request.Headers.Add("sec-ch-ua-mobile", " ?0");
            request.Headers.Add("sec-ch-ua-platform", " \"Windows\"");
            request.Headers.Add("sec-fetch-dest", " empty");
            request.Headers.Add("sec-fetch-mode", " cors");
            request.Headers.Add("sec-fetch-site", " same-origin");
            request.Headers.Add("sec-gpc", " 1");
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/111.0.0.0 Safari/537.36";
            request.Headers.Add("x-asbd-id", " 198387");
            request.Headers.Add("x-csrftoken", " U2gA3U4DYuVhxzXKoI7aWV4cyqlC8poU");
            request.Headers.Add("x-ig-app-id", " 936619743392459");
            request.Headers.Add("x-ig-www-claim", " hmac.AR2VsJz-RWrU-GsQrRTpQJFYs3vexseuqXnpTPNl95I5pE--");
            request.Headers.Add("x-reque", "");

            request.Method = "GET";
            //request.CookieContainer = cookieContainer;

            WebResponse response = request.GetResponse() as HttpWebResponse;
            var stream = response.GetResponseStream();

            // Controllo se la risposta è codificata con GZIP
            if (response.Headers["Content-Encoding"]?.ToLower().Contains("gzip") == true)
            {
                // Creo uno stream per la decompressione GZIP
                stream = new GZipStream(stream, CompressionMode.Decompress);
            }

            StreamReader reader2 = new StreamReader(stream);
            // Leggo la risposta.
            string streamJson2 = reader2.ReadToEnd();

            var utente = new JavaScriptSerializer().Deserialize<ChiamataUserIg.Root>(streamJson2);

            return utente;
        }

        // GET api/Ig
        public RicercaFollowersIg.Root Get(int id, int? maxID = null)
        {
            string api = $"https://www.instagram.com/api/v1/friendships/{id}/followers/?search_surface=follow_list_page&max_id={maxID}";
            var request = (HttpWebRequest)WebRequest.Create(api);

            request.ContentType = "application/json";
            request.Headers.Add("accept-encoding", " gzip, deflate, br");
            request.Headers.Add("accept-language", " it-IT,it;q=0.6");
            request.Headers.Add("cookie", " ig_did=F0CF4A4B-65B2-4006-8DC4-627E607D0E26; mid=YzxiTgALAAHNAoZtQUqgcWZJAjqU; datr=uy9sY0gDS725BOIJUPJKNJf-; ds_user_id=268542472; csrftoken=U2gA3U4DYuVhxzXKoI7aWV4cyqlC8poU; dpr=1.25; shbid=\"11945\\054268542472\\0541710232451:01f7a48fa27fd7a3d23ca4bd8de8796574c62dfcf42618445783b6d4f4d848e3aac26136\"; shbts=\"1678696451\\054268542472\\0541710232451:01f7d329f997d52e10a5af771dd068bdcaebaeb4547107ab6f6573ded9190534715cf291\"; sessionid=268542472%3AWpYWPaJMz84C1s%3A21%3AAYc9JuC9rlMSAgjiO9G1ElDbwY_06J80-WYx2N-E0g; rur=\"CLN\\054268542472\\0541710344652:01f75bfbe9c1520fbd904c1910e10ef68dbf78f3a824baa42b2592fdf64dcb41944800b4\"; csrftoken=U2gA3U4DYuVhxzXKoI7aWV4cyqlC8poU; ds_user_id=268542472; ig_did=0D50786E-A68F-4733-939A-522AAA398C66; mid=ZBAutAALAAH5BuY39pEsoGL0_jhD; rur=\"CLN\\054268542472\\0541710344757:01f725f0081ec8d7ff541da93c3c71c9150bb2943f96a0d5070642fdd91b1131fca61eed\"");
            request.Headers.Add("sec-ch-ua", " \"Brave\";v=\"111\", \"Not(A:Brand\";v=\"8\", \"Chromium\";v=\"111\"");
            request.Headers.Add("sec-ch-ua-mobile", " ?0");
            request.Headers.Add("sec-ch-ua-platform", " \"Windows\"");
            request.Headers.Add("sec-fetch-dest", " empty");
            request.Headers.Add("sec-fetch-mode", " cors");
            request.Headers.Add("sec-fetch-site", " same-origin");
            request.Headers.Add("sec-gpc", " 1");
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/111.0.0.0 Safari/537.36";
            request.Headers.Add("x-asbd-id", " 198387");
            request.Headers.Add("x-csrftoken", " U2gA3U4DYuVhxzXKoI7aWV4cyqlC8poU");
            request.Headers.Add("x-ig-app-id", " 936619743392459");
            request.Headers.Add("x-ig-www-claim", " hmac.AR2VsJz-RWrU-GsQrRTpQJFYs3vexseuqXnpTPNl95I5pE--");
            request.Headers.Add("x-reque", "");

            request.Method = "GET";
            //request.CookieContainer = cookieContainer;

            WebResponse response = request.GetResponse() as HttpWebResponse;
            var stream = response.GetResponseStream();

            // Controllo se la risposta è codificata con GZIP
            if (response.Headers["Content-Encoding"]?.ToLower().Contains("gzip") == true)
            {
                // Creo uno stream per la decompressione GZIP
                stream = new GZipStream(stream, CompressionMode.Decompress);
            }

            StreamReader reader2 = new StreamReader(stream);
            // Leggo la risposta.
            string streamJson2 = reader2.ReadToEnd();

            var listaFollowers = new JavaScriptSerializer().Deserialize<RicercaFollowersIg.Root>(streamJson2);

            return listaFollowers;
        }
    }
}
