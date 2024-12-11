using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ferry_Ticketing_App.Classes
{
    public class TicketPdfGenerator
    {
        public static void GenerateTicketPdf(List<Control> tickets, string outputPath)
        {
            using (FileStream fs = new FileStream(outputPath, FileMode.Create))
            {
                using (Document document = new Document(PageSize.A4, 25, 25, 30, 30))
                {
                    PdfWriter writer = PdfWriter.GetInstance(document, fs);
                    document.Open();

                    foreach (var ticket in tickets)
                    {
                        using (Bitmap bitmap = new Bitmap(ticket.Width, ticket.Height))
                        {
                            ticket.DrawToBitmap(bitmap, new System.Drawing.Rectangle(0, 0, ticket.Width, ticket.Height));
                            using (MemoryStream ms = new MemoryStream())
                            {
                                bitmap.Save(ms, ImageFormat.Png);
                                byte[] imageBytes = ms.ToArray();
                                iTextSharp.text.Image ticketImage = iTextSharp.text.Image.GetInstance(imageBytes);

                                float scale = Math.Min(
                                    (document.PageSize.Width - 50) / ticketImage.Width,
                                    (document.PageSize.Height - 50) / ticketImage.Height
                                );

                                ticketImage.ScalePercent(scale * 100);
                                document.Add(ticketImage);
                                document.NewPage();
                            }
                        }
                    }
                    document.Close();
                }
            }
        }
    }
}
