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
        {   //CREATING JSON FILE USING C#
            //install json.net
            // using class ResumeInfo

            ResumeInfo Rinfo = new ResumeInfo
            {
                Name = "John Carlo B. De Guzman",
                pwork = "Front-end Developer",
                Age = 19,
                Date_of_Birth = "Dec. 18, 2002",
                Email = "jcdeguzman18@gmail.com",
                Address = "Lapnit,San Ildefonso,Bulacan",
                Contact_No = 0163457698,
                Profile = "A dedicated person looking for work. I am willing to use my abilities and passion to achieve a company's objective. I am technologically competent, offering experience with many different social media networks, office technology programs, and advanced computer skills. establishing a positive mindset as well as the willingness and motivation to learn new programs.",
                Education_History = new List<string>()
                {
                    "Primary: Lapnit Elementary School | Salutatorian(2014-2015)",
                    "Secondary: Carlos F. Gonzales High School | Graduated with honors (2018-2019)",
                    "Tertiary: Polytechnic University of the Philipphine | Computer Engineering Graduate"
                },
               
                PersonalSkills = new List<string>()
                {
                    "HTML",
                    "CSS",
                    "JavaScript",
                    "jQuery",
                    "Problem Solving",
                    "Logical Thinking",
                    "Interpersonal Skills"
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
            iTextSharp.text.Font f_28_bold = new iTextSharp.text.Font(TNR, 28, iTextSharp.text.Font.BOLD);
            iTextSharp.text.Font f_20_bold = new iTextSharp.text.Font(TNR, 20, iTextSharp.text.Font.BOLD);
            iTextSharp.text.Font f_16_bold = new iTextSharp.text.Font(TNR, 16, iTextSharp.text.Font.BOLD);
            iTextSharp.text.Font f_14_normal = new iTextSharp.text.Font(TNR, 14, iTextSharp.text.Font.NORMAL);
            PdfWriter.GetInstance(doc, new FileStream("DE GUZMAN_JOHN CARLO.pdf", FileMode.Create)); // usePDFWriter

            doc.Open();

            PdfPTable name = new PdfPTable(1);
            name.DefaultCell.BorderWidth = 0;
            name.WidthPercentage = 100;
            name.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;

            PdfPTable work = new PdfPTable(1);
            work.DefaultCell.BorderWidth = 0;
            work.WidthPercentage = 100;
            work.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;

            PdfPTable line0 = new PdfPTable(1);
            line0.DefaultCell.BorderWidth = 0;
            line0.WidthPercentage = 100;
            line0.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;

            PdfPTable pinfo = new PdfPTable(1);
            pinfo.DefaultCell.BorderWidth = 0;
            pinfo.WidthPercentage = 100;
            pinfo.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;

            PdfPTable email = new PdfPTable(1);
            email.DefaultCell.BorderWidth = 0;
            email.WidthPercentage = 100;
            email.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;

            PdfPTable age = new PdfPTable(1);
            age.DefaultCell.BorderWidth = 0;
            age.WidthPercentage = 100;
            age.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;

            PdfPTable bday = new PdfPTable(1);
            bday.DefaultCell.BorderWidth = 0;
            bday.WidthPercentage = 100;
            bday.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;

            PdfPTable address = new PdfPTable(1);
            address.DefaultCell.BorderWidth = 0;
            address.WidthPercentage = 100;
            address.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;

            PdfPTable cp_no = new PdfPTable(1);
            cp_no.DefaultCell.BorderWidth = 0;
            cp_no.WidthPercentage = 100;
            cp_no.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;

            PdfPTable line1 = new PdfPTable(1);
            line1.DefaultCell.BorderWidth = 0;
            line1.WidthPercentage = 100;
            line1.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;

            PdfPTable profile = new PdfPTable(1);
            profile.DefaultCell.BorderWidth = 0;
            profile.WidthPercentage = 100;
            profile.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;

            PdfPTable profileinfo = new PdfPTable(1);
            profileinfo.DefaultCell.BorderWidth = 0;
            profileinfo.WidthPercentage = 100;
            profileinfo.DefaultCell.HorizontalAlignment = Element.ALIGN_JUSTIFIED_ALL;
            
            PdfPTable line2 = new PdfPTable(1);
            line2.DefaultCell.BorderWidth = 0;
            line2.WidthPercentage = 100;
            line2.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;

            PdfPTable educhistory = new PdfPTable(1);
            educhistory.DefaultCell.BorderWidth = 0;
            educhistory.WidthPercentage = 100;
            educhistory.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;

            PdfPTable primary = new PdfPTable(1);
            primary.DefaultCell.BorderWidth = 0;
            primary.WidthPercentage = 100;
            primary.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;

            PdfPTable secondary = new PdfPTable(1);
            secondary.DefaultCell.BorderWidth = 0;
            secondary.WidthPercentage = 100;
            secondary.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;

            PdfPTable tertiary = new PdfPTable(1);
            tertiary.DefaultCell.BorderWidth = 0;
            tertiary.WidthPercentage = 100;
            tertiary.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;

            PdfPTable line3 = new PdfPTable(1);
            line3.DefaultCell.BorderWidth = 0;
            line3.WidthPercentage = 100;
            line3.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;

            PdfPTable skills = new PdfPTable(1);
            skills.DefaultCell.BorderWidth = 0;
            skills.WidthPercentage = 100;
            skills.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;

            PdfPTable one = new PdfPTable(1);
            one.DefaultCell.BorderWidth = 0;
            one.WidthPercentage = 100;
            one.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;

            PdfPTable two = new PdfPTable(1);
            two.DefaultCell.BorderWidth = 0;
            two.WidthPercentage = 100;
            two.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;

            PdfPTable three = new PdfPTable(1);
            three.DefaultCell.BorderWidth = 0;
            three.WidthPercentage = 100;
            three.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;

            PdfPTable four = new PdfPTable(1);
            four.DefaultCell.BorderWidth = 0;
            four.WidthPercentage = 100;
            four.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;

            PdfPTable five = new PdfPTable(1);
            five.DefaultCell.BorderWidth = 0;
            five.WidthPercentage = 100;
            five.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;

            PdfPTable six = new PdfPTable(1);
            six.DefaultCell.BorderWidth = 0;
            six.WidthPercentage = 100;
            six.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;

            //NAME
            Chunk NAME = new Chunk("JOHN CARLO DE GUZMAN", f_28_bold);
            Chunk WORK = new Chunk("Front-end Developer", f_16_bold);
            PdfPCell LINE0 = new PdfPCell(new Phrase("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━", f_16_bold));
            //PROFILE
            Chunk PINFO = new Chunk("PERSONAL INFORMATION", f_20_bold);
            Chunk EMAIL = new Chunk("Email: jcdeguzman18@gmail.com", f_14_normal);
            Chunk AGE = new Chunk("Age: 19", f_14_normal);
            Chunk DATEOFBIRTH = new Chunk("Date of Birth: December 18, 2002", f_14_normal);
            Chunk ADDRESS = new Chunk("Address: Lapnit,San Ildefonso,Bulacan", f_14_normal);
            Chunk PHONENUM = new Chunk("Contact No.: 0163457698", f_14_normal);
            PdfPCell LINE1 = new PdfPCell(new Phrase("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━", f_16_bold));
            
            Chunk PROFILE = new Chunk("PROFILE", f_20_bold);
            Chunk PROFILEINFO = new Chunk("A dedicated person looking for work. I am willing to use my abilities and passion to achieve a company's objective. I am technologically competent, offering experience with many different social media networks, office technology programs, and advanced computer skills. establishing a positive mindset as well as the willingness and motivation to learn new programs.", f_14_normal);
            PdfPCell LINE2 = new PdfPCell(new Phrase("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━", f_16_bold));
           
            //EDUCATION HISTORY
            Chunk EDUCHIS = new Chunk("EDUCATION HISTORY", f_20_bold);
            PdfPCell PRIMARY = new PdfPCell(new Phrase("•" + " PRIMARY: Lapnit Elementary School | Salutatorian(2014-2015)", f_14_normal));
            PdfPCell SECONDARY = new PdfPCell(new Phrase("•" + " SECONDARY: Carlos F. Gonzales High School | Graduated with honors (2018-2019)", f_14_normal));
            PdfPCell TERTIARY = new PdfPCell(new Phrase("•" + " TERTIARY: Polytechnic University of the Philipphine | Computer Engineering Graduate", f_14_normal));
            PdfPCell LINE3 = new PdfPCell(new Phrase("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━", f_16_bold));
                                                       
            //SKILLS
            Chunk SKILLS = new Chunk("SKILLS", f_20_bold);
            PdfPCell ONE = new PdfPCell(new Phrase("•" + " HTML", f_14_normal));
            PdfPCell TWO = new PdfPCell(new Phrase("•" + " JavaScript", f_14_normal));
            PdfPCell THREE = new PdfPCell(new Phrase("•" + " jQuery", f_14_normal));
            PdfPCell FOUR = new PdfPCell(new Phrase("•" + " Problem Solving", f_14_normal));
            PdfPCell FIVE = new PdfPCell(new Phrase("•" + " Logical Thinking", f_14_normal));
            PdfPCell SIX = new PdfPCell(new Phrase("•" + " Interpersonal Skills", f_14_normal));
            //BORDERS
            PRIMARY.Border = iTextSharp.text.Rectangle.NO_BORDER;
            SECONDARY.Border = iTextSharp.text.Rectangle.NO_BORDER;
            TERTIARY.Border = iTextSharp.text.Rectangle.NO_BORDER;
            ONE.Border = iTextSharp.text.Rectangle.NO_BORDER;
            TWO.Border = iTextSharp.text.Rectangle.NO_BORDER;
            THREE.Border = iTextSharp.text.Rectangle.NO_BORDER;
            FOUR.Border = iTextSharp.text.Rectangle.NO_BORDER;
            FIVE.Border = iTextSharp.text.Rectangle.NO_BORDER;
            SIX.Border = iTextSharp.text.Rectangle.NO_BORDER;
            

            name.AddCell(new Phrase(NAME));
            work.AddCell(new Phrase(WORK));
            line0.AddCell(LINE0);
            pinfo.AddCell(new Phrase(PINFO));
            email.AddCell(new Phrase(EMAIL));
            age.AddCell(new Phrase(AGE));
            bday.AddCell(new Phrase(DATEOFBIRTH));
            address.AddCell(new Phrase(ADDRESS));
            cp_no.AddCell(new Phrase(PHONENUM));
            line1.AddCell(LINE1);
            profile.AddCell(new Phrase(PROFILE));
            profileinfo.AddCell(new Phrase(PROFILEINFO));
            line2.AddCell(LINE2);
            educhistory.AddCell(new Phrase(EDUCHIS));
            primary.AddCell(PRIMARY);
            secondary.AddCell(SECONDARY);
            tertiary.AddCell(TERTIARY);
            line3.AddCell(LINE3);
            skills.AddCell(new Phrase(SKILLS));
            one.AddCell(ONE);
            two.AddCell(TWO);
            three.AddCell(THREE);
            four.AddCell(FOUR);
            five.AddCell(FIVE);
            six.AddCell(SIX);

            doc.Add(name);
            doc.Add(work);
            doc.Add(line0);
            doc.Add(pinfo);
            doc.Add(email);
            doc.Add(age);
            doc.Add(bday);
            doc.Add(address);
            doc.Add(cp_no);
            doc.Add(line1);
            doc.Add(profile);
            doc.Add(profileinfo);
            doc.Add(line2);
            doc.Add(educhistory);
            doc.Add(primary);
            doc.Add(secondary);
            doc.Add(tertiary);
            doc.Add(line3);
            doc.Add(skills);
            doc.Add(one);
            doc.Add(two);
            doc.Add(three);
            doc.Add(four);
            doc.Add(five);
            doc.Add(six);

            doc.Close();
            MessageBox.Show("PDF successfully created!", "PDF Creator", MessageBoxButtons.OK);

        }  

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
