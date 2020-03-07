namespace SetupTv.Sections
{
    partial class DSVideoControl_Setup
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
            this.browsebutton = new System.Windows.Forms.Button();
            this.pathtoexe = new System.Windows.Forms.TextBox();
            this.folderBrowserTool = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // browsebutton
            // 
            this.browsebutton.Location = new System.Drawing.Point(294, 40);
            this.browsebutton.Name = "browsebutton";
            this.browsebutton.Size = new System.Drawing.Size(37, 23);
            this.browsebutton.TabIndex = 0;
            this.browsebutton.Text = "...";
            this.browsebutton.UseVisualStyleBackColor = true;
            this.browsebutton.Click += new System.EventHandler(this.browsebutton_Click);
            // 
            // pathtoexe
            // 
            this.pathtoexe.Location = new System.Drawing.Point(28, 41);
            this.pathtoexe.Name = "pathtoexe";
            this.pathtoexe.Size = new System.Drawing.Size(260, 22);
            this.pathtoexe.TabIndex = 2;
            // 
            // folderBrowserTool
            // 
            this.folderBrowserTool.HelpRequest += new System.EventHandler(this.folderBrowserTool_HelpRequest);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pathtoexe);
            this.groupBox1.Controls.Add(this.browsebutton);
            this.groupBox1.Location = new System.Drawing.Point(55, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(405, 209);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // DSVideoControl_Setup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "DSVideoControl_Setup";
            this.Size = new System.Drawing.Size(800, 450);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button browsebutton;
        private System.Windows.Forms.TextBox pathtoexe;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserTool;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}