@extends('layouts.master')
@section('content')
<div class="container">
    <div class="blanc">
        <h1>Liste de mes Medicaments</h1>
    </div>
    <table class="table table-bordered table-striped">
        <thead>
            <tr>
                <th>Id</th>
                <th>Titre</th>
                <th>Famille</th>
                <th>effets</th>
                <th>contre indication</th>
                <th>Prix</th>
                <th>Modification </th>
                <th>Supression </th>
            </tr>
        </thead>
        @foreach($medicaments as $medicament)
        <tr>   
            <td> {{$medicament->id_medicament}} </td> 
            <td> {{$medicament->nom_commercial}} </td>
            <td> {{$medicament->lib_famille}} </td>
            <td> {{$medicament->effets}}</td>
            <td> {{$medicament->contre_indication}}</td>
            <td> {{$medicament->prix_echantillon}} </td>
            <td style="text-align:center;"><a href="{{ url('/modifierMedicament') }}/{{$medicament->id_medicament}}">
                    <span class="glyphicon glyphicon-pencil" data-toggle="tooltip" data-placement="top" title="Modifier"></span></a></td>
            <td style="text-align:center;">
                <a class="glyphicon glyphicon-remove" data-toggle="tooltip" data-placement="top" title="Supprimer" href="#"
                    onclick="javascript:if (confirm('supression confirmée ?'))
                        { window.location='{{ url('/supprimerMedicament') }}/{{$medicament->id_medicament}}';}">
                </a>
            </td>                    
        </tr>
        @endforeach
        <BR> <BR>
    </table>
	<div class="col-md-6 col-md-offset-3">
        @include('error')
    </div>
</div>
@stop