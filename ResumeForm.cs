using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDF_Resume_Creator
{
    public partial class ResumeForm : Form
    {
        public ResumeForm()
        {
            InitializeComponent();
        }

        private void ResumeForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            PDF_Creator form = new PDF_Creator();
            form.ShowDialog();
        }
    }
}
