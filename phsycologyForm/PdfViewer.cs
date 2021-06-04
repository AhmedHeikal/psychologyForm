using System;
using System.Linq;
using System.Windows.Forms;

namespace phsycologyForm
{
    public partial class PdfViewer : Form
    {
        string location;
        public PdfViewer(string location = "")
        {
            InitializeComponent();
            this.location = location;
        }

        private void PdfViewer_Load(object sender, EventArgs e)
        {
            if (location != string.Empty)
            {
                this.pdfViewer1.LoadDocument(location);
            }
        }
    }
}
