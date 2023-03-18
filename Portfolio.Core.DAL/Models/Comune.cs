using static PortFolio.Core.DAL.ViewModels.IndicePA;
using static PortFolio.Core.DAL.ViewModels.Istat;
using static PortFolio.Core.DAL.ViewModels.WikiData;

namespace PortFolio.Core.DAL.Models
{
    public class Comune
    {
        public string Nome { get; set; }
        public string Regione { get; set; }
        public string Provincia { get; set; }
        public DettagliIstat DettagliIstat { get; set; }
        public DettagliIndicePA DettagliIndicePA { get; set; }
        public DettagliWikiData DettagliWikiData { get; set; }
    }
}
