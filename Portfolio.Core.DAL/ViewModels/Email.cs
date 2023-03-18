namespace PortFolio.Core.DAL.ViewModels
{
    public class Email
    {
        public string Nominativo { get; set; }
        public string EmailMittente { get; set; }
        public string Oggetto { get; set; }
        public string Corpo { get; set; }
        public Alert alert { get; set; }
    }
}
