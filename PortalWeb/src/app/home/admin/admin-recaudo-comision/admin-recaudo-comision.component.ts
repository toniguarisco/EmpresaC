import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-admin-recaudo-comision',
  templateUrl: './admin-recaudo-comision.component.html',
  styleUrls: ['./admin-recaudo-comision.component.scss']
})
export class AdminRecaudoComisionComponent implements OnInit {
  parametrosForm = new FormGroup({
    NombreEmpresa : new FormControl('', Validators.required),
    TotalComisiones : new FormControl('', [Validators.required]),
  });

  comisionForm = new FormGroup({
    TotalTotal : new FormControl('', Validators.required)
  });

  constructor() { }

  ngOnInit(): void {
  }

  consultarTotalEmpresa(): void{
    console.log('click en actualizar paramteros');
    console.log(this.parametrosForm.value);
  }

  consultarTotalTotal(): void{
    console.log('click en actualizar comision');
    console.log(this.comisionForm.value);
  }

}
