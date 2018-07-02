namespace gsb_bureau
{
    partial class FormLister
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
            this.lvListePrescrire = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.btValider = new System.Windows.Forms.Button();
            this.btAnnuler = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvListePrescrire
            // 
            this.lvListePrescrire.Location = new System.Drawing.Point(216, 59);
            this.lvListePrescrire.Name = "lvListePrescrire";
            this.lvListePrescrire.Size = new System.Drawing.Size(343, 180);
            this.lvListePrescrire.TabIndex = 0;
            this.lvListePrescrire.UseCompatibleStateImageBehavior = false;
            this.lvListePrescrire.SelectedIndexChanged += new System.EventHandler(this.lvListePrescrire_SelectedIndexChanged);
            this.lvListePrescrire.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvListePrescrire_DoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(213, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(215, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Selection une prescription pour plus d\'option";
            // 
            // btValider
            // 
            this.btValider.Location = new System.Drawing.Point(230, 274);
            this.btValider.Name = "btValider";
            this.btValider.Size = new System.Drawing.Size(75, 23);
            this.btValider.TabIndex = 2;
            this.btValider.Text = "Valider";
            this.btValider.UseVisualStyleBackColor = true;
            this.btValider.Click += new System.EventHandler(this.btValider_Click);
            // 
            // btAnnuler
            // 
            this.btAnnuler.Location = new System.Drawing.Point(471, 274);
            this.btAnnuler.Name = "btAnnuler";
            this.btAnnuler.Size = new System.Drawing.Size(75, 23);
            this.btAnnuler.TabIndex = 3;
            this.btAnnuler.Text = "Annuler";
            this.btAnnuler.UseVisualStyleBackColor = true;
            this.btAnnuler.Click += new System.EventHandler(this.btAnnuler_Click);
            // 
            // FormLister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btAnnuler);
            this.Controls.Add(this.btValider);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lvListePrescrire);
            this.Name = "FormLister";
            this.Text = "FormLister";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvListePrescrire;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btValider;
        private System.Windows.Forms.Button btAnnuler;
    }
}