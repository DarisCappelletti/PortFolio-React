using PortFolio.Core.DAL.ViewModels;
using SelectPdf;
using System;
using System.IO;
using System.IO.Compression;
using System.Web;
using System.Xml.Serialization;

namespace Portfolio.Core.BLL.Helpers
{
    public static class CurriculumGeneratorHelper
    {
        public static CvZipFile ImpostaOggettoCV(Curriculum1 cv, string filePath)
        {
            var html = "";
            using (StreamReader sr = new StreamReader(filePath))
            {
                html = sr.ReadToEnd();
            }

            html = ImpostaVariabiliSuHtml(html, cv);

            var file = GeneraZip(html, cv);

            return file;
        }

        public static string ImpostaVariabiliSuHtml(string html, Curriculum1 cv)
        {
            var immagineProfilo = "";
            // Converto l'immagine in base64
            if (cv.imgBase64 == null)
            {
                immagineProfilo = cv.hidImgBase64;
            }
            else
            {
                if (cv.imgBase64 != null && cv.imgBase64.Length > 0)
                {

                    string fileName = Path.GetFileName(cv.imgBase64.FileName);
                    byte[] byteArray = new byte[cv.imgBase64.Length];
                    using (BinaryReader theReader = new BinaryReader(cv.imgBase64.OpenReadStream()))
                    {
                        byteArray = theReader.ReadBytes((int)cv.imgBase64.Length);
                    }
                    immagineProfilo = Convert.ToBase64String(byteArray);
                    cv.hidImgBase64 = immagineProfilo;
                }
            }

            html =
                html
                .Replace("{{ImgBase64}}", immagineProfilo)
                .Replace("{{Nome}}", cv.anagrafica.Nome)
                .Replace("{{Cognome}}", cv.anagrafica.Cognome)
                .Replace("{{Eta}}", cv.anagrafica.Eta)
                .Replace("{{Nazionalita}}", cv.anagrafica.Nazionalita)
                .Replace("{{Lingua}}", cv.anagrafica.Lingua)
                .Replace("{{Telefono}}", cv.contatti.Telefono)
                .Replace("{{Email}}", cv.contatti.Email)
                .Replace("{{Indirizzo}}", cv.contatti.Indirizzo)
                .Replace("{{SitoWeb}}", cv.contatti.SitoWeb)
                .Replace("{{Percorso1}}", cv.percorsoDiStudi.Percorso1)
                .Replace("{{PercorsoLuogo1}}", cv.percorsoDiStudi.PercorsoLuogo1)
                .Replace("{{Percorso2}}", cv.percorsoDiStudi.Percorso2)
                .Replace("{{PercorsoLuogo2}}", cv.percorsoDiStudi.PercorsoLuogo2)
                .Replace("{{Skills}}", cv.skills)
                .Replace("{{Profilo}}", cv.profilo)
                .Replace("{{Professione}}", cv.esperienzaLavorativa.Professione)
                .Replace("{{Azienda}}", cv.esperienzaLavorativa.Azienda)
                .Replace("{{Inizio}}", cv.esperienzaLavorativa.DataInizio)
                .Replace("{{Fine}}", cv.esperienzaLavorativa.DataFine)
                .Replace("{{Descrizione}}", cv.esperienzaLavorativa.Descrizione);

            html = ReplaceSkills(html, cv);
            html = ReplaceProgettiPersonali(html, cv);

            return html;
        }

        public static string ReplaceProgettiPersonali(string html, Curriculum1 cv)
        {
            if(cv.progettiPersonali != null)
            {
                int i = 1;
                foreach (var progetto in cv.progettiPersonali)
                {
                    var pro = "{{Progetto" + i + "}}";
                    var linguaggio = "{{ProgettoLinguaggio" + i + "}}";
                    html =
                        html
                        .Replace(pro, progetto.Progetto)
                        .Replace(linguaggio, progetto.Linguaggio);
                    i = i + 1;
                }
            }

            return html;
        }

