<?php
namespace App\Http\Controllers;
use Illuminate\Support\Facades\Session;
use App\modeles\Famille;

class GenreController extends Controller
{
    public function getFamilles() {
        $erreur = Session::get('erreur');
        Session::forget('erreur');
        $famille = new Famille();
        $familles = $famille->getFamilles();
        return view('formFamille', compact('familles', 'erreur'));
    }
}
