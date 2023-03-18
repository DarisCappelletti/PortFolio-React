using System;
using System.Collections.Generic;
using System.Web;
using System.Xml.Serialization;

namespace PortFolio.Core.DAL.ViewModels
{
    public class Bio
    {
        public string File { get; set; }
        public string Sequid { get; set; }
        public string Source { get; set; }
        public string Type { get; set; }
        public string Start { get; set; }
        public string End { get; set; }
        public string Score { get; set; }
        public string Strand { get; set; }
        public string Phase { get; set; }
        public string[] Attributes { get; set; }
    }

    public class InColonne
    {
        public bool inFile { get; set; }
        public bool inSequid { get; set; }
        public bool inSource { get; set; }
        public bool inType { get; set; }
        public bool inStart { get; set; }
        public bool inEnd { get; set; }
        public bool inScore { get; set; }
        public bool inStrand { get; set; }
        public bool inPhase { get; set; }
        public bool inAttributes { get; set; }
    }
}