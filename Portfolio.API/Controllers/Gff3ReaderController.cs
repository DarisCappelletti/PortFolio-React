using PortFolio.BLL.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Script.Serialization;
using static PortFolio.DAL.Models.GetSoluzioneViaggio;
using static PortFolio.DAL.Models.PostSoluzioneViaggio;
using System.Web.Http.Description;

namespace Portfolio.API.Controllers
{
    public class Gff3ControllerController : ApiController
    {
        [HttpGet]
        [ApiExplorerSettings(IgnoreApi = true)]
        public List<PostSolution> Get(GetTratta tratta)
        {
            var soluzioni = new List<PostSolution>();

            // Imposto i parametri di ricerca
            Ricerca data2 = new Ricerca();
            data2.departureLocationId = Convert.ToInt32(tratta.StazionePartenza.id);
            data2.arrivalLocationId = Convert.ToInt32(tratta.StazioneArrivo.id);

            // Impostata come stringa a causa del JavaScriptSerializer
            data2.departureTime = tratta.DataPartenza.Date.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss");
            data2.adults = tratta.Adulti;
            data2.children = tratta.Bambini;

            data2.advancedSearchRequest = new AdvancedSearchRequest()
            {
                bestFare = false
            };

            bool ciSonoElementi = true;
            int offset = 0;

            while (ciSonoElementi)
            {
                try
                {
                    // Imposto i criteri di ricerca (nello specifico l'offset)
                    data2.criteria = new Criteria()
                    {
                        frecceOnly = tratta.IsFreccia,
                        regionalOnly = tratta.IsRegionale,
                        noChanges = tratta.IsDiretto,
                        order = "DEPARTURE_DATE",
                        offset = offset,
                        limit = 10
                    };

                    // serializzo in json
                    var json = new JavaScriptSerializer().Serialize(data2);
                    // effettuo la chiamata POST
                    var listaSoluzioni = TreniHelper.ricercoSoluzioni(json);
                    soluzioni.AddRange(listaSoluzioni.solutions);

                    if (listaSoluzioni.solutions.Count >= 10)
                    {
                        // ci sono ancora elementi quindi effettuo di nuovo la chiamata aumentando l'offset
                        offset = offset + 10;
                    }
                    else
                    {
                        // non ci sono più elementi
                        ciSonoElementi = false;
                        break;
                    }
                }
                catch (Exception exc)
                {
                    // Errore quando non ci sono più elementi ed effettuo la chiamata
                    ciSonoElementi = false;
                    break;
                }
            }

            // Filtro i super economy
            if (tratta.IsSuperEconomy)
            {
                soluzioni =
                    soluzioni.Where(x =>
                        x.tooltip.nodeServices != null && x.tooltip.nodeServices.Count != 0 &&
                        x.tooltip.nodeServices.Any(y => y != null && y.offer != null && y.offer == "Super Economy"))
                    .ToList();
            }

            return soluzioni;
        }
    }
}
