using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FellowOakDicom;

namespace DICOMViewer.src.Presentation.UserControls
{
    public partial class ExamControl : UserControl
    {
        public string _seriesDescription;
        public int _index;

        public ExamControl(int index, string seriesDescription, Bitmap image)
        {
            InitializeComponent();
            _index = index;
            _seriesDescription = seriesDescription;
            //lblSeriesDescription.Text = seriesDescription;
            //pnlImage.BackgroundImage = image;
        }

        private void ExamControl_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(new Pen(Color.White, 0.5f), 0, this.Height-1, this.Width, this.Height-1);
        }
    }
}
