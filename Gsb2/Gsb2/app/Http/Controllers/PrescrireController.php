<?php

namespace App\Http\Controllers;

//use Illuminate\Http\Request;
use Request;
use App\modeles\Medicament;
use App\modeles\Famille;
use App\modeles\Prescrire;
use App\modeles\Dosage;
use App\modeles\Type_individu;
use App\Http\Requests;
use Illuminate\Support\Facades\Session;
use Exception;

class PrescrireController extends Controller
{
   public function getPrescrires()
   {
       $erreur = Session::get('erreur');
       Session::forget('erreur');
       $prescrire = new Prescrire();
       $prescrires = $prescrire->getPrescrires();
       return view('listePrescrires', compact('prescrires','erreur'));
   }
  
   public function getPrescriresDosage()
           {
            $erreur = "";
         
            
            $id_dosage = request::input('cbDosage');
           
            if($id_dosage)
            {
                $prescrire = new Prescrire();
                $prescrires = $prescrire->getPrescriresDosage($id_dosage);
                return view('listePrescrires', compact('prescrires', 'erreur'));
            }
            else
            {
                $erreur = "Il faut sélectionner un dosage";
                Session::put('erreur',$erreur);
                return redirect ('/listerPrescrires');
            }
           }
           
            public function getDosages()
            {
                $erreur = Session::get('erreur');
                Session::forget('erreur');
                $dosage = new Dosage();
            }
            public function getPrescriresMedicament()
            {
                $erreur = "";
                $id_medicament = Request::input('cbMedicament');
                if($id_medicament)
                    {
                     $prescrire = new Prescrire();
                     $prescrires = $prescrire->getPrescriresMedicament($id_medicament);
                     return view('listePrescires', compact('prescrires','erreur'));
                    }
                    else
                    {
                        $erreur = "Il faut choisir un medicament";
                        Session::put('erreur', $erreur);
                        return redirect('/listerPrescrires');
                    }
            }
            public function getMedicaments()
            {
                $erreur = Session::get('erreur');
                Session::forget('erreur');
                $medicament = new Medicament();
            }       
            


       public function getPrescriresType_individu()
           {
            $erreur = "";
            $id_Type_individu = request::input('id_type_individu');
            //$lib_Type_individu = request::input('cbType_individu');
           // $id_Type_individu = existType_individu('cbType_individu');
            
            if($id_Type_individu)
            {
                $prescrire = new Prescrire();
                $prescrires = $prescrire->getPrescriresType_individu($id_Type_individu);
                return view('listePrescrires', compact('prescrires', 'erreur'));
            }
            else
            {
                $erreur = "Il faut saisir un Type individu";
                Session::put('erreur',$erreur);
                return redirect ('/listerPrescrires');
            }
           }
           
            public function getType_individus()
            {
                $erreur = Session::get('erreur');
                Session::forget('erreur');
                $type_individu = new Type_individu();
               ;
            }
            public function updatePrescrire($idMedicament,$idDosage, $idTypeIndividu, $erreur = "")
            {
             $leMedicament = new Medicament();
             $medicaments = $leMedicament->getMedicaments();
             $famille = new Famille();
             $familles = $famille->getFamilles();
             $prescrire = new Prescrire();
             $prescrires = $prescrire->getPrescrire($idMedicament,$idDosage,$idTypeIndividu);
             $dosage = new Dosage();
             $dosages = $dosage->getDosages();
             $type_individu = new Type_individu();
             $type_individus = $type_individu->getType_individus();
             $titreVue = "Modification d'une prescription";
             return view('formPrescrire', compact('prescrires','familles', 'titreVue', 'erreur','medicaments','dosages','type_individus'));
            }


            public function ValidatePrescrire()
            {  
                $id_dosage = Request::input('cbDosage');
                $lib_type_individu = Request::input('cbType_individu');
                $id_medicament = Request::input('cbMedicament');
                $id_type_individu = Request::input('id_type_individu');
                $posologie = Request::input('cbPosologie');
               
                
                
                $type_individu = new Type_individu();
                $prescrire = new Prescrire();
                
                if($id_type_individu == 0)
                {
                    
                     $type_individu->insertType_individu($lib_type_individu);
                     $result = $type_individu->dernierType_individu($lib_type_individu);
                     $id_type_individu = $result[0]->dernier;
                     $type_individu->insertPrescrireType($id_dosage, $id_medicament, $id_type_individu,$posologie);
                }
                try {if ($id_dosage > 0 && $id_medicament > 0 && $id_type_individu > 0 )
                {
                    $prescrire->updatePrescrire($id_dosage, $id_medicament, $id_type_individu, $posologie);
                }
              /*  else
                    {
                       
                                               
                        $type_individu->insertPrescrireType( $id_medicament, $id_type_individu, $id_dosage, $posologie);
                    }*/
                }
                    catch(Exception $ex){
                        $erreur = $ex->getMessage();
                        if($id_dosage > 0 && $id_medicament > 0 && $id_type_individu >  0)
                        {
                            return $this->updatePrescrire($id_dosage, $id_medicament, $id_type_individu, $erreur);
                        }
                        else 
                        {
                            return $this->addPrescrire($erreur);
                        }
                    }
                    
                return redirect('listerPrescrires');
            }
            
            public function addPrescrire($erreur="")
            {
                $prescrire = new Prescrire();
                $dosage = new Dosage();
                $dosages = $dosage->getDosages();
                $medicament = new Medicament();
                $medicaments = $medicament->getMedicaments();
                $type_individu = new Type_individu();
                $type_individus = $type_individu->getType_individus();
                $titreVue = "Ajout d'une prescription";
                return view('formPrescrire', compact('prescrire','dosages', 'medicaments', 'type_individus','titreVue','erreur'));
            }
            public function deletePrescrire($id_dosage, $id_medicament, $id_type_individu)
            {
              $medicament = new Medicament();
              $medicament->deleteMedicament($id_medicament); 
              $id_dosage = new Dosage();
              $id_dosage->deletePrescrire($id_dosage);
              $id_type_individu = new Type_individu();
              $id_type_individu->deletePrescrire($id_type_individu);
              
              return redirect('listerPrescrires');
            }
                    
                
           }
           

