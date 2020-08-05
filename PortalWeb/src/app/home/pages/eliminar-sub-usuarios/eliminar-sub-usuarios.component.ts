import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import {NgbModule} from '@ng-bootstrap/ng-bootstrap/';

@Component({
  selector: 'app-eliminar-sub-usuarios',
  templateUrl: './eliminar-sub-usuarios.component.html',
  styleUrls: ['./eliminar-sub-usuarios.component.scss']
})
export class EliminarSubUsuariosComponent implements OnInit {

  bloqueoForm = new FormGroup({
    
  });

  constructor() { }

  ngOnInit(): void {
  }

  bloqueoOperaciones(): void{

  }
}
