import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import {NgbModule} from '@ng-bootstrap/ng-bootstrap/';

@Component({
  selector: 'app-bloqueo-operaciones',
  templateUrl: './bloqueo-operaciones.component.html',
  styleUrls: ['./bloqueo-operaciones.component.scss']
})
export class BloqueoOperacionesComponent implements OnInit {
  bloqueoForm = new FormGroup({
    
  });


  constructor() { }


  ngOnInit(): void {
  }

  bloqueoOperaciones(): void{

  }

}
