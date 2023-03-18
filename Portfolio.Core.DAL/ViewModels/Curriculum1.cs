using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace PortFolio.Core.DAL.ViewModels
{
    public class Curriculum1
    {
        [XmlIgnore]
        public IFormFile imgBase64 { get; set; }
        public string hidImgBase64 { get; set; }
        public Anagrafica anagrafica { get; set; }
        public Contatti contatti { get; set; }
        public PercorsoDiStudi percorsoDiStudi { get; set; }
        public string skills { get; set; }
        public string profilo { get; set; }
        public EsperienzaLavorativa esperienzaLavorativa { get; set; }
        public List<ProgettoPersonale> progettiPersonali { get; set; }
    }

    public class Anagrafica
    {
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string Eta { get; set; }
        public string Nazionalita { get; set; }
        public string Lingua { get; set; }
    }

    public class Contatti
    {
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Indirizzo { get; set; }
        public string SitoWeb { get; set; }
    }

    public class PercorsoDiStudi
    {
        public string Percorso1 { get; set; }
        public string PercorsoLuogo1 { get; set; }
        public string Percorso2 { get; set; }
        public string PercorsoLuogo2 { get; set; }
    }

    public class EsperienzaLavorativa
    {
        public string Professione { get; set; }
        public string Azienda { get; set; }
        public string DataInizio { get; set; }
        public string DataFine { get; set; }
        public string Descrizione { get; set; }
    }

    public class ProgettoPersonale
    {
        public string Progetto { get; set; }
        public string Linguaggio { get; set; }
    }

    public class XmlCurriculum
    {
        public Curriculum1 curriculum { get; set; }
    }

    public class CvZipFile
    {
        public byte[] Content { get; set; }
        public string ContentType { get; set; }
        public string NomeConEstensione { get; set; }
    }
}