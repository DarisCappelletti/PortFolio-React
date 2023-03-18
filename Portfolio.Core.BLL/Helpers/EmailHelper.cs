using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net.Mail;

namespace Portfolio.Core.BLL.Helpers
{
    public static class EmailHelper
    {
        public static void Send(string message, ICollection<String> a, ICollection<String> cc = null, string subject = "Richiesta sito Daris")
        {
            // prendo dal web config i parametri per l'invio mail
            var mailFrom = ConfigurationManager.AppSettings["email.indirizzo"];
            var mailSmtp = ConfigurationManager.AppSettings["SmtpServer"];
            var port = Convert.ToInt32(ConfigurationManager.AppSettings["Porta"]);
            var password = ConfigurationManager.AppSettings["email.password"];

            // preparo l'email
            //var smtpClient = new SmtpClient(mailSmtp, port);
            var gmailClient = new System.Net.Mail.SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new System.Net.NetworkCredential(mailFrom, password)
            };

            gmailClient.DeliveryMethod = SmtpDeliveryMethod.Network;

            var mail = new MailMessage
            {
                From = new MailAddress(mailFrom, "Daris Portfolio"),
                Body = message,
                Subject = subject
            };
            foreach (var email in a)
            {
                mail.To.Add(new MailAddress(email));
            }

            if(cc != null)
            {
                foreach (var email in cc)
                {
                    mail.CC.Add(new MailAddress(email));
                }
            }

            mail.IsBodyHtml = true;

            // invio l'email
            gmailClient.Send(mail);
        }

        public static string sendPEC(MailAddress mailAddressTO, string subject, string body, Dictionary<string, byte[]> allegati, bool isBodyHtml = false)
        {
            string result = "";

            try
            {
                string ConfSmtp = "";  //Get_Parametro("IpEmailPECAttivazioneCOC");
                string IndirizzoEmailDa = "";  //Get_Parametro("IndirizzoEmailPECAttivazioneCOC");
                string PswEmailDa = "";  //Get_Parametro("PswEmailPECAttivazioneCOC");


                if (ConfSmtp == "")
                    throw new Exception("Smpt non configurato");

                if (IndirizzoEmailDa == "")
                    throw new Exception("Indirizzo Email del mittente non trovata");


                SmtpClient smtpServer = new SmtpClient(ConfSmtp, 25);
                smtpServer.Credentials = new System.Net.NetworkCredential(IndirizzoEmailDa, PswEmailDa);
                smtpServer.EnableSsl = true;

                MailMessage Msg = new MailMessage();
                Msg.From = new MailAddress(IndirizzoEmailDa, IndirizzoEmailDa);
                Msg.To.Add(mailAddressTO);
                Msg.Body = body;
                Msg.BodyEncoding = System.Text.Encoding.UTF8;

                ///*Allego i file*////
                if (allegati != null && allegati.Count > 0)
                {
                    foreach (var alleg in allegati)
                    {
                        Stream oAll = new MemoryStream(alleg.Value);
                        Attachment Allegato = new Attachment(oAll, "application/pdf");
                        Allegato.Name = alleg.Key;
                        Msg.Attachments.Add(Allegato);
                    }
                }

                Msg.Subject = subject;
                smtpServer.Send(Msg);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                result = ex.Message;
            }

            return result;
        }
    }
}