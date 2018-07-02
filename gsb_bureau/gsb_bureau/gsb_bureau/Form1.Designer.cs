namespace gsb_bureau
{
    partial class Form1
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
            this.tbLogin = new System.Windows.Forms.TextBox();
            this.tbMdp = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btValiderConnexion = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.lbErreurConnexion = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbLogin
            // 
            this.tbLogin.Location = new System.Drawing.Point(284, 125);
            this.tbLogin.Name = "tbLogin";
            this.tbLogin.Size = new System.Drawing.Size(100, 20);
            this.tbLogin.TabIndex = 0;
            this.tbLogin.Enter += new System.EventHandler(this.tbLogin_Enter);
            this.tbLogin.Leave += new System.EventHandler(this.tbLogin_Leave);
            // 
            // tbMdp
            // 
            this.tbMdp.Location = new System.Drawing.Point(284, 183);
            this.tbMdp.Name = "tbMdp";
            this.tbMdp.Size = new System.Drawing.Size(100, 20);
            this.tbMdp.TabIndex = 1;
            this.tbMdp.Enter += new System.EventHandler(this.tbMdp_Enter);
            this.tbMdp.Leave += new System.EventHandler(this.tbMdp_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(223, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Login:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(185, 183);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Mot de passe:";
            // 
            // btValiderConnexion
            // 
            this.btValiderConnexion.Location = new System.Drawing.Point(226, 242);
            this.btValiderConnexion.Name = "btValiderConnexion";
            this.btValiderConnexion.Size = new System.Drawing.Size(75, 23);
            this.btValiderConnexion.TabIndex = 4;
            this.btValiderConnexion.Text = "Valider";
            this.btValiderConnexion.UseVisualStyleBackColor = true;
            this.btValiderConnexion.Click += new System.EventHandler(this.btValiderConnexion_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(348, 242);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "annuler";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btAnnulerConnexion_Click);
            // 
            // lbErreurConnexion
            // 
            this.lbErreurConnexion.AutoSize = true;
            this.lbErreurConnexion.Location = new System.Drawing.Point(311, 80);
            this.lbErreurConnexion.Name = "lbErreurConnexion";
            this.lbErreurConnexion.Size = new System.Drawing.Size(0, 13);
            this.lbErreurConnexion.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 450);
            this.Controls.Add(this.lbErreurConnexion);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btValiderConnexion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbMdp);
            this.Controls.Add(this.tbLogin);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbLogin;
        private System.Windows.Forms.TextBox tbMdp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btValiderConnexion;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lbErreurConnexion;
    }
}