@extends('layouts.master')
@section('content')
{!! Form::open(['url' => 'listerMedicamentsFamille'])!!}
<div class="col-md-12 well well-sm">
    <center><h1>Choix d'une Famille</h1></center>
    <div class="form-horizontal">    
        <div class="form-group">
            <label class="col-md-3 control-label">Famille : </label>
            <div class="col-md-3">
                <select class='form-control' name='cbFamille' required>
                    <OPTION VALUE=0>Sélectionner une famille</option>
                    @foreach ($familles as $famille)
                    <option value="{{$famille->id_famille}}"> {{ $famille->lib_famille}} </option>
                    @endforeach
                </select>
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-6 col-md-offset-3">
                <button type="submit" class="btn btn-default btn-primary"><span class="glyphicon glyphicon-ok"></span> Valider</button>
                &nbsp;
                <button type="button" class="btn btn-default btn-primary" 
                    onclick="javascript: window.location = '{{ url('/listerMedicamentsFamille') }}';">
                    <span class="glyphicon glyphicon-remove"></span> Annuler </button>
            </div>           
        </div>
		<div class="col-md-6 col-md-offset-3">
            @include('error')
        </div>
    </div>
</div>
{!! Form::close() !!}
@stop

