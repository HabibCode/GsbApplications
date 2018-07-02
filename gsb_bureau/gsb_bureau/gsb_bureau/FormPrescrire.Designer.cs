namespace gsb_bureau
{
    partial class FormPrescrire
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
            this.cbMedicament = new System.Windows.Forms.ComboBox();
            this.cbDosage = new System.Windows.Forms.ComboBox();
            this.tbTypeIndividu = new System.Windows.Forms.TextBox();
            this.tbPosologie = new System.Windows.Forms.TextBox();
            this.btValider = new System.Windows.Forms.Button();
            this.btAnnuler = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btSupp = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbMedicament
            // 
            this.cbMedicament.FormattingEnabled = true;
            this.cbMedicament.Location = new System.Drawing.Point(272, 70);
            this.cbMedicament.Name = "cbMedicament";
            this.cbMedicament.Size = new System.Drawing.Size(185, 21);
            this.cbMedicament.TabIndex = 0;
            this.cbMedicament.SelectedIndexChanged += new System.EventHandler(this.cbMedicament_SelectedIndexChanged);
            this.cbMedicament.Click += new System.EventHandler(this.cbMedicament_SelectedIndexChanged);
            // 
            // cbDosage
            // 
            this.cbDosage.FormattingEnabled = true;
            this.cbDosage.Location = new System.Drawing.Point(272, 168);
            this.cbDosage.Name = "cbDosage";
            this.cbDosage.Size = new System.Drawing.Size(185, 21);
            this.cbDosage.TabIndex = 2;
            this.cbDosage.SelectedIndexChanged += new System.EventHandler(this.cbDosage_SelectedIndexChanged);
            this.cbDosage.Click += new System.EventHandler(this.cbDosage_SelectedIndexChanged);
            // 
            // tbTypeIndividu
            // 
            this.tbTypeIndividu.Location = new System.Drawing.Point(272, 114);
            this.tbTypeIndividu.Name = "tbTypeIndividu";
            this.tbTypeIndividu.Size = new System.Drawing.Size(185, 20);
            this.tbTypeIndividu.TabIndex = 3;
            this.tbTypeIndividu.Enter += new System.EventHandler(this.tbTypeIndividu_Enter);
            this.tbTypeIndividu.Leave += new System.EventHandler(this.tbTypeIndividu_Leave);
            // 
            // tbPosologie
            // 
            this.tbPosologie.Location = new System.Drawing.Point(272, 218);
            this.tbPosologie.Name = "tbPosologie";
            this.tbPosologie.Size = new System.Drawing.Size(185, 20);
            this.tbPosologie.TabIndex = 4;
            this.tbPosologie.Enter += new System.EventHandler(this.tbPosologie_Enter);
            this.tbPosologie.Leave += new System.EventHandler(this.tbPosologie_Leave);
            // 
            // btValider
            // 
            this.btValider.Location = new System.Drawing.Point(199, 260);
            this.btValider.Name = "btValider";
            this.btValider.Size = new System.Drawing.Size(75, 23);
            this.btValider.TabIndex = 5;
            this.btValider.Text = "Ajouter";
            this.btValider.UseVisualStyleBackColor = true;
            this.btValider.Click += new System.EventHandler(this.btValider_Click);
            // 
            // btAnnuler
            // 
            this.btAnnuler.Location = new System.Drawing.Point(454, 260);
            this.btAnnuler.Name = "btAnnuler";
            this.btAnnuler.Size = new System.Drawing.Size(75, 23);
            this.btAnnuler.TabIndex = 6;
            this.btAnnuler.Text = "Annuler";
            this.btAnnuler.UseVisualStyleBackColor = true;
            this.btAnnuler.Click += new System.EventHandler(this.btRetour_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(147, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Choisir un medicament :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(149, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Saisir un type d\'individu";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(164, 176);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Choisir un Dosage : ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(156, 225);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Saisir une posologie : ";
            // 
            // btSupp
            // 
            this.btSupp.Location = new System.Drawing.Point(326, 260);
            this.btSupp.Name = "btSupp";
            this.btSupp.Size = new System.Drawing.Size(75, 23);
            this.btSupp.TabIndex = 11;
            this.btSupp.Text = "Supprimer";
            this.btSupp.UseVisualStyleBackColor = true;
            this.btSupp.Click += new System.EventHandler(this.btSupp_Click);
            // 
            // FormPrescrire
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btSupp);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btAnnuler);
            this.Controls.Add(this.btValider);
            this.Controls.Add(this.tbPosologie);
            this.Controls.Add(this.tbTypeIndividu);
            this.Controls.Add(this.cbDosage);
            this.Controls.Add(this.cbMedicament);
            this.Name = "FormPrescrire";
            this.Text = "FormPrescrire";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbMedicament;
        private System.Windows.Forms.ComboBox cbDosage;
        private System.Windows.Forms.TextBox tbTypeIndividu;
        private System.Windows.Forms.TextBox tbPosologie;
        private System.Windows.Forms.Button btValider;
        private System.Windows.Forms.Button btAnnuler;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btSupp;
    }
}