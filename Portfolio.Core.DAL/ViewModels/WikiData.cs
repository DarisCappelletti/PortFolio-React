using Newtonsoft.Json;
using System.Collections.Generic;

namespace PortFolio.Core.DAL.ViewModels
{
    public class WikiData
    {
        public class Root
        {
            public Entities entities { get; set; }
            public int success { get; set; }
        }

        public class Entities
        {
            [JsonProperty("user_id")]
            public ElementoPrincipale elemento { get; set; }
        }

        public class ElementoPrincipale
        {
            public dynamic type { get; set; }
            public dynamic id { get; set; }
            public Claims claims { get; set; }
        }

        public class Claims
        {
            public List<Elemento1> P373 { get; set; }
            public List<Elemento1> P131 { get; set; }
            public List<Elemento1> P281 { get; set; }
            public List<Elemento1> P47 { get; set; }
            public List<Elemento1> P421 { get; set; }
            public List<Elemento1> P242 { get; set; }
            public List<Elemento1> P473 { get; set; }
            public List<Elemento1> P18 { get; set; }
            public List<Elemento1> P635 { get; set; }
            public List<Elemento1> P17 { get; set; }
            public List<Elemento1> P806 { get; set; }
            public List<Elemento1> P856 { get; set; }
            public List<Elemento1> P31 { get; set; }
            public List<Elemento1> P646 { get; set; }
            public List<Elemento1> P1566 { get; set; }
            public List<Elemento3> P214 { get; set; }
            public List<Elemento1> P2044 { get; set; }
            public List<Elemento1> P625 { get; set; }
            public List<Elemento1> P395 { get; set; }
            public List<Elemento1> P1332 { get; set; }
            public List<Elemento1> P1333 { get; set; }
            public List<Elemento1> P1334 { get; set; }
            public List<Elemento1> P1335 { get; set; }
            public List<Elemento3> P402 { get; set; }
            public List<Elemento1> P1667 { get; set; }
            public List<Elemento1> P36 { get; set; }
            public List<Elemento1> P2046 { get; set; }
            public List<Elemento3> P1082 { get; set; }
            public List<Elemento1> P6832 { get; set; }
            public List<Elemento1> P6766 { get; set; }
            public List<Elemento1> P7859 { get; set; }
            public List<Elemento1> P2186 { get; set; }
            public List<Elemento1> P417 { get; set; }
            public List<Elemento1> P8592 { get; set; }
            public List<Elemento1> P9235 { get; set; }
        }

        public class Elemento1
        {
            public Mainsnak mainsnak { get; set; }
            public dynamic type { get; set; }
            public Qualifiers qualifiers { get; set; }
            public dynamic id { get; set; }
            public dynamic rank { get; set; }
            public List<Reference> references { get; set; }
        }

        public class Elemento2
        {
            public dynamic snaktype { get; set; }
            public dynamic property { get; set; }
            public dynamic hash { get; set; }
            public Datavalue datavalue { get; set; }
            public dynamic datatype { get; set; }
        }

        public class Elemento3
        {
            public Mainsnak mainsnak { get; set; }
            public dynamic type { get; set; }
            public dynamic id { get; set; }
            public dynamic rank { get; set; }
            public List<Reference> references { get; set; }
            public dynamic snaktype { get; set; }
            public dynamic property { get; set; }
            public dynamic hash { get; set; }
            public Datavalue datavalue { get; set; }
            public dynamic datatype { get; set; }
        }

        public class Mainsnak
        {
            public dynamic snaktype { get; set; }
            public dynamic property { get; set; }
            public dynamic hash { get; set; }
            public Datavalue datavalue { get; set; }
            public dynamic datatype { get; set; }
        }

        public class Datavalue
        {
            public dynamic value { get; set; }
            public dynamic type { get; set; }
        }

        public class Qualifiers
        {
            public List<Elemento2> P1264 { get; set; }
            public List<Elemento2> P585 { get; set; }
            public List<Elemento2> P459 { get; set; }
            public List<Elemento2> P580 { get; set; }
        }

        public class Reference
        {
            public dynamic hash { get; set; }
            public Snaks snaks { get; set; }
        }

        public class Snaks
        {
            public List<Elemento2> P143 { get; set; }
            public List<Elemento2> P248 { get; set; }
            public List<Elemento2> P577 { get; set; }
            public List<Elemento2> P813 { get; set; }
            public List<Elemento3> P402 { get; set; }
            public List<Elemento2> P854 { get; set; }
            public List<Elemento2> P1476 { get; set; }
            public List<Elemento3> P123 { get; set; }
            public List<Elemento3> P214 { get; set; }
            public List<Elemento2> P4656 { get; set; }
        }

        public class Value
        {
            public dynamic EntityType { get; set; }
            public dynamic NumericId { get; set; }
            public dynamic id { get; set; }
            public dynamic time { get; set; }
            public dynamic timezone { get; set; }
            public dynamic before { get; set; }
            public dynamic after { get; set; }
            public dynamic precision { get; set; }
            public dynamic calendarmodel { get; set; }
            public dynamic amount { get; set; }
            public dynamic unit { get; set; }
            public dynamic upperBound { get; set; }
            public dynamic lowerBound { get; set; }
            public double latitude { get; set; }
            public double longitude { get; set; }
            public dynamic altitude { get; set; }
            public dynamic globe { get; set; }
            public dynamic text { get; set; }
            public dynamic language { get; set; }
        }



        public class DettagliWikiData
        {
            public string NomeComune { get; set; }
            public string CAP { get; set; }
            public string CodAmm { get; set; }
            public string latitude { get; set; }
            public string longitude { get; set; }
        }

        public class RootWikiData
        {
            public DettagliWikiData Dettagli { get; set; }
        }
    }
}