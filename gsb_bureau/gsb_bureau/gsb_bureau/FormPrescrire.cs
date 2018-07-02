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
    public partial class FormPrescrire : Form
    {
        private gsbEntities BD;
        private List<prescrire> retourRes;
        private prescrire prescription;
        public FormPrescrire(gsbEntities p_bd,prescrire v, List<prescrire> resultats)
        {
            InitializeComponent();
            BD = p_bd;
            initCbs();
            retourRes = resultats;
            prescription = v;
            btValider.Location = new Point(55, 245);
            btSupp.Location = new Point(140, 245);
            btSupp.Visible = true;
            
            btAnnuler.Location = new Point(310, 245);
            remplirForm(v);

        }
        public FormPrescrire(gsbEntities p_bd, prescrire v)
        {
            InitializeComponent();
            BD = p_bd;
            initCbs();
            prescription = v;
            btValider.Location = new Point(98, 245);
            btSupp.Location = new Point(183, 245);
            btSupp.Visible = true;
            btAnnuler.Location = new Point(268, 245);
            remplirForm(v);
        }

        public FormPrescrire(gsbEntities p_bd, List<prescrire> resultats)
        {
            InitializeComponent();
            BD = p_bd;
            initCbs();
            retourRes = resultats;
            btValider.Location = new Point(98, 245);
            btValider.Text = "Ajouter";

            btAnnuler.Location = new Point(268, 245);

        }

        public FormPrescrire(gsbEntities p_bd)
        {
            InitializeComponent();
            BD = p_bd;
            initCbs();
            btValider.Location = new Point(140, 245);
            btValider.Text = "Ajouter";
            btAnnuler.Location = new Point(225, 245);
            
        }

        private void initCbs()
        {
            var reqMedo = from medicament in BD.medicament
                          select medicament;
            cbMedicament.DisplayMember = "NomMedo";
            cbMedicament.ValueMember = "IdMedo";
            cbMedicament.Items.Add(new unMedo() { NomMedo = "Sélectionner", IdMedo = 0 });
            foreach (medicament medo in reqMedo)
            {
                cbMedicament.Items.Add(new unMedo() { NomMedo = medo.nom_commercial, IdMedo = medo.id_medicament });
            }
            cbMedicament.SelectedIndex = 0;

            var reqDosage = from dosage in BD.dosage
                             select dosage;
            cbDosage.DisplayMember = "LibDosage";
            cbDosage.ValueMember = "IdDosage";
            cbDosage.Items.Add(new unDosage() { LibDosage = "Sélectionner", IdDosage = 0 });
            foreach (dosage dose in reqDosage)
            {
                cbDosage.Items.Add(new unDosage() { LibDosage = dose.unite_dosage + dose.qte_dosage, IdDosage = dose.id_dosage });
            }
            cbDosage.SelectedIndex = 0;
        }

        private void remplirForm(prescrire v)
        {
            
           
            if (v.id_medicament != 0) { cbMedicament.SelectedIndex = v.id_medicament; }
            if (v.id_dosage != 0) { cbDosage.SelectedIndex = v.id_dosage; }
            if (v.id_type_individu != 0 && v.type_individu.lib_type_individu!= "") { tbTypeIndividu.Text = v.type_individu.lib_type_individu; }
            if (v.posologie != null && v.posologie != "") { tbPosologie.Text = v.posologie; }
        }

        public class unMedo
        {
            public string NomMedo { get; set; }
            public int IdMedo { get; set; }
        }

        public class unDosage
        {
            public string LibDosage { get; set; }
            public int IdDosage { get; set; }
        }

        private void btValider_Click(object sender, EventArgs e)
        {
            if (btValider.Text == "Ajouter")
            {
                prepAjoutPrescrire();
            }
            else
            {
               
            }
        }

        private void btSupp_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Etes-vous sûr(e) de vouloir supprimer cette Prescription ?", "Demande de confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                
                var suppPres = from prescrire in BD.prescrire
                              where prescrire.id_medicament == prescription.id_medicament
                              where prescrire.id_type_individu == prescription.id_type_individu
                              where prescrire.id_dosage == prescription.id_dosage
                              select prescrire;
                foreach (prescrire v in suppPres)
                {
                    BD.prescrire.Remove(v);
                    if (retourRes != null && retourRes.LongCount() > 0)
                    {
                        int index = 0;
                        bool verif = false;
                        foreach (prescrire unVisi in retourRes)
                        {
                            if (unVisi.id_medicament == v.id_medicament && unVisi.id_type_individu == v.id_type_individu && unVisi.id_dosage == v.id_dosage )
                            {
                                verif = true;
                                break;
                            }
                            index++;
                        }
                        if (verif)
                        {
                            retourRes.RemoveAt(index);
                        }
                    }
                }
                bool flag = false;
                try
                {
                    BD.SaveChanges();
                }
                catch
                {
                    MessageBox.Show("La prescription n'a pas pu être supprimé !", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    flag = true;
                }
                if (!flag)
                {
                    if (retourRes == null || retourRes.LongCount() == 0)
                    {
                        MessageBox.Show("La prescription été supprimé, vous pouvez en créer un nouveau.", "Confirmation de suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        System.Threading.Thread monthread = new System.Threading.Thread(new System.Threading.ThreadStart(nouveauFormAjout));
                        monthread.Start();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("La prescription a bien été supprimé, vous pouvez en créer un nouveau ou retourner à la liste de recherche.", "Confirmation de suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        System.Threading.Thread monthread = new System.Threading.Thread(new System.Threading.ThreadStart(nouveauFormAjoutList));
                        monthread.Start();
                        this.Close();
                    }
                }
            }
        }

        private void btRetour_Click(object sender, EventArgs e)
        {
            System.Threading.Thread monthread = new System.Threading.Thread(new System.Threading.ThreadStart(lister));
            monthread.Start();
            this.Close();
        }

        private void lister()
        {
            Form listResultat = new FormLister(BD, retourRes);
            listResultat.ShowDialog();
        }

        private void nouveauFormAjout()
        {
            Form visit = new FormPrescrire(BD);
            visit.Text = "Ajout d'une Prescription";
            visit.ShowDialog();
        }

        private void nouveauFormAjoutList()
        {
            Form visit = new FormPrescrire(BD, retourRes);
            visit.Text = "Ajout d'un visiteur";
            visit.ShowDialog();
        }

        private void prepAjoutPrescrire()
        {
            var verifLogin = from prescrire in BD.prescrire
                             where prescrire.type_individu.lib_type_individu == tbTypeIndividu.Text
                             select prescrire;
            if (verifLogin.LongCount() != 0)
            {
                
                tbTypeIndividu.Text = "";
                tbTypeIndividu.Focus();
            }
            else
            {
                ajoutPrescrire();
            }
        }

        private void ajoutPrescrire()
        {
            prescrire nouveauPrescrire = new prescrire();
            nouveauPrescrire.id_medicament = 0;
            nouveauPrescrire.id_dosage = 0;
            nouveauPrescrire.id_type_individu = 0;           
            if (tbTypeIndividu.Text != "") { nouveauPrescrire.type_individu.lib_type_individu = tbTypeIndividu.Text; }
            if (tbPosologie.Text != "") { nouveauPrescrire.posologie = tbPosologie.Text; }
           
            if (cbMedicament.SelectedIndex != 0) { nouveauPrescrire.id_medicament = cbMedicament.SelectedIndex; }
            if (cbDosage.SelectedIndex != 0) { nouveauPrescrire.id_dosage = cbDosage.SelectedIndex; }
          ;
            BD.prescrire.Add(nouveauPrescrire);
            bool flag = false;
            try
            {
                BD.SaveChanges();
            }
            catch
            {
                MessageBox.Show("Le visiteur n'a pas pu être créé !", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                flag = true;
            }
            prescription = nouveauPrescrire;
            if (!flag)
            {
                if (retourRes != null && retourRes.LongCount() > 0)
                {
                    MessageBox.Show("La prescription a bien été ajouté, vous pouvez maintenant le modifier.", "Confirmation d'ajout", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    System.Threading.Thread monthread = new System.Threading.Thread(new System.Threading.ThreadStart(nouveauFormModifList));
                    monthread.Start();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("La prescription a bien été ajouté, vous pouvez maintenant le modifier.", "Confirmation d'ajout", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    System.Threading.Thread monthread = new System.Threading.Thread(new System.Threading.ThreadStart(nouveauFormModif));
                    monthread.Start();
                    this.Close();
                }
            }
        }

        private void nouveauFormModif()
        {
            Form visit = new FormPrescrire(BD, prescription);
            visit.Text = "Modification/Suppression d'une prescription";
            visit.ShowDialog();
        }

        private void nouveauFormModifList()
        {
            Form visit = new FormPrescrire(BD, prescription, retourRes);
            visit.Text = "Modification/Suppression d'une prescription";
            visit.ShowDialog();
        }

       

        private void modifPrescrire()
        {

            using (gsbEntities bdd = new gsbEntities())
            {
                prescrire visi = (from prescrire in bdd.prescrire
                                 where prescrire.id_medicament == prescription.id_medicament
                                 where prescrire.id_type_individu == prescription.id_type_individu
                                 where prescrire.id_dosage == prescription.id_dosage
                                 select prescrire).FirstOrDefault();

                
                if (visi.type_individu.lib_type_individu != tbTypeIndividu.Text) { if (tbTypeIndividu.Text == "") { visi.id_type_individu = 0; } else { visi.id_type_individu = prescription.id_type_individu + 1; } }
                if (visi.posologie != tbPosologie.Text) { if (tbPosologie.Text == "") { visi.posologie = null; } else { visi.posologie = tbPosologie.Text; } }             
                if (visi.id_medicament != cbMedicament.SelectedIndex) { if (cbMedicament.SelectedIndex == 0) { visi.id_medicament = 0; } else { visi.id_medicament = cbMedicament.SelectedIndex; } }
                if (visi.id_dosage != cbDosage.SelectedIndex) { if (cbDosage.SelectedIndex == 0) { visi.id_dosage = 0; } else { visi.id_dosage = cbDosage.SelectedIndex; } }
                prescription = visi;
                if (retourRes != null && retourRes.LongCount() > 0)
                {
                    int index = 0;
                    bool verif = false;
                    foreach (prescrire unVisi in retourRes)
                    {
                        if (unVisi.id_medicament == visi.id_medicament && unVisi.id_type_individu == visi.id_type_individu && unVisi.id_dosage == visi.id_dosage )
                        {
                            verif = true;
                            break;
                        }
                        index++;
                    }
                    if (verif)
                    {
                        retourRes.RemoveAt(index);
                        retourRes.Add(visi);
                        retourRes.Sort(delegate (prescrire vis1, prescrire vis2) { return string.Compare(vis1.posologie, vis2.posologie); });
                    }
                }
                bool flag = false;
                try
                {
                    bdd.SaveChanges();
                }
                catch
                {
                    MessageBox.Show("La modification n'a pas pu être enregistrée !", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    flag = true;
                }
                if (!flag)
                {
                    if (retourRes != null && retourRes.LongCount() > 0)
                    {
                        MessageBox.Show("La prescription a bien été modifié !", "Confirmation de modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        System.Threading.Thread monthread = new System.Threading.Thread(new System.Threading.ThreadStart(nouveauFormModifList));
                        monthread.Start();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("La prescription a bien été modifié !", "Confirmation de modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        System.Threading.Thread monthread = new System.Threading.Thread(new System.Threading.ThreadStart(nouveauFormModif));
                        monthread.Start();
                        this.Close();
                    }
                }
            }
        }

       

      

      
        
       

        

       

       

       

        private void tbTypeIndividu_Enter(object sender, EventArgs e)
        {
            if (tbTypeIndividu.Text == "")
            {
                tbTypeIndividu.Text = "Saisir un login";
            }
        }

        private void tbTypeIndividu_Leave(object sender, EventArgs e)
        {
            if (tbTypeIndividu.Text == "")
            {
                tbTypeIndividu.Text = "Saisir un login";
            }
        }

        private void tbPosologie_Enter(object sender, EventArgs e)
        {
            if (tbPosologie.Text == "")
            {
                tbPosologie.Text = "Saisir une posologie";
            }
        }

        private void tbPosologie_Leave(object sender, EventArgs e)
        {
            if (tbPosologie.Text == "")
            {
                tbPosologie.Text = "Saisir une Posologie";
            }
        }

        

        private void tbTypeIndividu_KeyUp(object sender, KeyEventArgs e)
        {
            if (tbTypeIndividu.Text != ""  && tbPosologie.Text != "Saisir un mot de passe")
            {
                btValider.Enabled = true;
            }
            else
            {
                btValider.Enabled = false;
            }
        }

        private void tbPosologie_KeyUp(object sender, KeyEventArgs e)
        {
            if (btValider.Text == "Valider" && tbTypeIndividu.Text != "" && tbPosologie.Text != "")
            {
                btValider.Enabled = true;
            }
            else
            {
                btValider.Enabled = false;
            }
        }

        

       

        

       

       

        private void cbMedicament_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (btValider.Text == "Valider" && tbTypeIndividu.Text != "" && tbPosologie.Text != "")
            {
                btValider.Enabled = true;
            }
        }

        private void cbDosage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (btValider.Text == "Valider" && tbTypeIndividu.Text != ""  && tbPosologie.Text != "" )
            {
                btValider.Enabled = true;
            }
        }

    }
}
