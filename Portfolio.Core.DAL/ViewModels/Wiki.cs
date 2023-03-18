using System.Collections.Generic;

namespace PortFolio.Core.DAL.ViewModels
{
    public class Wiki
    {
        public class WikiDataDescription
        {
            public string value { get; set; }
            public string language { get; set; }
        }

        public class WikiDataDisplay
        {
            public WikiDataLabel label { get; set; }
            public WikiDataDescription description { get; set; }
        }

        public class WikiDataLabel
        {
            public string value { get; set; }
            public string language { get; set; }
        }

        public class Match
        {
            public string type { get; set; }
            public string language { get; set; }
            public string text { get; set; }
        }

        public class WikiDataRoot
        {
            public WikiDataSearchinfo searchinfo { get; set; }
            public List<WikiDataSearch> search { get; set; }
            public int SearchContinue { get; set; }
            public int success { get; set; }
        }

        public class WikiDataSearch
        {
            public string id { get; set; }
            public string title { get; set; }
            public int pageid { get; set; }
            public WikiDataDisplay display { get; set; }
            public string repository { get; set; }
            public string url { get; set; }
            public string concepturi { get; set; }
            public string label { get; set; }
            public string description { get; set; }
            public Match match { get; set; }
        }

        public class WikiDataSearchinfo
        {
            public string search { get; set; }
        }
    }
}
