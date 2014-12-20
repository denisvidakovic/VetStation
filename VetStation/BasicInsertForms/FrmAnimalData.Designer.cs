namespace VetStation
{
    partial class FrmAnimalData
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
            this.txtRegNumber_Animal = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBreed = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.clAnimal = new System.Windows.Forms.MonthCalendar();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbOwners = new System.Windows.Forms.ComboBox();
            this.cmbBreed = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnAddNewBreed = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.btnAddNewType = new System.Windows.Forms.Button();
            this.rbMale = new System.Windows.Forms.RadioButton();
            this.rbFemale = new System.Windows.Forms.RadioButton();
            this.label10 = new System.Windows.Forms.Label();
            this.btnAddNewOwne = new System.Windows.Forms.Button();
            this.cmbAge = new System.Windows.Forms.ComboBox();
            this.lblInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtRegNumber_Animal
            // 
            this.txtRegNumber_Animal.Location = new System.Drawing.Point(15, 109);
            this.txtRegNumber_Animal.Name = "txtRegNumber_Animal";
            this.txtRegNumber_Animal.Size = new System.Drawing.Size(160, 20);
            this.txtRegNumber_Animal.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 93);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "Registarski broj zivotinje";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(202, 127);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Starost";
            // 
            // txtBreed
            // 
            this.txtBreed.Location = new System.Drawing.Point(15, 68);
            this.txtBreed.Name = "txtBreed";
            this.txtBreed.Size = new System.Drawing.Size(160, 20);
            this.txtBreed.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Pasmina";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(15, 25);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(160, 20);
            this.txtName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Ime";
            // 
            // clAnimal
            // 
            this.clAnimal.Location = new System.Drawing.Point(520, 25);
            this.clAnimal.MaxSelectionCount = 1;
            this.clAnimal.Name = "clAnimal";
            this.clAnimal.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(517, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "Datum Unosa Podataka";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(640, 207);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(79, 36);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "Spremi";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(201, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 13);
            this.label7.TabIndex = 29;
            this.label7.Text = "Vlasnik";
            // 
            // cmbOwners
            // 
            this.cmbOwners.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOwners.FormattingEnabled = true;
            this.cmbOwners.Location = new System.Drawing.Point(204, 25);
            this.cmbOwners.Name = "cmbOwners";
            this.cmbOwners.Size = new System.Drawing.Size(186, 21);
            this.cmbOwners.TabIndex = 5;
            // 
            // cmbBreed
            // 
            this.cmbBreed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBreed.FormattingEnabled = true;
            this.cmbBreed.Location = new System.Drawing.Point(204, 65);
            this.cmbBreed.Name = "cmbBreed";
            this.cmbBreed.Size = new System.Drawing.Size(186, 21);
            this.cmbBreed.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(201, 49);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 13);
            this.label8.TabIndex = 32;
            this.label8.Text = "Vrsta";
            // 
            // btnAddNewBreed
            // 
            this.btnAddNewBreed.Location = new System.Drawing.Point(396, 59);
            this.btnAddNewBreed.Name = "btnAddNewBreed";
            this.btnAddNewBreed.Size = new System.Drawing.Size(120, 29);
            this.btnAddNewBreed.TabIndex = 10;
            this.btnAddNewBreed.Text = "Dodaj novu vrstu";
            this.btnAddNewBreed.UseVisualStyleBackColor = true;
            this.btnAddNewBreed.Click += new System.EventHandler(this.btnAddNewBreed_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(201, 87);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(22, 13);
            this.label9.TabIndex = 35;
            this.label9.Text = "Tip";
            // 
            // cmbType
            // 
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(204, 103);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(186, 21);
            this.cmbType.TabIndex = 7;
            // 
            // btnAddNewType
            // 
            this.btnAddNewType.Location = new System.Drawing.Point(396, 97);
            this.btnAddNewType.Name = "btnAddNewType";
            this.btnAddNewType.Size = new System.Drawing.Size(120, 30);
            this.btnAddNewType.TabIndex = 11;
            this.btnAddNewType.Text = "Dodaj novi tip";
            this.btnAddNewType.UseVisualStyleBackColor = true;
            this.btnAddNewType.Click += new System.EventHandler(this.btnAddNewType_Click);
            // 
            // rbMale
            // 
            this.rbMale.AutoSize = true;
            this.rbMale.Location = new System.Drawing.Point(14, 149);
            this.rbMale.Name = "rbMale";
            this.rbMale.Size = new System.Drawing.Size(34, 17);
            this.rbMale.TabIndex = 3;
            this.rbMale.TabStop = true;
            this.rbMale.Text = "M";
            this.rbMale.UseVisualStyleBackColor = true;
            // 
            // rbFemale
            // 
            this.rbFemale.AutoSize = true;
            this.rbFemale.Location = new System.Drawing.Point(54, 149);
            this.rbFemale.Name = "rbFemale";
            this.rbFemale.Size = new System.Drawing.Size(31, 17);
            this.rbFemale.TabIndex = 4;
            this.rbFemale.TabStop = true;
            this.rbFemale.Text = "F";
            this.rbFemale.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(13, 132);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(28, 13);
            this.label10.TabIndex = 39;
            this.label10.Text = "Spol";
            // 
            // btnAddNewOwne
            // 
            this.btnAddNewOwne.Location = new System.Drawing.Point(396, 25);
            this.btnAddNewOwne.Name = "btnAddNewOwne";
            this.btnAddNewOwne.Size = new System.Drawing.Size(120, 28);
            this.btnAddNewOwne.TabIndex = 9;
            this.btnAddNewOwne.Text = "Dodaj novog vlasnika";
            this.btnAddNewOwne.UseVisualStyleBackColor = true;
            this.btnAddNewOwne.Click += new System.EventHandler(this.btnAddNewOwne_Click);
            // 
            // cmbAge
            // 
            this.cmbAge.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAge.FormattingEnabled = true;
            this.cmbAge.Location = new System.Drawing.Point(204, 143);
            this.cmbAge.Name = "cmbAge";
            this.cmbAge.Size = new System.Drawing.Size(186, 21);
            this.cmbAge.TabIndex = 8;
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.ForeColor = System.Drawing.Color.Red;
            this.lblInfo.Location = new System.Drawing.Point(364, 222);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(141, 13);
            this.lblInfo.TabIndex = 41;
            this.lblInfo.Text = "* Podaci uspješno spremljeni";
            this.lblInfo.Visible = false;
            // 
            // FrmAnimalData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 255);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.cmbAge);
            this.Controls.Add(this.btnAddNewOwne);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.rbFemale);
            this.Controls.Add(this.rbMale);
            this.Controls.Add(this.btnAddNewType);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cmbType);
            this.Controls.Add(this.btnAddNewBreed);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmbBreed);
            this.Controls.Add(this.cmbOwners);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.clAnimal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtRegNumber_Animal);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtBreed);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.Name = "FrmAnimalData";
            this.Text = "Osnovni podaci o životinji";
            this.Load += new System.EventHandler(this.FrmAnimalData_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtRegNumber_Animal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtBreed;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MonthCalendar clAnimal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbOwners;
        private System.Windows.Forms.ComboBox cmbBreed;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnAddNewBreed;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.Button btnAddNewType;
        private System.Windows.Forms.RadioButton rbMale;
        private System.Windows.Forms.RadioButton rbFemale;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnAddNewOwne;
        private System.Windows.Forms.ComboBox cmbAge;
        private System.Windows.Forms.Label lblInfo;
    }
}