        public static string ReplaceSkills(string html, Curriculum1 cv)
        {
            var scheletro =
                "<div class=\"row border-left\">" +
                    "<div class=\"column w-10 p-0\">" +
                        "<!-- icona arrow-->" +
                        "<svg class=\"svg-inline--fa fa-arrow-right-long icona-width\" aria-hidden=\"true\" focusable=\"false\" data-prefix=\"fas\" data-icon=\"arrow-right-long\" role=\"img\" xmlns=\"http://www.w3.org/2000/svg\" viewBox=\"0 0 512 512\" data-fa-i2svg=\"\"><path fill=\"currentColor\" d=\"M502.6 278.6c12.5-12.5 12.5-32.8 0-45.3l-128-128c-12.5-12.5-32.8-12.5-45.3 0s-12.5 32.8 0 45.3L402.7 224 32 224c-17.7 0-32 14.3-32 32s14.3 32 32 32l370.7 0-73.4 73.4c-12.5 12.5-12.5 32.8 0 45.3s32.8 12.5 45.3 0l128-128z\"></path></svg>" +
                    "</div>" +
                    "<div class=\"column w-90 p-0\">" +
                        "<h3 class=\"m-0\">{{Skill}}</h3>" +
                            "</div>" +
                        "</div>";
            int i = 1;
            var skills = !String.IsNullOrEmpty(cv.skills) ? cv.skills.Split(',') : null;

            if (skills != null)
            {
                foreach (var skill in skills)
                {
                    var anchor = "{{Skill-" + i + "}}";
                    var scheletroConSkill = scheletro.Replace("{{Skill}}", skill);
                    html =
                        html
                        .Replace(anchor, scheletroConSkill);
                    i = i + 1;
                }

                if (skills.Length < 11)
                {
                    // Rimpiazzo tutte le skill con un campo vuoto
                    int inizio = skills.Length + 1;
                    for (int num = inizio; num <= 11; num++)
                    {
                        var anchor = "{{Skill-" + num + "}}";
                        html =
                            html
                            .Replace(anchor, "");
                    }
                }
            }
            else
            {
                // Rimpiazzo tutte le skill con un campo vuoto
                for (int num = 1; num <= 11; num++)
                {
                    var anchor = "{{Skill-" + num + "}}";
                    html =
                        html
                        .Replace(anchor, "");
                    num++;
                }
            }

            return html;
        }

        public static PdfDocument GeneraPDF(string html)
        {
            // Uso la libreria SelectPDF community edition

            // Imposto il foglio in formato A4
            string pdf_page_size = "A4";
            PdfPageSize pageSize = (PdfPageSize)Enum.Parse(typeof(PdfPageSize),
                pdf_page_size, true);

            // Imposto l'orientamento verticale
            string pdf_orientation = "Portrait";
            PdfPageOrientation pdfOrientation =
                (PdfPageOrientation)Enum.Parse(typeof(PdfPageOrientation),
                pdf_orientation, true);

            // Imposto le dimensioni della pagina
            int webPageWidth = 840;
            int webPageHeight = 1188;

            // Instanzio l'oggetto HtmlToPdf
            HtmlToPdf converter = new HtmlToPdf();

            // Imposto i parametri
            converter.Options.PdfPageSize = pageSize;
            converter.Options.PdfPageOrientation = pdfOrientation;
            converter.Options.WebPageWidth = webPageWidth;
            converter.Options.WebPageHeight = webPageHeight;

            // Converto l'html nel pdf
            SelectPdf.PdfDocument doc = converter.ConvertHtmlString(html);

            return doc;
        }

        public static CvZipFile GeneraZip(string html, Curriculum1 cv)
        {
            var pdf = GeneraPDF(html);// Imposto il nome del documento
            var nomeDocumentoPdf = $"Curriculum - {cv.anagrafica.Nome} {cv.anagrafica.Cognome} {DateTime.Now.ToShortDateString().Replace("/", "-")}.pdf";
            byte[] fileBytesPdf;

            using (var fileToCompressStreamPdf = new MemoryStream())
            {
                pdf.Save(fileToCompressStreamPdf);
                fileBytesPdf = fileToCompressStreamPdf.ToArray();
            }

            // Generate xml file
            XmlCurriculum xmlCurriculum = new XmlCurriculum
            {
                curriculum = cv
            };
            var xmlSerializer = new XmlSerializer(typeof(XmlCurriculum));
            var nomeDocumentoXml = $"Curriculum - {cv.anagrafica.Nome} {cv.anagrafica.Cognome} {DateTime.Now.ToShortDateString().Replace("/", "-")}.xml";
            byte[] fileBytesXml;

            using (var fileToCompressStreamXml = new MemoryStream())
            {
                xmlSerializer.Serialize(fileToCompressStreamXml, xmlCurriculum);
                fileBytesXml = fileToCompressStreamXml.ToArray();
            }

            byte[] compressedBytes;

            using (var outStream = new MemoryStream())
            {
                using (var archive = new ZipArchive(outStream, ZipArchiveMode.Create, true))
                {
                    var pdfFile = archive.CreateEntry(nomeDocumentoPdf, CompressionLevel.Optimal);
                    using (var entryStream = pdfFile.Open())
                    using (var fileToCompressStreamPdf = new MemoryStream(fileBytesPdf))
                    {
                        fileToCompressStreamPdf.CopyTo(entryStream);
                    }

                    var xml = archive.CreateEntry(nomeDocumentoXml, CompressionLevel.Optimal);
                    using (var entryStream = xml.Open())
                    using (var fileToCompressStreamXml = new MemoryStream(fileBytesXml))
                    {
                        fileToCompressStreamXml.CopyTo(entryStream);
                    }
                }
                compressedBytes = outStream.ToArray();

                var nomeZip = $"Curriculum - {cv.anagrafica.Nome} {cv.anagrafica.Cognome} {DateTime.Now.ToShortDateString().Replace("/", "-")}.zip";

                //HttpResponse response = HttpContext.Current.Response;
                //response.Clear();
                //response.AppendHeader("Content-Disposition", $"attachment; filename={nomeZip}");
                //response.ContentType = "application/zip";
                //response.BinaryWrite(compressedBytes);
                //response.End();
                return new CvZipFile
                {
                    Content = compressedBytes,
                    ContentType = "application/zip",
                    NomeConEstensione = nomeZip
                };
            }
        }

