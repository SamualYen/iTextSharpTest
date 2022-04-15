using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using iText;
using iText.Layout;
using System.IO;
using iText.Kernel.Pdf;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.Kernel.Colors;

namespace iTextSharpTest
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private void BtnPDF_Clicked(object sender, EventArgs e)
        {
            try
            {
                CreatePdfiOS();
                /*switch (Device.RuntimePlatform)
                {
                    case Device.iOS:
                        CreatePdfiOS();
                        break;

                    case Device.Android:
                    default:
                        break;
                }*/
            }
            catch
            {

            }
            finally
            {

            }
        }
        private void CreatePdfiOS()
        {
            string nowTime = DateTime.Now.ToString("yyyyMMddHHmmss");
            //創建PDFwriter 和 設定檔案路徑名稱
            var defaultPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var iosPath = Path.Combine(defaultPath, "..", "Library");
            var filename = Path.Combine(iosPath, nowTime + ".pdf");
            PdfWriter pdfWriter = new PdfWriter(filename);
            PdfDocument pdf = new PdfDocument(pdfWriter);
            Document _document = new Document(pdf);
            _document.GetPdfDocument();
            //Header
            Paragraph header = new Paragraph("Header")
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                .SetFontSize(20);
            _document.Add(header);
            //Sub Header
            Paragraph subHeader = new Paragraph("Sub Header")
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                .SetFontSize(20);
            _document.Add(subHeader);
            //分隔線
            LineSeparator line = new LineSeparator(new SolidLine());
            _document.Add(line);
            _document.Close();
        }
    }
}
