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
    public partial class FormRechercher : Form
    {
        AutoCompleteStringCollection coll = new AutoCompleteStringCollection();
        private gsbEntities BD;
        private List<prescrire> resultat;
        public FormRechercher(gsbEntities p_bd)
        {
            InitializeComponent();
            BD = p_bd;
            resultat = new List<prescrire>();
           //auto();

            var reqMedoc = from medicament in BD.medicament
                          select medicament;
            cbMedicament.DisplayMember = "NomMedicament";
            cbMedicament.ValueMember = "IdMedicament";
            cbMedicament.Items.Add(new unMedicament() { NomMedicament = "Sélectionner un Medicament", IdMedicament = 0 });
            cbMedicament.SelectedIndex = 0;
            foreach (medicament medoc in reqMedoc)
            {
                cbMedicament.Items.Add(new unMedicament() { NomMedicament = medoc.nom_commercial, IdMedicament = medoc.id_medicament });
            }

            var reqType = from type_individu in BD.type_individu
                             select type_individu;
            cbType_individu.DisplayMember = "LibType";
            cbType_individu.ValueMember = "IdType";
            cbType_individu.Items.Add(new unType() { LibType = "Sélectionner un type d'individu ", IdType = 0 });
            cbType_individu.SelectedIndex = 0;
            foreach (type_individu typeInd in reqType)
            {
                cbType_individu.Items.Add(new unType() { LibType = typeInd.lib_type_individu, IdType = typeInd.id_type_individu });
            }

            var reqDosage = from dosage in BD.dosage
                          select dosage;
            cbDosage.DisplayMember = "UniteDosage";
            cbDosage.ValueMember = "IdDosage";
            cbDosage.Items.Add(new unDosage() { LibDosage = "Sélectionner un Dosage ", IdDosage = 0 });
            cbDosage.SelectedIndex = 0;
            foreach (dosage dose in reqDosage)
            {
                cbDosage.Items.Add(new unDosage() { LibDosage = dose.unite_dosage + dose.qte_dosage, IdDosage = dose.id_dosage });
            }
        }
       

        private void btAnnuler_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public class unMedicament
        {
            public string NomMedicament { get; set; }
            public int IdMedicament { get; set; }
        }

        public class unType
        {
            public string LibType { get; set; }
            public int IdType { get; set; }
        }
        public class unDosage
        {
            public string LibDosage { get; set; }
            public int IdDosage { get; set; }
        }

       

        

       

        
       

        

        private void btRechercher_Click(object sender, EventArgs e)
        {
            if ( cbDosage.SelectedIndex!= 0 && cbMedicament.SelectedIndex != 0 && cbType_individu.SelectedIndex != 0)
            {
                rechDoseMedTyp();
            }
            else if (cbDosage.SelectedIndex != 0 && cbMedicament.SelectedIndex != 0)
            {
                rechDoseMed();
            }
            else if (cbDosage.SelectedIndex != 0 && cbType_individu.SelectedIndex != 0)
            {
                rechDoseType();
            }
            else if (cbMedicament.SelectedIndex != 0 && cbType_individu.SelectedIndex != 0)
            {
                rechMedType();
            }
           
            else if (cbMedicament.SelectedIndex != 0)
            {
                rechMed();
            }
            else if (cbType_individu.SelectedIndex != 0)
            {
                rechTyp();
            }
            else
            {
                tousPrescrire();
            }
        }

        private void rechDoseMedTyp()
        {
            var req = from prescrire in BD.prescrire
                      where prescrire.id_dosage == cbDosage.SelectedIndex
                      where prescrire.id_medicament == cbMedicament.SelectedIndex
                      where prescrire.id_type_individu == cbType_individu.SelectedIndex
                      orderby prescrire.medicament.nom_commercial
                      select prescrire;
            ;
            if (req.LongCount() != 0)
            {
                foreach (prescrire v in req)
                {
                    resultat.Add(v);
                }
                System.Threading.Thread monthread = new System.Threading.Thread(new System.Threading.ThreadStart(lister));
                monthread.Start();
                this.Close();
            }
            else
            {
                reinitialiser();
            }
        }

        private void rechDoseMed()
        {
            var req = from prescrire in BD.prescrire
                      where prescrire.id_dosage == cbDosage.SelectedIndex
                      where prescrire.id_medicament== cbMedicament.SelectedIndex
                      orderby prescrire.medicament.nom_commercial
                      select prescrire;
            if (req.LongCount() != 0)
            {
                foreach (prescrire v in req)
                {
                    resultat.Add(v);
                }
                System.Threading.Thread monthread = new System.Threading.Thread(new System.Threading.ThreadStart(lister));
                monthread.Start();
                this.Close();
            }
            else
            {
                reinitialiser();
            }
        }

        private void rechDoseType()
        {
            var req = from prescrire in BD.prescrire
                      where prescrire.id_dosage == cbDosage.SelectedIndex
                      where prescrire.id_type_individu == cbType_individu.SelectedIndex
                      orderby prescrire.medicament.nom_commercial
                      select prescrire;
            if (req.LongCount() != 0)
            {
                foreach (prescrire v in req)
                {
                    resultat.Add(v);
                }
                System.Threading.Thread monthread = new System.Threading.Thread(new System.Threading.ThreadStart(lister));
                monthread.Start();
                this.Close();
            }
            else
            {
                reinitialiser();
            }
        }

        private void rechMedType()
        {
            var req = from prescrire in BD.prescrire
                      where prescrire.id_medicament == cbMedicament.SelectedIndex
                      where prescrire.id_type_individu == cbType_individu.SelectedIndex
                      orderby prescrire.medicament.nom_commercial
                      select prescrire;
            if (req.LongCount() != 0)
            {
                foreach (prescrire v in req)
                {
                    resultat.Add(v);
                }
                System.Threading.Thread monthread = new System.Threading.Thread(new System.Threading.ThreadStart(lister));
                monthread.Start();
                this.Close();
            }
            else
            {
                reinitialiser();
            }
        }

        private void rechDosage()
        {
            var req = from prescrire in BD.prescrire
                      where prescrire.id_dosage == cbDosage.SelectedIndex
                      orderby prescrire.medicament.nom_commercial
                      select prescrire;
            if (req.LongCount() != 0)
            {
                foreach (prescrire v in req)
                {
                    resultat.Add(v);
                }
                System.Threading.Thread monthread = new System.Threading.Thread(new System.Threading.ThreadStart(lister));
                monthread.Start();
                this.Close();
            }
            else
            {
                reinitialiser();
            }
        }

        private void rechMed()
        {
            var req = from prescrire in BD.prescrire
                     
                      where prescrire.id_medicament == cbMedicament.SelectedIndex
                      orderby prescrire.medicament.nom_commercial
                      select prescrire;
            if (req.LongCount() != 0)
            {
                foreach (prescrire v in req)
                {
                    resultat.Add(v);
                }
                System.Threading.Thread monthread = new System.Threading.Thread(new System.Threading.ThreadStart(lister));
                monthread.Start();
                this.Close();
            }
            else
            {
                reinitialiser();
            }
        }

        private void rechTyp()
        {
            var req = from prescrire in BD.prescrire

                      where prescrire.id_type_individu == cbType_individu.SelectedIndex
                      orderby prescrire.medicament.nom_commercial
                      select prescrire;
            if (req.LongCount() != 0)
            {
                foreach (prescrire v in req)
                {
                    resultat.Add(v);
                }
                System.Threading.Thread monthread = new System.Threading.Thread(new System.Threading.ThreadStart(lister));
                monthread.Start();
                this.Close();
            }
            else
            {
                reinitialiser();
            }
        }

        private void tousPrescrire()
        {
            var req = from prescrire in BD.prescrire
                      
                      orderby prescrire.medicament.nom_commercial
                      select prescrire;
            if (req.LongCount() != 0)
            {
                foreach (prescrire v in req)
                {
                    resultat.Add(v);
                }
                System.Threading.Thread monthread = new System.Threading.Thread(new System.Threading.ThreadStart(lister));
                monthread.Start();
                this.Close();
            }
            else
            {
                reinitialiser();
            }
        }

        private void reinitialiser()
        {
            cbDosage.SelectedIndex = 0;
            cbMedicament.SelectedIndex = 0;
            cbType_individu.SelectedIndex = 0;
            
        }

        private void lister()
        {
            Form listResultat = new FormLister(BD, resultat);
            listResultat.ShowDialog();
        }
    }
}

