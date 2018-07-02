@extends('layouts.master')
@section('content')
{!! Form::open(['url' => 'validerPrescrire','files' => true]) !!}

  
<div class="col-md-12 well well-sm">
    <center><h1> Ajouter une Prescription </h1></center>
    <div class="form-horizontal">    
        
        <div class="form-group">
            <label class="col-md-3 control-label">Medicament : </label>
            <div class="col-md- 3">
                <select class='form-control' name='cbMedicament' required>
                    <OPTION VALUE=0>Sélectionner un Medicament</option>
                    @foreach ($medicaments as $medicament)
                    selected=""
                    <option value="{{$medicament->id_medicament}}"
                            @if( $medicament->id_medicament == $prescrire->id_medicament  )
                            selected = "selected"
                            @endif
                            > {{ $medicament->nom_commercial }} </option>
                    @endforeach
                </select>
            </div>
        </div>
       
        
        <div class="form-group">
            <input type="hidden" name="id_type_individu" value="{{$prescrire->id_type_individu}}"/>
            <label class="col-md-3 control-label">Type d'individu : </label>
            <div class="col-md-3">
                <input type="text" name="cbType_individu" 
                       value=" {{ $prescrire->lib_type_individu}}" class="form-control" required autofocus>
            </div>
        </div>
        
        <div class="form-group">
            <label class="col-md-3 control-label">Dosage quantité & unité : </label>
            <div class="col-md- 3">
                <select class='form-control' name='cbDosage'  required>
                       <OPTION VALUE=0>Sélectionner une quantité par unité</option>
                    @foreach ($dosages     as $dosage) 
                    selected=""
                    <option value="{{$dosage->id_dosage}}"
                            @if( $dosage->id_dosage == $prescrire->id_dosage  )
                            selected = "selected"
                            @endif
                            > {{ $dosage->qte_dosage.' '.$dosage->unite_dosage }} </option>
                    
                    @endforeach 
                </select>
                
            </div>
        </div>
        
        
        
        <div class="form-group">
            <label class="col-md-3 control-label">Posologie : </label>
            <div class="col-md-3">
                <input type="text" name="cbPosologie" value=" {{ $prescrire->posologie or '' }}" class="form-control" >
            </div>
        </div>
        
        <div class="form-group">
            <div class="col-md-6 col-md-offset-3">
                <button type="submit" class="btn btn-default btn-primary"><span class="glyphicon glyphicon-ok"></span> Valider</button>
                &nbsp;
                <button type="button" class="btn btn-default btn-primary" onclick="javascript: window.location = '{{ url('/') }}';">
                    <span class="glyphicon glyphicon-remove"></span> Annuler</button>
            </div>           
        </div>
	    <div class="col-md-6 col-md-offset-3">
           @include('error')
        </div>
    </div>
</div>
{!! form::close() !!}
@stop