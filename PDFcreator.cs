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
            File.WriteAllText(@"PersonalDetails.json", JsonOutput);
            MessageBox.Show("JSON File Stored!");
        }

        private void btnPDF_Click(object sender, EventArgs e)
        {
            //install itextsharp
            Document doc = new Document();
            PdfWriter.GetInstance(doc, new FileStream("DE GUZMAN_JOHN CARLO.pdf", FileMode.Create)); // usePDFWriter
            doc.Open();
            Paragraph info = new Paragraph(richTextBox1.Text);
            doc.Add(info);
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
