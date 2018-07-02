<?php

namespace App\modeles;
use DB;
use Illuminate\Database\Eloquent\Model;
use Exception;

class Prescrire extends Model
{
    public function getPrescrires()
            {
                $prescrires = DB::table('prescrire')
                        ->Select(/*'id_dosage', 'id_medicament', 'id_type_individu',*/'posologie','medicament.nom_commercial','type_individu.lib_type_individu','dosage.qte_dosage','dosage.unite_dosage')
                       ->join('dosage',  'prescrire.id_dosage', '=', 'dosage.id_dosage')
                       ->join('medicament',  'prescrire.id_medicament', '=', 'medicament.id_medicament')
                       ->join('type_individu',  'prescrire.id_type_individu', '=', 'type_individu.id_type_individu')
                        ->get();             
                
                       /* ->Select('id_dosage', 'id_medicament', 'id_type_individu')
                        ->join('dosage','dosage.id_dosage',"=", 'prescrire.id_dosage')
                        ->get();*/ 
                return $prescrires;
            }
           
            
            public function getPrescriresDosage($id_dosage)
            {
                $prescrires = DB::table('prescrire')
                        ->Select('dosage.qte_dosage','dosage.unite_dosage','id_medicament', 'id_type_individu', 'posologie')
                        ->Where('prescrire.id_dosage','=',$id_dosage)
                        ->join('dosage','prescrire.id_dosage','=','dosage.id_dosage')
                        ->get();
                        return $prescrires;
            }
            public function getPrescriresMedicament($id_medicament)
            {
                 $prescrires = DB::table('prescrire')
                        ->Select('id_dosage', 'medicament.nom_commercial', 'id_type_individu', 'posologie')
                        ->Where('prescrire.id_medicament','=',$id_medicament)
                        ->join('medicament','prescrire.id_medicament','=','medicament.id_medicament')
                        ->get();
                        return $prescrires;
            }
             
            public function getPrescriresType_individu($id_type_individu)
            {
                 $prescrires = DB::table('prescrire')
                        ->Select('id_dosage', 'id_medicament', 'type_individu.lib_type_individu', 'posologie')
                        ->Where('prescrire.id_type_individu','=',$id_type_individu)
                        ->join('type_individu','prescrire.id_type_individu','=','type_individu.id_type_individu')
                        ->get();
                        return $prescrires;
            }
            
            public function getPrescrire($idMedicament,$idDosage, $idTypeIndividu)
            {
                $prescrire = DB::table('prescrire')
                        ->select()
                        ->where('id_medicament', '=', $idMedicament)
                        ->where('id_dosage','=',$idDosage)
                        ->where('id_type_individu','=',$idTypeIndividu)
                        ->first();
                        return $prescrire;
            }
            public function updatePrescrire ($id_dosage, $id_medicament, $id_type_individu, $posologie)
            {
                try {
                    DB::table('prescrire')->where('id_dosage', '=', $id_dosage)
                            ->where('id_medicament','=', $id_medicament)
                            ->where('id_type_individu','=', $id_type_individu)
                   ->update  (['posologie'=> $posologie]);
                    
                }catch(Exception $ex){
                    throw $ex;
                }
            }
            public function insertPrescrire($id_medicament, $id_type_individu, $id_dosage, $posologie)
                    {
                
                try {
                  DB::table('prescrire')->insert(
            [ 'id_medicament' => $id_medicament, 'id_type_individu' => $id_type_individu,  'id_dosage' => $id_dosage,'posologie' => $posologie,]
                          ); 
                }  catch (Exception $ex) {
                    throw $ex;
                }
                    }
                    public function deletePrescrire($id_dosage, $id_medicament, $id_type_individu)
                    {
                         try {
                  $prescrire = DB :: table('prescrire')->where('id_dosage','=',$id_dosage,'&&','id_medicament', '=' ,$id_medicament,'&&','id_type_individu','=',$id_type_individu)->delete();
                    }
                 catch (Exception $ex)
               {
                  throw $ex;
               }
                    }
 
}
