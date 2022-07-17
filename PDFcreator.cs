using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace PDF_Resume_Creator
{
    public partial class PDF_Creator : Form
    {
        public PDF_Creator()
        {
            InitializeComponent();
        }

        private void btnJSON_Click(object sender, EventArgs e)
        {
            //install json.net
            // using class ResumeInfo

            ResumeInfo Rinfo = new ResumeInfo
            {
                Name = "John Carlo B. De Guzman",
                Age = 19,
                Date_of_Birth = "Dec. 18, 2002",
                Email = "jcdeguzman18@gmail.com",
                Address = "Lapnit,San Ildefonso,Bulacan",
                Contact_No = 0163457698,
                Language = new List<string>()
                {
                    "ENGLISH",
                    "FILIPINO"
                },
                Profile = "A dedicated student looking for work. I am willing to use my abilities and passion to achieve a company's objective. I am technologically competent, offering experience with many different social media networks, office technology programs, and advanced computer skills. establishing a positive mindset as well as the willingness and motivation to learn new programs.",
                PrimaryEducation_History = "Lapnit Elementary School",
                SecondaryEducation_History = "Carlos F. Gonzales High School",
                Achievement = new List<string>()
                {
                    "Salutatorian(2014-2015)",
                    "Graduated with honors (2018-2019)"
                },
                PersonalSkills = new List<string>()
                {
                    "Communication Skills",
                    "Problem Solving Skills",
                    "Leadership",
                    "Creativity",
                    "Social Media Platform",
                    "Logical Thinking",
                    "Work Under Pressure"
                }

            };
            

            string JsonOutput = JsonConvert.SerializeObject(Rinfo);
            richTextBox1.Text = JsonOutput;
            File.WriteAllText(@"PersonalDetails.json", JsonOutput);//create json file
            MessageBox.Show("JSON File Stored!");
        }

        private void btnPDF_Click(object sender, EventArgs e)
        {
            //install itextsharp{
            Document doc = new Document(PageSize.A4, 60, 75, 60, 75);
            BaseFont TNR = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font f_20_bold = new iTextSharp.text.Font(TNR, 20, iTextSharp.text.Font.BOLD);
            iTextSharp.text.Font f_15_normal = new iTextSharp.text.Font(TNR, 15, iTextSharp.text.Font.NORMAL);
            iTextSharp.text.Font f_14_normal = new iTextSharp.text.Font(TNR, 14, iTextSharp.text.Font.NORMAL);
            PdfWriter.GetInstance(doc, new FileStream("GUZMAN_JOHN CARLO.pdf", FileMode.Create)); // usePDFWriter

            doc.Open();

            PdfPTable table = new PdfPTable(1);
            table.DefaultCell.BorderWidth = 0;
            table.WidthPercentage = 100;
            table.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;

            PdfPTable profile = new PdfPTable(1);
            profile.DefaultCell.BorderWidth = 0;
            profile.WidthPercentage = 100;
            profile.DefaultCell.HorizontalAlignment = Element.ALIGN_JUSTIFIED_ALL;
            
            PdfPTable hl = new PdfPTable(1);
            hl.DefaultCell.BorderWidth = 0;
            hl.WidthPercentage = 100;
            hl.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;

            PdfPTable aa = new PdfPTable(1);
            aa.DefaultCell.BorderWidth = 0;
            aa.WidthPercentage = 100;
            aa.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;

            PdfPTable ab = new PdfPTable(1);
            ab.DefaultCell.BorderWidth = 0;
            ab.WidthPercentage = 100;
            ab.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;

            PdfPTable ac = new PdfPTable(1);
            ac.DefaultCell.BorderWidth = 0;
            ac.WidthPercentage = 100;
            ac.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;


            Chunk name = new Chunk("JOHN CARLO DE GUZMAN", f_20_bold);
            Chunk PROFILE = new Chunk("\n\nA dedicated student looking for work. I am willing to use my abilities and passion to achieve a company's objective. I am technologically competent, offering experience with many different social media networks, office technology programs, and advanced computer skills. establishing a positive mindset as well as the willingness and motivation to learn new programs.", f_14_normal);
            Chunk line = new Chunk("--------------------------------------------------------------------", f_20_bold);
            Chunk achievment = new Chunk("ACHIEVEMENT", f_20_bold);
            PdfPCell sal = new PdfPCell(new Phrase("•" + " Salutatorian", f_14_normal));
            PdfPCell aaa = new PdfPCell(new Phrase("•" + " With Honors", f_14_normal));

            sal.Border = iTextSharp.text.Rectangle.NO_BORDER;
            aaa.Border = iTextSharp.text.Rectangle.NO_BORDER;

            table.AddCell(new Phrase(name));
            profile.AddCell(new Phrase(PROFILE));
            hl.AddCell(new Phrase(line));
            aa.AddCell(new Phrase(achievment));
            ab.AddCell(sal);
            ac.AddCell(aaa);

            doc.Add(table);
            doc.Add(profile);
            doc.Add(hl);
            doc.Add(aa);
            doc.Add(ab);
            doc.Add(ac);

            doc.Close();
            MessageBox.Show("PDF successfully created!", "PDF Creator", MessageBoxButtons.OK);

            }


        private void button1_Click_1(object sender, EventArgs e)
        {
            ResumeForm form = new ResumeForm();
            form.ShowDialog();
        }
    }
}
