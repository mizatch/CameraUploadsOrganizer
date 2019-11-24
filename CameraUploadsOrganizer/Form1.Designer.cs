namespace CameraUploadsOrganizer
{
    partial class Organizer
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
            this.fbdUploadsFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOpenUploadsDialog = new System.Windows.Forms.Button();
            this.lblCameraUploadsLocation = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.fbdPhotosFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.lblSelectedUploadsLocation = new System.Windows.Forms.Label();
            this.lblSelectedPhotosLocation = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(89, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(489, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Camera Uploads Folder Location";
            // 
            // btnOpenUploadsDialog
            // 
            this.btnOpenUploadsDialog.Location = new System.Drawing.Point(698, 70);
            this.btnOpenUploadsDialog.Name = "btnOpenUploadsDialog";
            this.btnOpenUploadsDialog.Size = new System.Drawing.Size(304, 74);
            this.btnOpenUploadsDialog.TabIndex = 1;
            this.btnOpenUploadsDialog.Text = "Select Folder";
            this.btnOpenUploadsDialog.UseVisualStyleBackColor = true;
            this.btnOpenUploadsDialog.Click += new System.EventHandler(this.btnOpenUploadsDialog_Click);
            // 
            // lblCameraUploadsLocation
            // 
            this.lblCameraUploadsLocation.AutoSize = true;
            this.lblCameraUploadsLocation.Location = new System.Drawing.Point(96, 379);
            this.lblCameraUploadsLocation.Name = "lblCameraUploadsLocation";
            this.lblCameraUploadsLocation.Size = new System.Drawing.Size(0, 37);
            this.lblCameraUploadsLocation.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(698, 588);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(304, 78);
            this.button1.TabIndex = 3;
            this.button1.Text = "Organize Photos";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(89, 393);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(217, 37);
            this.label2.TabIndex = 4;
            this.label2.Text = "Photos Folder";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(698, 374);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(304, 76);
            this.button2.TabIndex = 5;
            this.button2.Text = "Select Folder";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // lblSelectedUploadsLocation
            // 
            this.lblSelectedUploadsLocation.AutoSize = true;
            this.lblSelectedUploadsLocation.Location = new System.Drawing.Point(150, 201);
            this.lblSelectedUploadsLocation.Name = "lblSelectedUploadsLocation";
            this.lblSelectedUploadsLocation.Size = new System.Drawing.Size(0, 37);
            this.lblSelectedUploadsLocation.TabIndex = 6;
            // 
            // lblSelectedPhotosLocation
            // 
            this.lblSelectedPhotosLocation.AutoSize = true;
            this.lblSelectedPhotosLocation.Location = new System.Drawing.Point(150, 496);
            this.lblSelectedPhotosLocation.Name = "lblSelectedPhotosLocation";
            this.lblSelectedPhotosLocation.Size = new System.Drawing.Size(0, 37);
            this.lblSelectedPhotosLocation.TabIndex = 7;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // Organizer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(19F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 724);
            this.Controls.Add(this.lblSelectedPhotosLocation);
            this.Controls.Add(this.lblSelectedUploadsLocation);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblCameraUploadsLocation);
            this.Controls.Add(this.btnOpenUploadsDialog);
            this.Controls.Add(this.label1);
            this.Name = "Organizer";
            this.Text = "Camera Uploads Organizer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog fbdUploadsFolder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOpenUploadsDialog;
        private System.Windows.Forms.Label lblCameraUploadsLocation;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.FolderBrowserDialog fbdPhotosFolder;
        private System.Windows.Forms.Label lblSelectedUploadsLocation;
        private System.Windows.Forms.Label lblSelectedPhotosLocation;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}

