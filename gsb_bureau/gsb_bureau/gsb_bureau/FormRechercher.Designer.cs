namespace gsb_bureau
{
    partial class FormRechercher
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
            this.cbDosage = new System.Windows.Forms.ComboBox();
            this.cbType_individu = new System.Windows.Forms.ComboBox();
            this.cbMedicament = new System.Windows.Forms.ComboBox();
            this.btRechercher = new System.Windows.Forms.Button();
            this.btAnnuler = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbDosage
            // 
            this.cbDosage.FormattingEnabled = true;
            this.cbDosage.Location = new System.Drawing.Point(293, 189);
            this.cbDosage.Name = "cbDosage";
            this.cbDosage.Size = new System.Drawing.Size(169, 21);
            this.cbDosage.TabIndex = 0;
            // 
            // cbType_individu
            // 
            this.cbType_individu.FormattingEnabled = true;
            this.cbType_individu.Location = new System.Drawing.Point(293, 141);
            this.cbType_individu.Name = "cbType_individu";
            this.cbType_individu.Size = new System.Drawing.Size(169, 21);
            this.cbType_individu.TabIndex = 1;
            // 
            // cbMedicament
            // 
            this.cbMedicament.FormattingEnabled = true;
            this.cbMedicament.Location = new System.Drawing.Point(293, 98);
            this.cbMedicament.Name = "cbMedicament";
            this.cbMedicament.Size = new System.Drawing.Size(169, 21);
            this.cbMedicament.TabIndex = 2;
            // 
            // btRechercher
            // 
            this.btRechercher.Location = new System.Drawing.Point(293, 245);
            this.btRechercher.Name = "btRechercher";
            this.btRechercher.Size = new System.Drawing.Size(75, 23);
            this.btRechercher.TabIndex = 3;
            this.btRechercher.Text = "Rechercher";
            this.btRechercher.UseVisualStyleBackColor = true;
            // 
            // btAnnuler
            // 
            this.btAnnuler.Location = new System.Drawing.Point(387, 245);
            this.btAnnuler.Name = "btAnnuler";
            this.btAnnuler.Size = new System.Drawing.Size(75, 23);
            this.btAnnuler.TabIndex = 4;
            this.btAnnuler.Text = "Annuler";
            this.btAnnuler.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(210, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Medicament";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(205, 149);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Type individu";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(231, 197);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Dosage";
            // 
            // FormRechercher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btAnnuler);
            this.Controls.Add(this.btRechercher);
            this.Controls.Add(this.cbMedicament);
            this.Controls.Add(this.cbType_individu);
            this.Controls.Add(this.cbDosage);
            this.Name = "FormRechercher";
            this.Text = "FormRechercher";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbDosage;
        private System.Windows.Forms.ComboBox cbType_individu;
        private System.Windows.Forms.ComboBox cbMedicament;
        private System.Windows.Forms.Button btRechercher;
        private System.Windows.Forms.Button btAnnuler;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}