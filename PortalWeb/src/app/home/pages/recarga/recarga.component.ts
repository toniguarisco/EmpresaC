import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import {NgbModule} from '@ng-bootstrap/ng-bootstrap/';

@Component({
  selector: 'app-recarga',
  templateUrl: './recarga.component.html',
  styleUrls: ['./recarga.component.scss']
})
export class RecargaComponent implements OnInit {

  recargaForm = new FormGroup({
    montoMaxTransacciones : new FormControl('', Validators.required),
    maxOperacionesDiarias : new FormControl('', [Validators.required]),
    montoMaxDiario : new FormControl('', Validators.required)
  });


  constructor() { }


  ngOnInit(): void {
  }

  recargarSaldo(): void{

  }

}
