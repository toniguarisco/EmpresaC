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

  sortOrders: string[] = ["Carlos Perez", "Karla Perez", "Manuel Perez", "Marcia Avila"];
  selectedSortOrder: string = "Sub Usuario";



  constructor() { }

 
  ChangeSortOrder(newSortOrder: string) { 
    this.selectedSortOrder = newSortOrder;
  }


  ngOnInit(): void {
  }

  eliminarSubusuario(): void{

    console.log('bloquear');
    console.log('Form -> ',this.selectedSortOrder)
  
  }
}
