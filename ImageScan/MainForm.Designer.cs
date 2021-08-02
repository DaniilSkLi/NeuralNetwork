
namespace ImageScan
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.обучитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MNIST_LEARN = new System.Windows.Forms.ToolStripMenuItem();
            this.checkNeuron = new System.Windows.Forms.ToolStripMenuItem();
            this.saveNeural = new System.Windows.Forms.ToolStripMenuItem();
            this.loadNeural = new System.Windows.Forms.ToolStripMenuItem();
            this.status = new System.Windows.Forms.Label();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.progressBarLabel = new System.Windows.Forms.Label();
            this.MNIST_CHECK = new System.Windows.Forms.ToolStripMenuItem();
            this.imageCheck = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.обучитьToolStripMenuItem,
            this.checkNeuron,
            this.saveNeural,
            this.loadNeural});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // обучитьToolStripMenuItem
            // 
            this.обучитьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MNIST_LEARN});
            this.обучитьToolStripMenuItem.Name = "обучитьToolStripMenuItem";
            this.обучитьToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.обучитьToolStripMenuItem.Text = "Обучить";
            // 
            // MNIST_LEARN
            // 
            this.MNIST_LEARN.Name = "MNIST_LEARN";
            this.MNIST_LEARN.Size = new System.Drawing.Size(180, 22);
            this.MNIST_LEARN.Text = "MNIST";
            this.MNIST_LEARN.Click += new System.EventHandler(this.MNIST_LEARN_Click);
            // 
            // checkNeuron
            // 
            this.checkNeuron.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MNIST_CHECK,
            this.imageCheck});
            this.checkNeuron.Name = "checkNeuron";
            this.checkNeuron.Size = new System.Drawing.Size(79, 20);
            this.checkNeuron.Text = "Проверить";
            // 
            // saveNeural
            // 
            this.saveNeural.Name = "saveNeural";
            this.saveNeural.Size = new System.Drawing.Size(78, 20);
            this.saveNeural.Text = "Сохранить";
            this.saveNeural.Click += new System.EventHandler(this.saveNeural_Click);
            // 
            // loadNeural
            // 
            this.loadNeural.Name = "loadNeural";
            this.loadNeural.Size = new System.Drawing.Size(73, 20);
            this.loadNeural.Text = "Загрузить";
            this.loadNeural.Click += new System.EventHandler(this.loadNeural_Click);
            // 
            // status
            // 
            this.status.AutoSize = true;
            this.status.Location = new System.Drawing.Point(12, 33);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(43, 15);
            this.status.TabIndex = 1;
            this.status.Text = "Статус";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "ineural";
            this.saveFileDialog.Filter = "(Image neural network) *.ineural|";
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "ineural";
            this.openFileDialog.FileName = "OpenFile";
            this.openFileDialog.Filter = "(Image neural network) *.ineural|";
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(12, 415);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(776, 23);
            this.progressBar.TabIndex = 2;
            // 
            // progressBarLabel
            // 
            this.progressBarLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBarLabel.Location = new System.Drawing.Point(12, 389);
            this.progressBarLabel.Name = "progressBarLabel";
            this.progressBarLabel.Size = new System.Drawing.Size(776, 23);
            this.progressBarLabel.TabIndex = 3;
            this.progressBarLabel.Text = "0/0";
            this.progressBarLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // MNIST_CHECK
            // 
            this.MNIST_CHECK.Name = "MNIST_CHECK";
            this.MNIST_CHECK.Size = new System.Drawing.Size(180, 22);
            this.MNIST_CHECK.Text = "MNIST";
            this.MNIST_CHECK.Click += new System.EventHandler(this.MNIST_CHECK_Click);
            // 
            // imageCheck
            // 
            this.imageCheck.Name = "imageCheck";
            this.imageCheck.Size = new System.Drawing.Size(180, 22);
            this.imageCheck.Text = "Картинка";
            this.imageCheck.Click += new System.EventHandler(this.imageCheck_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.progressBarLabel);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.status);
            this.Controls.Add(this.menuStrip1);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem обучитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MNIST_LEARN;
        private System.Windows.Forms.Label status;
        private System.Windows.Forms.ToolStripMenuItem checkNeuron;
        private System.Windows.Forms.ToolStripMenuItem saveNeural;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ToolStripMenuItem loadNeural;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label progressBarLabel;
        private System.Windows.Forms.ToolStripMenuItem MNIST_CHECK;
        private System.Windows.Forms.ToolStripMenuItem imageCheck;
    }
}

