import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';


@Component({
  selector: 'app-admin-config-parametros',
  templateUrl: './admin-config-parametros.component.html',
  styleUrls: ['./admin-config-parametros.component.scss']
})
export class AdminConfigParametrosComponent implements OnInit {

  parametrosForm = new FormGroup({
    montoMaxTransacciones : new FormControl('', Validators.required),
    maxOperacionesDiarias : new FormControl('', [Validators.required]),
    montoMaxDiario : new FormControl('', Validators.required)
  });

  comisionForm = new FormGroup({
    comision : new FormControl('', Validators.required)
  });

  constructor() { }

  ngOnInit(): void {
  }

  actualizarParametros(): void{
    console.log('click en actualizar paramteros');
    console.log(this.parametrosForm.value);
  }

  actualizarComision(): void{
    console.log('click en actualizar comision');
    console.log(this.comisionForm.value);
  }

}
