namespace VetStation.BasicInsertForms
{
    partial class FrmInseminationData
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
            this.clInsemination = new System.Windows.Forms.MonthCalendar();
            this.cmbExpectedSuccess = new System.Windows.Forms.ComboBox();
            this.cmbBullBreed = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBullName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbPersonnel = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbAnimal = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // clInsemination
            // 
            this.clInsemination.Location = new System.Drawing.Point(244, 74);
            this.clInsemination.MaxSelectionCount = 1;
            this.clInsemination.Name = "clInsemination";
            this.clInsemination.TabIndex = 0;
            // 
            // cmbExpectedSuccess
            // 
            this.cmbExpectedSuccess.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbExpectedSuccess.FormattingEnabled = true;
            this.cmbExpectedSuccess.Location = new System.Drawing.Point(15, 68);
            this.cmbExpectedSuccess.Name = "cmbExpectedSuccess";
            this.cmbExpectedSuccess.Size = new System.Drawing.Size(166, 21);
            this.cmbExpectedSuccess.TabIndex = 1;
            // 
            // cmbBullBreed
            // 
            this.cmbBullBreed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBullBreed.FormattingEnabled = true;
            this.cmbBullBreed.Location = new System.Drawing.Point(15, 160);
            this.cmbBullBreed.Name = "cmbBullBreed";
            this.cmbBullBreed.Size = new System.Drawing.Size(163, 21);
            this.cmbBullBreed.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Očekivani uspjeh";
            // 
            // txtBullName
            // 
            this.txtBullName.Location = new System.Drawing.Point(15, 116);
            this.txtBullName.Name = "txtBullName";
            this.txtBullName.Size = new System.Drawing.Size(166, 20);
            this.txtBullName.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Ime bika";
            // 
            // cmbPersonnel
            // 
            this.cmbPersonnel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPersonnel.FormattingEnabled = true;
            this.cmbPersonnel.Location = new System.Drawing.Point(244, 25);
            this.cmbPersonnel.Name = "cmbPersonnel";
            this.cmbPersonnel.Size = new System.Drawing.Size(199, 21);
            this.cmbPersonnel.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 144);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Pasmina bika";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Životinja";
            // 
            // cmbAnimal
            // 
            this.cmbAnimal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAnimal.FormattingEnabled = true;
            this.cmbAnimal.Location = new System.Drawing.Point(15, 25);
            this.cmbAnimal.Name = "cmbAnimal";
            this.cmbAnimal.Size = new System.Drawing.Size(163, 21);
            this.cmbAnimal.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(241, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Izvršioc";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(241, 52);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(121, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Datum Unosa Podataka";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(368, 248);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 39);
            this.btnSave.TabIndex = 15;
            this.btnSave.Text = "Spremi";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.ForeColor = System.Drawing.Color.Red;
            this.lblInfo.Location = new System.Drawing.Point(228, 261);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(134, 13);
            this.lblInfo.TabIndex = 16;
            this.lblInfo.Text = "* Podaci uspješno snimljeni";
            this.lblInfo.Visible = false;
            // 
            // FrmInseminationData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 299);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbAnimal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbPersonnel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtBullName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbBullBreed);
            this.Controls.Add(this.cmbExpectedSuccess);
            this.Controls.Add(this.clInsemination);
            this.Name = "FrmInseminationData";
            this.Text = "Osjemenjavanje";
            this.Load += new System.EventHandler(this.FrmInsemination_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MonthCalendar clInsemination;
        private System.Windows.Forms.ComboBox cmbExpectedSuccess;
        private System.Windows.Forms.ComboBox cmbBullBreed;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBullName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbPersonnel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbAnimal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblInfo;
    }
}