<?php

/*
|--------------------------------------------------------------------------
| Web Routes
|--------------------------------------------------------------------------
|
| Here is where you can register web routes for your application. These
| routes are loaded by the RouteServiceProvider within a group which
| contains the "web" middleware group. Now create something great!
|
*/

Route::get('/', function () {
    return view('home');
});
Route::get('/getLogin', 'UtilisateurController@getLogin');
Route::post('/signIn', 'UtilisateurController@signIn');
Route::get('/signOut', 'UtilisateurController@signOut');
Route::get('/listerMedicaments', 'MangaController@getMedicaments');
Route::get('/listerFamilles','GenreController@getFamilles');
Route::post('/listerMedicamentsFamille', 'MangaController@getMedicamentsFamille');
Route::get('/modifierMedicament/{id}', 'MangaController@updateMedicament');
Route::post('/validerMedicament','MangaController@validateMedicament');
Route::get('/ajouterMedicament','MangaController@addMedicament');
Route::get('/supprimerMedicament/{id}','MangaController@deleteMedicament');

Route::get('/listerPrescrires','PrescrireController@getPrescrires');
Route::get('/listerDosages','PrescrireController@getPrescriresDosage');
Route::get('/listerMedicamentp','PrescrireController@getPrescriresMedicament');
Route::get('/listerType_individus','PrescrireController@getPrescriresType_individu');
Route::get('/modifierPrescrire/{id}','PrescrireController@updatePrescrire');
Route::post('/validerPrescrire','PrescrireController@validatePrescrire');

Route::get('/ajouterPrescrire','PrescrireController@addPrescrire');
Route::get('/supprimerPrescrire/{id}','PrescrireController@deletePrescrire');

Route::group(['middleware' => ['autorise']], function()
{   
    Route::get('/signOut', 'UtilisateurController@signOut');
    Route::get('/listerMedicaments','MangaController@getMedicaments');
    Route::get('/listerFamilles', 'GenreController@getFamilles');
    Route::get('/listerMedicamentsFamille','MangaController@getMedicamentsFamille');
    Route::get('/modifierMedicament/{id}', 'MangaController@updateMedicament');
    Route::get('/validerMedicament','MangaController@validateMedicament');
    Route::get('/ajouterMedicament','MangaController@addMedicament');
    Route::get('/supprimerMedicament/{id}','MangaController@deleteMedicament');
    
    Route::get('/listerPrescrires','PrescrireController@getPrescrires');
    Route::get('/listerDosages','PrescrireController@getPrescriresDosage');
    Route::get('/listerMedicamentp','PrescrireController@getPrescriresMedicament');
    Route::get('/listerType_individus','PrescrireController@getPrescriresType_individu');
    Route::get('/modifierPrescrire/{id}','PrescrireController@updatePrescrire');
    Route::get('/validerPrescrire','PrescrireController@validatePrescrire');
   
    Route::get('/ajouterPrescrire','PrescrireController@addPrescrire');
    Route::get('/supprimerPrescrire/{id}','PrescrireController@deletePrescrire');
});
