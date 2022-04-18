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
using iText.Kernel.Font;
using Xamarin.Essentials;

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
        private void BtnPDF2_Clicked(object sender, EventArgs e)
        {
            try
            {
                CreatePdfAndroid();
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
            //iText.Kernel.Font.PdfFontFactory.Register("simhei.ttf");
            string nowTime = DateTime.Now.ToString("yyyyMMddHHmmss");
            //創建PDFwriter 和 設定檔案路徑名稱
            string defaultPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string filename = Path.Combine(defaultPath, nowTime + ".pdf");
            PdfWriter pdfWriter = new PdfWriter(filename);
            PdfDocument pdf = new PdfDocument(pdfWriter);
            Document _document = new Document(pdf);
            //string rootPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            //string folderPath = Path.Combine(rootPath, "Resources");
            //string fontFile = Path.Combine(folderPath, "NotoSansTC-Regular.otf");
            //string fontFile = "/../NotoSansTC-Regular.otf";
            //PdfFont pdfFont = PdfFontFactory.CreateFont(fontFile, PdfFontFactory.EmbeddingStrategy.FORCE_EMBEDDED);
            ///PdfFont pdfFont = PdfFontFactory.CreateRegisteredFont("simhei.ttf", "" ,PdfFontFactory.EmbeddingStrategy.FORCE_EMBEDDED);
            //PdfFont pdfFont = PdfFontFactory.CreateFont("STSongStd-Light", "UniGB-UCS2-H",PdfFontFactory.EmbeddingStrategy.FORCE_EMBEDDED);
            //_document.SetFont(pdfFont);
            //Header
            string ttF = "times.ttf";
            PdfFont pdfFont = PdfFontFactory.CreateFont(ttF, PdfFontFactory.EmbeddingStrategy.FORCE_NOT_EMBEDDED);
            _document.SetFont(pdfFont);
            
            Paragraph header = new Paragraph("圓 安 生 技 股 份 有 限 公 司Yuan An Group")
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                .SetFontSize(20);
            _document.Add(header);
            //Sub Header
            Paragraph subHeader = new Paragraph("轉  帳  傳  票Transefer Invoice")
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                .SetFontSize(20);
            _document.Add(subHeader);
            //分隔線
            LineSeparator line = new LineSeparator(new SolidLine());
            _document.Add(line);
            //創建空表格
            Table table = new Table(4, false);
            //創建欄位 由左到右 由上到下
            iText.Layout.Element.Cell ce11 = new iText.Layout.Element.Cell(1, 1)
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                .Add(new Paragraph("會  計  項  目ACCOUNTING"));
            table.AddCell(ce11);

            iText.Layout.Element.Cell ce12 = new iText.Layout.Element.Cell(1, 1)
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                .Add(new Paragraph("摘Info                                    要"));
            table.AddCell(ce12);

            iText.Layout.Element.Cell ce13 = new iText.Layout.Element.Cell(1, 1)
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                .Add(new Paragraph("借 方 金 額"));
            table.AddCell(ce13);

            iText.Layout.Element.Cell ce14 = new iText.Layout.Element.Cell(1, 1)
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                .Add(new Paragraph("貸 方 金 額"));
            table.AddCell(ce14);

            iText.Layout.Element.Cell ce21 = new iText.Layout.Element.Cell(1, 1)
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT)
                .Add(new Paragraph("直接人工"));
            table.AddCell(ce21);

            iText.Layout.Element.Cell ce22 = new iText.Layout.Element.Cell(1, 1)
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT)
                .Add(new Paragraph("110/12/13-12/23生產部作業員薪資"));
            table.AddCell(ce22);

            iText.Layout.Element.Cell ce23 = new iText.Layout.Element.Cell(1, 1)
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.RIGHT)
                .Add(new Paragraph("56320"));
            table.AddCell(ce23);

            iText.Layout.Element.Cell ce24 = new iText.Layout.Element.Cell(1, 1)
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.RIGHT)
                .Add(new Paragraph(""));
            table.AddCell(ce24);
            iText.Layout.Element.Cell ce31 = new iText.Layout.Element.Cell(1, 1)
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT)
                .Add(new Paragraph("製-加班費"));
            table.AddCell(ce31);

            iText.Layout.Element.Cell ce32 = new iText.Layout.Element.Cell(1, 1)
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT)
                .Add(new Paragraph("12/21生產部作業員加班費"));
            table.AddCell(ce32);

            iText.Layout.Element.Cell ce33 = new iText.Layout.Element.Cell(1, 1)
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.RIGHT)
                .Add(new Paragraph("1704"));
            table.AddCell(ce33);

            iText.Layout.Element.Cell ce34 = new iText.Layout.Element.Cell(1, 1)
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.RIGHT)
                .Add(new Paragraph(""));
            table.AddCell(ce34);

            iText.Layout.Element.Cell ce41 = new iText.Layout.Element.Cell(1, 1)
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT)
                .Add(new Paragraph("應付費用"));
            table.AddCell(ce41);

            iText.Layout.Element.Cell ce42 = new iText.Layout.Element.Cell(1, 1)
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT)
                .Add(new Paragraph("110/12/13-12/23生產部作業員薪資"));
            table.AddCell(ce42);

            iText.Layout.Element.Cell ce43 = new iText.Layout.Element.Cell(1, 1)
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.RIGHT)
                .Add(new Paragraph(""));
            table.AddCell(ce43);

            iText.Layout.Element.Cell ce44 = new iText.Layout.Element.Cell(1, 1)
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.RIGHT)
                .Add(new Paragraph("58024"));
            table.AddCell(ce44);

            iText.Layout.Element.Cell ce51 = new iText.Layout.Element.Cell(1, 1)
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT)
                .Add(new Paragraph(""));
            table.AddCell(ce51);

            iText.Layout.Element.Cell ce52 = new iText.Layout.Element.Cell(1, 1)
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT)
                .Add(new Paragraph(""));
            table.AddCell(ce52);

            iText.Layout.Element.Cell ce53 = new iText.Layout.Element.Cell(1, 1)
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.RIGHT)
                .Add(new Paragraph(""));
            table.AddCell(ce53);

            iText.Layout.Element.Cell ce54 = new iText.Layout.Element.Cell(1, 1)
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.RIGHT)
                .Add(new Paragraph(""));
            table.AddCell(ce54);
            iText.Layout.Element.Cell ce61 = new iText.Layout.Element.Cell(1, 1)
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT)
                .Add(new Paragraph(""));
            table.AddCell(ce61);

            iText.Layout.Element.Cell ce62 = new iText.Layout.Element.Cell(1, 1)
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT)
                .Add(new Paragraph(""));
            table.AddCell(ce62);

            iText.Layout.Element.Cell ce63 = new iText.Layout.Element.Cell(1, 1)
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.RIGHT)
                .Add(new Paragraph(""));
            table.AddCell(ce63);

            iText.Layout.Element.Cell ce64 = new iText.Layout.Element.Cell(1, 1)
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.RIGHT)
                .Add(new Paragraph(""));
            table.AddCell(ce64);
            //表格尾端合計
            iText.Layout.Element.Cell ce71 = new iText.Layout.Element.Cell(1, 2)
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                .Add(new Paragraph("合                                      計"));
            table.AddCell(ce71);

            iText.Layout.Element.Cell ce72 = new iText.Layout.Element.Cell(1, 1)
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.RIGHT)
                .Add(new Paragraph("58024"));
            table.AddCell(ce72);

            iText.Layout.Element.Cell ce73 = new iText.Layout.Element.Cell(1, 1)
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.RIGHT)
                .Add(new Paragraph("58024"));
            table.AddCell(ce73);

            /*iText.Layout.Element.Cell ce74 = new iText.Layout.Element.Cell(1, 1)
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.RIGHT)
                .Add(new Paragraph(""));
            table.AddCell(ce74);*/

            _document.Add(table);
            _document.Close();
        }
        private void CreatePdfAndroid()
        {
            string nowTime = DateTime.Now.ToString("yyyyMMddHHmmss");
            //創建PDFwriter 和 設定檔案路徑名稱
            var defaultPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var filename = Path.Combine(defaultPath, nowTime + ".pdf");
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
