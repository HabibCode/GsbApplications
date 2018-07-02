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

class Type_individuController extends Controller
{
   public function getType_individus()
   {
       $erreur = Session::get('erreur');
       Session::forget('erreur');
       $type_individu = new Type_individu();
       $type_individus= $type_individu->getTypes_individus();
       return view('formPrescrire',compact('type_individus','erreur'));
   }
   /*public function  validateType_individu()
   {
        $lib_type_individu = Request::input('cbType_individu');
        $id_type_individu = Request::input('id_type_individu');
        $type_individu = new Type_individu();
         if($id_type_individu = 0 )
         {
             $type_individu->insertType_individu($id_type_individu,$lib_type_individu);
         }
         return redirect('/listerPrescrires');
   }*/
   
}
