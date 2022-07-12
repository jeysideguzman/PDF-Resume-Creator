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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnJSON_Click(object sender, EventArgs e)
        {
            ResumeInfo info = new ResumeInfo
            {
                Name = "John Carlo De Guzman",
                Age = 19,
                Date_of_Birth = "Dec. 18, 2002",
                Email = "jcdeguzan@gmail.com",
                Address = "Lapnit,San Ildefonso,Bulacan",
                Contact_No = 0912345678,
                Description = "A dedicated student looking for work. I am willing to use my abilities and passion to achieve a company's objective. I am technologically competent, offering experience with many different social media networks, office technology programs, and advanced computer skills. establishing a positive mindset as well as the willingness and motivation to learn new programs.",
                Education_History = "PRIMARY: Calasag Elementary School Salutatorian(2014-2015) / SECONDARY: Carlos F. Gonzales High School Graduated with honors (2018-2019)"
            };
            string JsonOutput = JsonConvert.SerializeObject(info);
            richTextBox1.Text = JsonOutput;
        }

        private void btnPDF_Click(object sender, EventArgs e)
        {
            Document doc = new Document();
            PdfWriter.GetInstance(doc, new FileStream("Resume.pdf", FileMode.Create));
            doc.Open();
            Paragraph info = new Paragraph(richTextBox1.Text);
            doc.Add(info);
            doc.Close();
            MessageBox.Show("PDF successfully created!", "PDF Creator", MessageBoxButtons.OK);
        }
    }
}
