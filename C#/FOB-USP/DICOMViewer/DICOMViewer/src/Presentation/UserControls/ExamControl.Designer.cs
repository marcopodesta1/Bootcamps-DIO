namespace DICOMViewer.src.Presentation.UserControls
{
    partial class ExamControl
    {
        /// <summary> 
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if(disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExamControl));
            pnlImage = new Panel();
            lblSeriesDescription = new Label();
            SuspendLayout();
            // 
            // pnlImage
            // 
            pnlImage.BackColor = Color.Transparent;
            pnlImage.BackgroundImage = (Image)resources.GetObject("pnlImage.BackgroundImage");
            pnlImage.BackgroundImageLayout = ImageLayout.Stretch;
            pnlImage.Location = new Point(52, 0);
            pnlImage.Margin = new Padding(0);
            pnlImage.Name = "pnlImage";
            pnlImage.Size = new Size(85, 65);
            pnlImage.TabIndex = 0;
            // 
            // lblSeriesDescription
            // 
            lblSeriesDescription.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblSeriesDescription.BackColor = Color.Transparent;
            lblSeriesDescription.Font = new Font("Roboto", 9.5F);
            lblSeriesDescription.ForeColor = Color.Snow;
            lblSeriesDescription.Location = new Point(3, 60);
            lblSeriesDescription.Name = "lblSeriesDescription";
            lblSeriesDescription.Size = new Size(185, 25);
            lblSeriesDescription.TabIndex = 1;
            lblSeriesDescription.Text = "Scout";
            lblSeriesDescription.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ExamControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            Controls.Add(pnlImage);
            Controls.Add(lblSeriesDescription);
            Name = "ExamControl";
            Size = new Size(191, 83);
            Paint += ExamControl_Paint;
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlImage;
        private Label lblSeriesDescription;
    }
}
