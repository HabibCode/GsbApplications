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
    public partial class FormLister : Form
    {
        private gsbEntities BD;
        private List<int> listIds;
        private List<prescrire> resultats;
        private prescrire prescription;
        public FormLister(gsbEntities p_bd, List<prescrire> resultat)
        {
            InitializeComponent();
            resultats = resultat;
            BD = p_bd;
            CreateHeadersAndFillListView();
            PaintListView(resultat);
        }
        private void btAnnuler_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CreateHeadersAndFillListView()
        {
            lvListePrescrire.Columns.Add("Identifiant", -2, HorizontalAlignment.Left);
            lvListePrescrire.Columns.Add("Medicament", -2, HorizontalAlignment.Left);
            lvListePrescrire.Columns.Add("posologie", -2, HorizontalAlignment.Left);
            lvListePrescrire.Columns.Add("type individu", -2, HorizontalAlignment.Left);
            lvListePrescrire.Columns.Add("dosage", -2, HorizontalAlignment.Left);
          
        }

        private void PaintListView(List<prescrire> result)
        {
            try
            {
                ListViewItem lvi;
                listIds = new List<int>();

                lvListePrescrire.Items.Clear();

                lvListePrescrire.BeginUpdate();

                foreach (prescrire v in result)
                {
                    listIds.Add(v.id_medicament);
                    listIds.Add(v.id_type_individu);
                    listIds.Add(v.id_dosage);
                    var nomMed = from medicament in BD.medicament
                                  where medicament.id_medicament == v.id_medicament
                                  select medicament;
                    string strNom = "";
                    foreach (medicament med in nomMed)
                    {
                        strNom = med.nom_commercial;
                    }
                    var libType = from type_individu in BD.type_individu
                                     where type_individu.id_type_individu == v.id_type_individu
                                     select type_individu;
                    string strLib = "";
                    foreach (type_individu typ in libType)
                    {
                        strLib = typ.lib_type_individu;
                    }
                    lvi = new ListViewItem(v.medicament.nom_commercial);
                    
                    lvi.SubItems.Add(v.posologie);
                    lvi.SubItems.Add(v.type_individu.lib_type_individu);
                    lvi.SubItems.Add(v.dosage.qte_dosage.ToString());
                    lvi.SubItems.Add(v.dosage.unite_dosage);
                    lvi.SubItems.Add(strNom);
                    lvi.SubItems.Add(strLib);
                    lvListePrescrire.Items.Add(lvi);
                }
                lvListePrescrire.EndUpdate();
            }
            catch (System.Exception err)
            {
                MessageBox.Show("Error: " + err.Message);
            }

            lvListePrescrire.View = View.Details;
        }

        private void btValider_Click(object sender, EventArgs e)
        {
            rechercher();
        }

        private void lvListePrescrire_SelectedIndexChanged(object sender, EventArgs e)
        {
            btValider.Enabled = true;
        }

        private void lvListePrescrire_DoubleClick(object sender, EventArgs e)
        {
            rechercher();
        }

        private void rechercher()
        {
            var donnee = lvListePrescrire.SelectedIndices;
            foreach (int index in donnee)
            {
                int i = listIds[index];
                var req = from prescrire in BD.prescrire
                          where prescrire.id_medicament == i
                          where prescrire.id_dosage == i
                          where prescrire.id_type_individu== i
                          select prescrire;
                foreach (prescrire v in req)
                {
                    prescription = v;
                    System.Threading.Thread monthread = new System.Threading.Thread(new System.Threading.ThreadStart(details));
                    monthread.Start();
                    this.Close();
                }
            }
        }

        private void details()
        {
            Form detailsPrescrire = new FormPrescrire(BD, prescription, resultats);
            detailsPrescrire.Text = "Modification/Suppression d'un visiteur";
            detailsPrescrire.ShowDialog();
        }

        private void lvListePrescrire_DoubleClick(object sender, MouseEventArgs e)
        {
            rechercher();
        }
    }
}
