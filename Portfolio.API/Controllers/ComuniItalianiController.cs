using ExcelDataReader;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PortFolio.BLL.Helpers;
using PortFolio.DAL.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using static PortFolio.DAL.ViewModels.IndicePA;
using static PortFolio.DAL.ViewModels.Istat;
using static PortFolio.DAL.ViewModels.Wiki;
using static PortFolio.DAL.ViewModels.WikiData;

namespace Portfolio.API.Controllers
{
    public class ComuniItalianiController : ApiController
    {
        // GET api/ComuniItaliani
        public List<Comune> Get(string comune = null, bool datiIndicePA = false, bool datiWikiData = false)
        {
            // Ritorno la lista dei comuni italiani
            return ComuniItalianiHelper.RicercaComuniIstat(comune, datiIndicePA, datiWikiData);
        }
    }
}
