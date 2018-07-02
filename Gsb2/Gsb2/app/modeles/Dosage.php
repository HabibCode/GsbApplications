<?php

namespace App\modeles;
use DB;
use Illuminate\Database\Eloquent\Model;
use Exception;
class Dosage extends Model
{
   public function getDosages()
   {    
       $dosages= DB::table('dosage')->get();
       return $dosages;
   }
}
