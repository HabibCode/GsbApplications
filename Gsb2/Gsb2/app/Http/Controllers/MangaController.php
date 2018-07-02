<?php
namespace App\Http\Controllers;
//use Illuminate\Http\Request;
use Request;
use App\modeles\Medicament;
use App\modeles\Famille;
use App\modeles\Prescrire;
use App\modeles\Dosage;
use App\Http\Requests;
use Illuminate\Support\Facades\Session;
use Exception;


class MangaController extends Controller
{
   public function getMedicaments(){
       $erreur = Session::get('erreur');
       Session::forget('erreur');
       $medicament = new Medicament();
       $medicaments = $medicament->getMedicaments();
       return view('listeMedicaments', compact('medicaments', 'erreur'));
   }
   
   public function getMedicamentsFamille()
           {
          $erreur = "";
          $id_famille = Request::input('cbFamille');
          

          
          if($id_famille){
              $medicament = new Medicament();
              $medicaments = $medicament->getMedicamentsFamille($id_famille);
              return view('listeMedicaments', compact('medicaments','erreur'));
          }
          else{
              $erreur = "Il faut sélectionner une familles !";
              Session::put('erreur', $erreur);
              return redirect('/listerFamilles');
          }
           }
           public function getFamilles()
           {
               $erreur = Session::get('erreur');
               Session::forget('erreur');
               $famille = new Famille();
           } 
           
           
               
           
           public function updateMedicament($id, $erreur = "")
           {
             $leMedicament = new Medicament();
             $medicament = $leMedicament->getMedicament($id);
             $famille = new Famille();
             $familles = $famille->getFamilles();
             /*$prescrire = new Prescrire();
             $prescrires = $prescrire->getPrescrires();
             $dosage = new Dosage();
             $dosages = $dosage->getDosages();*/
             $titreVue = "Modification d'un medicament";
             return view('formMedicament', compact('medicament','familles', 'titreVue', 'erreur'));/*,'prescrires','dosages'));*/
             
             
           }
           public function validateMedicament()
           {
               $id_medicament = Request::input('id_medicament');
               $effets = Request::input('cbEffets');
               $prix_echantillon = Request::input('prix_echantillon');
               $contre_indication = Request::input('cbContre_indication');
               $nom_commercial = Request::input('nom_commercial');
               $id_famille = Request::input('cbFamille');
               
              /* if(Request::hasFile('couverture'))
               {
                   $image = Request::file('couverture');
                   $couverture = $image->getClientOriginalName();
                   Request::file('couverture')->move(base_path() .'/public/images', $couverture);
                   
               } else {
                   $couverture = Request::input('couvertureHidden');
               }*/
               
               $medicament = new Medicament();
               try { if ($id_medicament > 0)
               {
                   $medicament->updateMedicament($id_medicament, $nom_commercial, /*$couverture,*/ $prix_echantillon, $effets, $id_famille, $contre_indication);
               }
                else {
                      $medicament->insertMedicament($nom_commercial, /*$couverture,*/ $prix_echantillon, $effets, $id_famille, $contre_indication);
                     }
               } 
               catch(Exception $ex) {
                   $erreur = $ex->getMessage();
                   if ($id_medicament > 0)
                       {
                        return $this->updateMedicament($id_medicament, $erreur);
                       }
                   else 
                        {
                        return $this->addMedicament($erreur);
                        }
               }
               return redirect('/listerMedicaments');
           }
           public function addMedicament($erreur="")
           {
               $medicament = new Medicament();
               $famille = new Famille();
               $familles = $famille->getFamilles();
               
               $titreVue="Ajout d'un Medicament";
               return view('formMedicament', compact('medicament','familles','titreVue','erreur' /* 'dessinateurs','scenaristes',*/ ));
           }
           public function  deleteMedicament($id_medicament)
           {
              $medicament = new Medicament();
               $medicament->deleteMedicament($id_medicament);
               
                 return redirect('listerMedicaments');
           }
}
