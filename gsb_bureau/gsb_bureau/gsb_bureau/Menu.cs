using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
 
namespace gsb_bureau
{
    public partial class Menu : Form
    {
        private gsbEntities BD;
        public Menu()
        {
            InitializeComponent();
            BD = new gsbEntities();
        }

        private void Menu_FormClosing(object sender, FormClosingEventArgs e)
        {
            string appelant = e.CloseReason.ToString();
            if (appelant == "UserClosing")
            {
                e.Cancel = true;
                Application.Exit();
            }
            else if (MessageBox.Show("Etes-vous sûr(e) de vouloir quitter ?", "Demande de confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

       

        private void connexionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form Connexion = new Form1(this);
            Connexion.ShowDialog();
        }

        public void connecte(string role)
        {


            prescriptions.Visible = true;
           
            //lbBienvenue.Visible = true;
            deconnexion.Visible = true;
            connexion.Visible = false;
        }

        private void deconnexionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //lbBienvenue.Visible = false;
            deconnexion.Visible = false;
            connexion.Visible = true;
            prescriptions.Visible = false;
        }

        private void rechercherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form RecherchePrescription  = new FormRechercher(BD); 
            RecherchePrescription.ShowDialog();
        }

        private void ajouterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form detailsPrescrire = new FormPrescrire(BD);
            detailsPrescrire.Text = "Ajout d'un visiteur";
            detailsPrescrire.ShowDialog();
        }

        private void quitter_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }

}

