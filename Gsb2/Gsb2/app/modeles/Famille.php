<?php
namespace App\modeles;
use Illuminate\Database\Eloquent\Model;
use DB;



class Famille extends Model
{
    public function getFamilles() 
    {
        $familles = DB::table('famille')->get();
        return $familles;
    }
}
