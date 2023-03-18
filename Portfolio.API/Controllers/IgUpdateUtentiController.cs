using PortFolio.BLL.Helpers;
using PortFolio.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Portfolio.API.Controllers
{
    public class IgUpdateUtentiController : ApiController
    {
        // GET: IgUpdateUtenti
        public void Get()
        {
            DarisCappellettiEntities db = new DarisCappellettiEntities();
            var utenti = db.UtenteIg.ToList();

            foreach (var utente in utenti)
            {
                if(utente.Followers == 0)
                {
                    IgHelper.updUtente(db, utente);
                }
            }

        }
    }
}