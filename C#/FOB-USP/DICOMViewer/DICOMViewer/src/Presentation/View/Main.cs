using DICOMViewer.Domain.Interfaces;
using DICOMViewer.Presenter;
using DICOMViewer.src.Presentation.UserControls;

namespace DICOMViewer.Presentation.View
{
    public partial class Main : Form, IMain
    {
        private readonly ImagePresenter _imagePresenter;
        PictureBox IMain.pbImage => pbImage;

        public Main()
        {
            InitializeComponent();
            _imagePresenter = new ImagePresenter(this);
            pbImage.MouseWheel += PbImage_MouseWheel;
        }

        public Size ImageAreaSize => pbImage.Size;

        public void ResetControls()
        {
            UI(() =>
            {
                btnCancel.Enabled = false;
                btnCancel.Refresh();
                btnOpen.Enabled = true;
                btnOpen.Refresh();
                btnSave.Enabled = false;
                btnSave.Refresh();
                lblCount.Text = "0 / 0";
                lblCount.Visible = false;
                lblCount.Refresh();
                lblExam.Text = "0 / 0";
                lblExam.Visible = false;
                lblExam.Refresh();
                pbImage.Image = null;
                pbProgress.Value = 0;
                pbProgress.Visible = false;
                pbProgress.Refresh();
                trackBar.Value = 0;
                trackBar.Visible = false;
                trackBar.Refresh();
                txtResolution.Enabled = true;
                txtResolution.Refresh();
            });

        }

        public void ShowImage(Bitmap bmp)
        {
            UI(() => pbImage.Image = bmp);
        }

        public void UpdateLoadCounter(int value, int total)
        {
            UI(() =>
            {
                lblCount.Visible = true;
                lblCount.Text = $"{value} / {total}";
            });
        }

        public void UpdateExamCounter(int value, int total)
        {
            UI(() =>
            {
                lblExam.Visible = true;
                lblExam.Text = $"{value} / {total}";
            });

        }

        // public void UpdateSaveProgress(int value, int max)
        // {
        //     UI(() =>
        //     {
        //         pbProgress.Visible = value < max;
        //         pbProgress.Maximum = Math.Max(1, max);
        //         pbProgress.Value = Math.Min(value, pbProgress.Maximum);
        //     });
        // }

        public void UpdateProgressBar(int value, int total)
        {
            UI(() =>
            {
                pbProgress.Visible = value < total;
                pbProgress.Maximum = total;
                pbProgress.Value = value;
            });
        }

        public void SetTrackbar(int max)
        {
            UI(() =>
            {
                trackBar.Visible = true;
                trackBar.Minimum = 0;
                trackBar.Maximum = max;
            });
        }


        public void SetTrackbarValue(int index)
        {
            trackBar.Value = index;
        }

        public void SetLoadingState(bool isLoading)
        {
            UI(() =>
            {
                btnOpen.Enabled = !isLoading;
                btnCancel.Enabled = isLoading;
                txtResolution.Enabled = !isLoading;
            });
        }


        public void SetSavingState(bool isSaving)
        {
            UI(() =>
            {
                btnSave.Enabled = !isSaving;
                btnCancel.Enabled = isSaving;
            });
        }


        private async void btnOpen_Click(object sender, EventArgs e)
        {
            using var dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                int resolution = Convert.ToInt32(txtResolution.Text);
                await _imagePresenter.OpenAsync(dialog.SelectedPath, resolution);
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            using var dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                int resolution = Convert.ToInt32(txtResolution.Text);
                await _imagePresenter.SaveAsync(dialog.SelectedPath, resolution);

            }
        }

        private void trackBar_ValueChanged(object sender, EventArgs e)
        {
            _imagePresenter.DisplayImage(trackBar.Value);
        }

        private void PbImage_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0 && trackBar.Value < trackBar.Maximum)
                trackBar.Value++;
            else if (e.Delta < 0 && trackBar.Value > trackBar.Minimum)
                trackBar.Value--;
        }

        private void txtResolution_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

            _imagePresenter.Cancel();
            ResetControls();

        }

        public void UI(Action action)
        {
            if (InvokeRequired)
                Invoke(action);
            else
                action();
        }

        private void flowLayoutPanel1_Layout(object sender, LayoutEventArgs e)
        {
            UI(() =>
            {
                flowLayoutPanel1.Padding = (flowLayoutPanel1.VerticalScroll.Visible) ? new Padding(21, 0, 0, 0)
                                                                                     : new Padding(30, 0, 0, 0);

            });
        }
    }
}
