<?php

namespace App\modeles;

use Illuminate\Database\Eloquent\Model;
use Illuminate\Support\Facades\Session;
use DB;
class Utilisateur extends Model
{
   Public function login($login, $pwd)
   {
       $connected = false;
       $user = DB::table('praticien')
               ->select()
               ->where('nom_praticien', '=' , $login)
               ->first();
       if($user)
           {
            if($user->id_praticien == $pwd)
            {
                Session::put('id' , $user->id_praticien);
                $connected = true;
            }
           }
           return $connected;
   }
   public function logout()
   {
       Session::forget('id');
   }
}  
