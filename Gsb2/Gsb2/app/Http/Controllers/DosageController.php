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

class DosageController extends Controller
{
    public function getDosages()
    {
        $erreur= Session::get('erreur');
        Session::forget('erreur');
        $dosage = new Dosage();
        $dosages = $dosage->getDosages();
        return view ('formPrescrire',compact('dosages', 'erreur'));
    }
}
