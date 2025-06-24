namespace Lokiproject4.Views
{
    partial class StudentvideoForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmbSubjects = new System.Windows.Forms.ComboBox();
            this.webVideo = new System.Windows.Forms.WebBrowser();
            this.rtbNotes = new System.Windows.Forms.RichTextBox();
            this.btnLoadVideo = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmbSubjects
            // 
            this.cmbSubjects.FormattingEnabled = true;
            this.cmbSubjects.Location = new System.Drawing.Point(61, 19);
            this.cmbSubjects.Name = "cmbSubjects";
            this.cmbSubjects.Size = new System.Drawing.Size(121, 24);
            this.cmbSubjects.TabIndex = 0;
            this.cmbSubjects.SelectedIndexChanged += new System.EventHandler(this.cmbSubjects_SelectedIndexChanged);
            // 
            // webVideo
            // 
            this.webVideo.Location = new System.Drawing.Point(12, 124);
            this.webVideo.MinimumSize = new System.Drawing.Size(20, 20);
            this.webVideo.Name = "webVideo";
            this.webVideo.Size = new System.Drawing.Size(600, 350);
            this.webVideo.TabIndex = 1;
            this.webVideo.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webVideo_DocumentCompleted);
            // 
            // rtbNotes
            // 
            this.rtbNotes.Location = new System.Drawing.Point(233, 12);
            this.rtbNotes.Name = "rtbNotes";
            this.rtbNotes.Size = new System.Drawing.Size(229, 96);
            this.rtbNotes.TabIndex = 2;
            this.rtbNotes.Text = "";
            // 
            // btnLoadVideo
            // 
            this.btnLoadVideo.Location = new System.Drawing.Point(526, 41);
            this.btnLoadVideo.Name = "btnLoadVideo";
            this.btnLoadVideo.Size = new System.Drawing.Size(75, 23);
            this.btnLoadVideo.TabIndex = 3;
            this.btnLoadVideo.Text = "show";
            this.btnLoadVideo.UseVisualStyleBackColor = true;
            this.btnLoadVideo.Click += new System.EventHandler(this.btnLoadVideo_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "select";
            // 
            // StudentvideoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 491);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLoadVideo);
            this.Controls.Add(this.rtbNotes);
            this.Controls.Add(this.webVideo);
            this.Controls.Add(this.cmbSubjects);
            this.Name = "StudentvideoForm";
            this.Text = "StudentvideoForm";
            this.Load += new System.EventHandler(this.StudentvideoForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbSubjects;
        private System.Windows.Forms.WebBrowser webVideo;
        private System.Windows.Forms.RichTextBox rtbNotes;
        private System.Windows.Forms.Button btnLoadVideo;
        private System.Windows.Forms.Label label1;
    }
}