        public static Curriculum1 LeggiValoriDaFileXml(Microsoft.AspNetCore.Http.IFormFile xmlFile)
        {
            if (xmlFile != null)
            {
                try
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(XmlCurriculum));

                    // Declare an object variable of the type to be deserialized.
                    XmlCurriculum cv = (XmlCurriculum)serializer.Deserialize(xmlFile.OpenReadStream());

                    return cv.curriculum;

                    //MasterPage.ShowMessage("File caricato <strong>correttamente</strong>.", Alerts.Successo);
                }
                catch(Exception exc)
                {
                    return null;
                    //MasterPage.ShowMessage("Il file non è in un formato corretto.", Alerts.Errore);
                }
            }
            else
            {
                return null;
            }
        }

        //public static void ImpostaValoriSuTextBox(XmlCurriculum cv)
        //{
        //    if (cv != null)
        //    {
        //        var anagrafica = cv.curriculum.anagrafica;
        //        var contatti = cv.curriculum.contatti;
        //        var percorsiDiStudio = cv.curriculum.percorsoDiStudi;
        //        var profilo = cv.curriculum.profilo;
        //        var esperienzaLavorativa = cv.curriculum.esperienzaLavorativa;
        //        var progettiPersonali = cv.curriculum.progettiPersonali;

        //        hidImmagineProfilo.Value = cv.curriculum.imgBase64;
        //        fileImmagine.Attributes.Clear();
        //        txtNome.Text = anagrafica.Nome;
        //        txtCognome.Text = anagrafica.Cognome;
        //        txtEta.Text = anagrafica.Eta;
        //        txtNazionalita.Text = anagrafica.Nazionalita;
        //        txtLingue.Text = anagrafica.Lingua;
        //        txtTelefono.Text = contatti.Telefono;
        //        txtEmail.Text = contatti.Email;
        //        txtIndirizzo.Text = contatti.Indirizzo;
        //        txtSitoWeb.Text = contatti.SitoWeb;
        //        txtPercorso1.Text = percorsiDiStudio.Percorso1;
        //        txtPercorsoLuogo1.Text = percorsiDiStudio.PercorsoLuogo1;
        //        txtPercorso2.Text = percorsiDiStudio.Percorso2;
        //        txtPercorsoLuogo2.Text = percorsiDiStudio.PercorsoLuogo2;
        //        txtSkills.Text = cv.curriculum.skills;
        //        txtProfilo.Text = profilo;
        //        txtProfessione.Text = esperienzaLavorativa.Professione;
        //        txtAzienda.Text = esperienzaLavorativa.Azienda;
        //        txtDataInizio.Text = esperienzaLavorativa.Inizio;
        //        txtDataFine.Text = esperienzaLavorativa.Fine;
        //        txtDescrizione.Text = esperienzaLavorativa.Descrizione;

        //        for (int i = 1; i <= progettiPersonali.Count; i++)
        //        {
        //            switch (i)
        //            {
        //                case 1:
        //                    txtProgetto1.Text = progettiPersonali[0].Progetto;
        //                    txtProgettoLinguaggio1.Text = progettiPersonali[0].Linguaggio;
        //                    break;
        //                case 2:
        //                    txtProgetto2.Text = progettiPersonali[1].Progetto;
        //                    txtProgettoLinguaggio2.Text = progettiPersonali[1].Linguaggio;
        //                    break;
        //                case 3:
        //                    txtProgetto3.Text = progettiPersonali[2].Progetto;
        //                    txtProgettoLinguaggio3.Text = progettiPersonali[2].Linguaggio;
        //                    break;
        //                case 4:
        //                    txtProgetto4.Text = progettiPersonali[3].Progetto;
        //                    txtProgettoLinguaggio4.Text = progettiPersonali[3].Linguaggio;
        //                    break;
        //                case 5:
        //                    txtProgetto5.Text = progettiPersonali[4].Progetto;
        //                    txtProgettoLinguaggio5.Text = progettiPersonali[4].Linguaggio;
        //                    break;
        //                case 6:
        //                    txtProgetto6.Text = progettiPersonali[5].Progetto;
        //                    txtProgettoLinguaggio6.Text = progettiPersonali[5].Linguaggio;
        //                    break;
        //            }
        //        }
        //    }
        //}
    }
}
