@extends('layouts.master')
@section('content')
<div class="container">
    <div class="blanc">
        <h1>Liste de mes Prescriptions</h1>
    </div>
    <table class="table table-bordered table-striped">
        <thead>
            <tr>
                <th>Id medicament</th>
                <th>Nom medicament</th>
                <th>Quantité dosage</th>
                <th>Unité dosage</th>
                <th>Type d'individu</th>
                <th>Posologie</th>
                <th>Modification</th>
                <th>Supprimer</th>
                
            </tr>
        </thead>
        @foreach($prescrires as $prescrire)
        
        <tr>   
            <td> {{$prescrire->id_medicament}} </td> 
            <td> {{$prescrire->nom_commercial}} </td>
            <td> {{$prescrire->qte_dosage}}</td>
            <td> {{$prescrire->unite_dosage}}</td>
            <td> {{$prescrire->lib_type_individu}}</td>
            <td> {{$prescrire->posologie}} </td>
            <td style="text-align:center;"><a href="{{ url('/modifierPrescrire') }}/{{$prescrire->id_medicament}}">
                    <span class="glyphicon glyphicon-pencil" data-toggle="tooltip" data-placement="top" title="Modifier"></span></a></td>
            <td style="text-align:center;">
                <a class="glyphicon glyphicon-remove" data-toggle="tooltip" data-placement="top" title="Supprimer" href="#"
                    onclick="javascript:if (confirm('supression confirmée ?'))
                        { window.location='{{ url('/supprimerPrescrire') }}/{{$prescrire->id_medicament}}';}">
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