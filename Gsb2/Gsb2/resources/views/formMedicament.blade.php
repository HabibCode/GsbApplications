@extends('layouts.master')
@section('content')
{!! Form::open(['url' => 'validerMedicament','files' => true]) !!}

  
<div class="col-md-12 well well-sm">
    <center><h1> Ajouter un Medicament </h1></center>
    <div class="form-horizontal">    
        <div class="form-group">
            <input type="hidden" name="id_medicament" value="{{$medicament->id_medicament or 0}} "/>
            <label class="col-md-3 control-label">Titre : </label>
            <div class="col-md-3">
                <input type="text" name="nom_commercial" 
                       value="{{$medicament->nom_commercial or ''}}" class="form-control" required autofocus>
              </div>
        </div>
        <div class="form-group">
            <label class="col-md-3 control-label">Famille : </label>
            <div class="col-md- 3">
                <select class='form-control' name='cbFamille' required>
                    <OPTION VALUE=0>Sélectionner une Famille</option>
                    @foreach ($familles as $famille)
                    selected=""
                    <option value="{{$famille->id_famille}}"
                            @if( $famille->id_famille == $medicament->id_famille  )
                            selected = "selected"
                            @endif
                            > {{ $famille->lib_famille }} </option>
                    @endforeach
                </select>
            </div>
        </div>
       
          <div class="form-group">
            <label class="col-md-3 control-label">effets : </label>
            <div class="col-md-3">
                <input type="text" name="cbEffets" value=" {{ $medicament->effets or 0 }}" class="form-control" >
            </div>
        </div>
        
        <div class="form-group">
            <label class="col-md-3 control-label">contre indication : </label>
            <div class="col-md-3">
                <input type="text" name="cbContre_indication" value=" {{ $medicament->contre_indication or 0 }}" class="form-control" >
            </div>
        </div>
        
        <div class="form-group">
            <label class="col-md-3 control-label">Prix : </label>
            <div class="col-md-3">
                <input type="text" name="prix_echantillon" value=" {{ $medicament->prix_echantillon or 0 }}" class="form-control" >
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