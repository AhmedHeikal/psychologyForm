namespace phsycologyForm
{
    partial class Backup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Backup));
            this.linguisticGB = new System.Windows.Forms.GroupBox();
            this.saveNewBackupRB = new System.Windows.Forms.RadioButton();
            this.rebackRB = new System.Windows.Forms.RadioButton();
            this.backupDateComboBox = new System.Windows.Forms.ComboBox();
            this.dateLabel = new System.Windows.Forms.Label();
            this.BackupButton = new phsycologyForm.circularButtton();
            this.linguisticGB.SuspendLayout();
            this.SuspendLayout();
            // 
            // linguisticGB
            // 
            this.linguisticGB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linguisticGB.Controls.Add(this.saveNewBackupRB);
            this.linguisticGB.Controls.Add(this.rebackRB);
            this.linguisticGB.Font = new System.Drawing.Font("Sitka Heading", 14.25F, System.Drawing.FontStyle.Bold);
            this.linguisticGB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(57)))), ((int)(((byte)(33)))));
            this.linguisticGB.Location = new System.Drawing.Point(11, 0);
            this.linguisticGB.Name = "linguisticGB";
            this.linguisticGB.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.linguisticGB.Size = new System.Drawing.Size(596, 73);
            this.linguisticGB.TabIndex = 946;
            this.linguisticGB.TabStop = false;
            this.linguisticGB.Text = "نوع العملية";
            // 
            // saveNewBackupRB
            // 
            this.saveNewBackupRB.AutoSize = true;
            this.saveNewBackupRB.Font = new System.Drawing.Font("Sitka Heading", 14.25F);
            this.saveNewBackupRB.ForeColor = System.Drawing.Color.White;
            this.saveNewBackupRB.Location = new System.Drawing.Point(373, 29);
            this.saveNewBackupRB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.saveNewBackupRB.Name = "saveNewBackupRB";
            this.saveNewBackupRB.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.saveNewBackupRB.Size = new System.Drawing.Size(217, 32);
            this.saveNewBackupRB.TabIndex = 91;
            this.saveNewBackupRB.TabStop = true;
            this.saveNewBackupRB.Text = "حفظ حالة قواعد البيانات الحالية";
            this.saveNewBackupRB.UseVisualStyleBackColor = true;
            // 
            // rebackRB
            // 
            this.rebackRB.AutoSize = true;
            this.rebackRB.Font = new System.Drawing.Font("Sitka Heading", 14.25F);
            this.rebackRB.ForeColor = System.Drawing.Color.White;
            this.rebackRB.Location = new System.Drawing.Point(6, 29);
            this.rebackRB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rebackRB.Name = "rebackRB";
            this.rebackRB.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rebackRB.Size = new System.Drawing.Size(347, 32);
            this.rebackRB.TabIndex = 90;
            this.rebackRB.TabStop = true;
            this.rebackRB.Text = "استرجاع حالة قواعد بيانات قديمة وحفظ الحالة الحالية";
            this.rebackRB.UseVisualStyleBackColor = true;
            this.rebackRB.CheckedChanged += new System.EventHandler(this.rebackRB_CheckedChanged);
            // 
            // backupDateComboBox
            // 
            this.backupDateComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.backupDateComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.backupDateComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.backupDateComboBox.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.backupDateComboBox.ForeColor = System.Drawing.Color.White;
            this.backupDateComboBox.FormattingEnabled = true;
            this.backupDateComboBox.Location = new System.Drawing.Point(143, 82);
            this.backupDateComboBox.Name = "backupDateComboBox";
            this.backupDateComboBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.backupDateComboBox.Size = new System.Drawing.Size(314, 27);
            this.backupDateComboBox.TabIndex = 1003;
            // 
            // dateLabel
            // 
            this.dateLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateLabel.AutoSize = true;
            this.dateLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.dateLabel.Font = new System.Drawing.Font("Sitka Heading", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(242)))), ((int)(((byte)(234)))));
            this.dateLabel.Location = new System.Drawing.Point(463, 82);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(50, 28);
            this.dateLabel.TabIndex = 1004;
            this.dateLabel.Text = "بتاريخ";
            // 
            // BackupButton
            // 
            this.BackupButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(204)))), ((int)(((byte)(142)))));
            this.BackupButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BackupButton.Font = new System.Drawing.Font("Tempus Sans ITC", 13.8F, System.Drawing.FontStyle.Bold);
            this.BackupButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(57)))), ((int)(((byte)(33)))));
            this.BackupButton.Location = new System.Drawing.Point(242, 117);
            this.BackupButton.Name = "BackupButton";
            this.BackupButton.Size = new System.Drawing.Size(135, 38);
            this.BackupButton.TabIndex = 1005;
            this.BackupButton.Text = "حفظ";
            this.BackupButton.UseVisualStyleBackColor = false;
            this.BackupButton.Click += new System.EventHandler(this.BackupButton_Click);
            // 
            // Backup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(620, 160);
            this.Controls.Add(this.BackupButton);
            this.Controls.Add(this.dateLabel);
            this.Controls.Add(this.backupDateComboBox);
            this.Controls.Add(this.linguisticGB);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(636, 199);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(636, 199);
            this.Name = "Backup";
            this.Text = "Backup";
            this.linguisticGB.ResumeLayout(false);
            this.linguisticGB.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox linguisticGB;
        private System.Windows.Forms.RadioButton saveNewBackupRB;
        private System.Windows.Forms.RadioButton rebackRB;
        private System.Windows.Forms.ComboBox backupDateComboBox;
        private System.Windows.Forms.Label dateLabel;
        private circularButtton BackupButton;
    }
}