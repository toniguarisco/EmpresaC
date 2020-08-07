import { Component, OnInit, NgModule} from '@angular/core';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import {NgbModule} from '@ng-bootstrap/ng-bootstrap';
 



@Component({
  selector: 'app-bloqueo-operaciones',
  templateUrl: './bloqueo-operaciones.component.html',
  styleUrls: ['./bloqueo-operaciones.component.scss']
})



export class BloqueoOperacionesComponent implements OnInit {
  bloqueoForm = new FormGroup({
  
    selectedSortOrder: new FormControl('', Validators.required),
  });

 sortOrders: string[] = ["Tipo 1", "Tipo 2", "Tipo 3"];
  selectedSortOrder: string = "Tipo Operacion";



  constructor() { }

 
  ChangeSortOrder(newSortOrder: string) { 
    this.selectedSortOrder = newSortOrder;
  }



  ngOnInit(): void {
  }

  bloqueoOperaciones(): void{
 
      console.log('bloquear');
      console.log('Form -> ',this.selectedSortOrder)
    
  

  }

}

