<?php

namespace App\modeles;

use DB;
use Illuminate\Database\Eloquent\Model;
use Exception;

class Type_individu extends Model {

    public function getType_individus() {
        $type_individus = DB::table('type_individu')
                ->get();
        return $type_individus;
    }

    public function insertType_individu( $lib_type_individu) {
        try {
            DB::table('type_individu')->insert(
                    ['lib_type_individu' => $lib_type_individu]
            );
        } catch (Exception $ex) {
            throw $ex;
        }
    }

    public function insertPrescrireType($id_dosage, $id_medicament, $id_type_individu, $posologie) {
        try {
            DB::table('prescrire')->insert(
                    ['id_dosage' => $id_dosage, 'id_medicament' => $id_medicament, 'id_type_individu' => $id_type_individu, 'posologie' => $posologie]
            );
        } catch (Exception $ex) {
            throw $ex;
        }
    }

    public function dernierType_individu($lib_type_individu) {
        try {
            $id_type_individu = DB::select("select MAX(id_type_individu) as dernier from type_individu");
            return $id_type_individu;
        } catch (Exception $ex) {
            throw $ex;
        }
    }

}
