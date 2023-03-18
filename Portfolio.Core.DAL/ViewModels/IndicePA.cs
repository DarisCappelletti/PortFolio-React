using System.Collections.Generic;

namespace PortFolio.Core.DAL.ViewModels
{
    public class IndicePA
    {
        // Nuova chiamata GET ENTE
        public class Datum
        {
            public string cod_amm { get; set; }
            public string acronimo { get; set; }
            public string des_amm { get; set; }
        }

        public class Result
        {
            public int cod_err { get; set; }
            public string desc_err { get; set; }
            public int num_items { get; set; }
        }

        public class RootEnte
        {
            public Result result { get; set; }
            public List<Datum> data { get; set; }
        }

        // Nuova POST Dettagli Ente

        public class DettagliIndicePA
        {
            public string cod_amm { get; set; }
            public string acronimo { get; set; }
            public string des_amm { get; set; }
            public string regione { get; set; }
            public string provincia { get; set; }
            public string comune { get; set; }
            public string cap { get; set; }
            public string indirizzo { get; set; }
            public string titolo_resp { get; set; }
            public string nome_resp { get; set; }
            public string cogn_resp { get; set; }
            public string sito_istituzionale { get; set; }
            public object liv_access { get; set; }
            public string mail1 { get; set; }
            public string mail2 { get; set; }
            public string mail3 { get; set; }
            public string mail4 { get; set; }
            public string mail5 { get; set; }
            public string tipologia { get; set; }
            public string categoria { get; set; }
            public string data_accreditamento { get; set; }
            public string cf { get; set; }
        }

        public class ResultIndicePA
        {
            public int cod_err { get; set; }
            public string desc_err { get; set; }
            public int num_items { get; set; }
        }

        public class RootIndicePA
        {
            public ResultIndicePA result { get; set; }
            public DettagliIndicePA data { get; set; }
        }
    }
}
