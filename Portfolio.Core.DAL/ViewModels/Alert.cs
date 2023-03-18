using Portfolio.Core.DAL.Enums;

namespace PortFolio.Core.DAL.ViewModels
{
    public class Alert
    {
        public Alerts Tipo { get; set; }
        public string Intestazione { get; set; }
        public string Messaggio { get; set; }
    }
}
