namespace DICOMViewer.Presentation.View
{
    partial class Main
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblResolution;
        private System.Windows.Forms.TextBox txtResolution;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnOpen;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            pnlButtons = new Panel();
            btnCancel = new Button();
            lblResolution = new Label();
            txtResolution = new TextBox();
            lblCount = new Label();
            btnSave = new Button();
            btnOpen = new Button();
            splitContainer1 = new SplitContainer();
            flowLayoutPanel1 = new FlowLayoutPanel();
            pbProgress = new ProgressBar();
            trackBar = new TrackBar();
            lblExam = new Label();
            pbImage = new PictureBox();
            pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbImage).BeginInit();
            SuspendLayout();
            // 
            // pnlButtons
            // 
            pnlButtons.Anchor = AnchorStyles.None;
            pnlButtons.Controls.Add(btnCancel);
            pnlButtons.Controls.Add(lblResolution);
            pnlButtons.Controls.Add(txtResolution);
            pnlButtons.Controls.Add(lblCount);
            pnlButtons.Controls.Add(btnSave);
            pnlButtons.Controls.Add(btnOpen);
            pnlButtons.Location = new Point(-3, 0);
            pnlButtons.Margin = new Padding(0);
            pnlButtons.Name = "pnlButtons";
            pnlButtons.Size = new Size(1080, 42);
            pnlButtons.TabIndex = 2;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.None;
            btnCancel.Enabled = false;
            btnCancel.Location = new Point(688, 8);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(133, 27);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "Cancelar";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // lblResolution
            // 
            lblResolution.AutoSize = true;
            lblResolution.Location = new Point(6, 12);
            lblResolution.Name = "lblResolution";
            lblResolution.Size = new Size(64, 15);
            lblResolution.TabIndex = 4;
            lblResolution.Text = "Resolução:";
            // 
            // txtResolution
            // 
            txtResolution.Location = new Point(71, 8);
            txtResolution.MaxLength = 3;
            txtResolution.Name = "txtResolution";
            txtResolution.Size = new Size(40, 23);
            txtResolution.TabIndex = 3;
            txtResolution.Text = "300";
            txtResolution.TextAlign = HorizontalAlignment.Center;
            txtResolution.KeyPress += txtResolution_KeyPress;
            // 
            // lblCount
            // 
            lblCount.Anchor = AnchorStyles.None;
            lblCount.Location = new Point(935, 14);
            lblCount.Name = "lblCount";
            lblCount.Size = new Size(66, 15);
            lblCount.TabIndex = 2;
            lblCount.Text = "0 / 0";
            lblCount.TextAlign = ContentAlignment.MiddleRight;
            lblCount.Visible = false;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.None;
            btnSave.Enabled = false;
            btnSave.Location = new Point(488, 8);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(133, 27);
            btnSave.TabIndex = 1;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnOpen
            // 
            btnOpen.Anchor = AnchorStyles.None;
            btnOpen.Location = new Point(288, 8);
            btnOpen.Name = "btnOpen";
            btnOpen.Size = new Size(133, 27);
            btnOpen.TabIndex = 0;
            btnOpen.Text = "Abrir";
            btnOpen.UseVisualStyleBackColor = true;
            btnOpen.Click += btnOpen_Click;
            // 
            // splitContainer1
            // 
            splitContainer1.Anchor = AnchorStyles.Right;
            splitContainer1.BackColor = Color.LightSteelBlue;
            splitContainer1.Location = new Point(-5, 42);
            splitContainer1.Margin = new Padding(10, 0, 0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.BackColor = Color.FromArgb(20, 20, 20);
            splitContainer1.Panel1.Controls.Add(flowLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.BackColor = Color.Black;
            splitContainer1.Panel2.Controls.Add(pbProgress);
            splitContainer1.Panel2.Controls.Add(trackBar);
            splitContainer1.Panel2.Controls.Add(lblExam);
            splitContainer1.Panel2.Controls.Add(pbImage);
            splitContainer1.Size = new Size(1080, 790);
            splitContainer1.SplitterDistance = 240;
            splitContainer1.TabIndex = 3;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel1.BackColor = Color.Black;
            flowLayoutPanel1.BackgroundImageLayout = ImageLayout.None;
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Margin = new Padding(0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Padding = new Padding(21, 0, 0, 0);
            flowLayoutPanel1.Size = new Size(240, 790);
            flowLayoutPanel1.TabIndex = 0;
            flowLayoutPanel1.WrapContents = false;
            flowLayoutPanel1.Layout += flowLayoutPanel1_Layout;
            // 
            // pbProgress
            // 
            pbProgress.BackColor = Color.Black;
            pbProgress.Location = new Point(0, 782);
            pbProgress.Margin = new Padding(0);
            pbProgress.Name = "pbProgress";
            pbProgress.Size = new Size(836, 13);
            pbProgress.TabIndex = 3;
            pbProgress.Visible = false;
            // 
            // trackBar
            // 
            trackBar.Anchor = AnchorStyles.None;
            trackBar.BackColor = Color.Black;
            trackBar.Location = new Point(794, 6);
            trackBar.Name = "trackBar";
            trackBar.Orientation = Orientation.Vertical;
            trackBar.Size = new Size(45, 779);
            trackBar.TabIndex = 2;
            trackBar.ValueChanged += trackBar_ValueChanged;
            // 
            // lblExam
            // 
            lblExam.Anchor = AnchorStyles.None;
            lblExam.ForeColor = Color.White;
            lblExam.Location = new Point(708, 17);
            lblExam.Name = "lblExam";
            lblExam.Size = new Size(66, 15);
            lblExam.TabIndex = 6;
            lblExam.Text = "0 / 0";
            lblExam.TextAlign = ContentAlignment.MiddleRight;
            lblExam.Visible = false;
            // 
            // pbImage
            // 
            pbImage.Anchor = AnchorStyles.None;
            pbImage.BackColor = Color.Black;
            pbImage.BackgroundImage = (Image)resources.GetObject("pbImage.BackgroundImage");
            pbImage.BackgroundImageLayout = ImageLayout.Stretch;
            pbImage.Location = new Point(1, 0);
            pbImage.Margin = new Padding(0);
            pbImage.Name = "pbImage";
            pbImage.Size = new Size(790, 790);
            pbImage.TabIndex = 0;
            pbImage.TabStop = false;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSteelBlue;
            ClientSize = new Size(1075, 832);
            Controls.Add(pnlButtons);
            Controls.Add(splitContainer1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Name = "Main";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "DICOM Viewer";
            pnlButtons.ResumeLayout(false);
            pnlButtons.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)trackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbImage).EndInit();
            ResumeLayout(false);
        }

        private SplitContainer splitContainer1;
        private ProgressBar pbProgress;
        private TrackBar trackBar;
        private Label lblExam;
        private PictureBox pbImage;
        private FlowLayoutPanel flowLayoutPanel1;
    }
}
