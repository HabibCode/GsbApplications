<?php

namespace App\modeles;
use Illuminate\Database\Eloquent\Model;
use DB;
use Exception;

class Medicament extends Model
{
    public function getMedicaments()
    {
        $medicaments = DB::table('medicament')
                ->Select('id_medicament','nom_commercial','famille.lib_famille','effets','contre_indication','prix_echantillon')
                        ->join('famille','medicament.id_famille',"=", 'famille.id_famille')
                        //->join('dessinateur', 'manga.id_dessinateur', '=', 'dessinateur.id_dessinateur')
                        //->join('scenariste', 'manga.id_scenariste', '=', 'scenariste.id_scenariste')
                        ->get();
                return $medicaments;
    }
    
  
    public function getMedicamentsFamille($id_famille){
        $medicaments = DB::table('medicament')
                ->Select('id_medicament','nom_commercial', 'famille.lib_famille', 'effets','contre_indication','prix_echantillon')
                ->where('medicament.id_famille', '=', $id_famille)
                ->join('famille', 'medicament.id_famille', '=', 'famille.id_famille')
                //->join('dessinateur','manga.id_dessinateur','=','dessinateur.id_dessinateur')
                //->join('scenariste', 'manga.id_scenariste','=', 'scenariste.id_scenariste')
                ->get();
        return $medicaments;
    }
     public function getMedicament($idMedicament)
     {
         $medicament = DB::table('medicament')
                 ->select()
                 ->where('id_medicament', '=' , $idMedicament)
                 ->first();
         return $medicament;
     }
     public function updateMedicament ($id_medicament, $nom_commercial, /*$couverture,*/ $prix_echantillon, $effets, $id_famille, $contre_indication)
     {
         try {
             DB::table('medicament')->where('id_medicament', '=', $id_medicament)
                     ->update(['effets'=> $effets, 'prix_echantillon' => $prix_echantillon,
                         'nom_commercial' => $nom_commercial, /*'couverture' => $couverture,*/ 
                         'id_famille' => $id_famille, 'contre_indication' => $contre_indication]);
         }catch(Exception $ex) {
         throw $ex;
         } 
     }
     public function insertMedicament($nom_commercial,   $prix_echantillon, $effets, $id_famille, $contre_indication)
     {
        try {
            DB::table('medicament')->insert(
                    ['effets' => $effets, 'prix_echantillon' => $prix_echantillon, 'nom_commercial' => $nom_commercial,/* 'couverture' => $couverture,*/
                        'id_famille' => $id_famille, 'contre_indication' => $contre_indication]
                    );
         
         } catch(Exception $ex) {
             throw $ex;
         }
     }

     public function deleteMedicament($id_medicament)
     {           
         try {
            $medicament = DB :: table('medicament')->where('id_medicament', '=' ,$id_medicament)->delete();
         }
            catch (Exception $ex)
               {
                  throw $ex;
               }

                 
     }

}
