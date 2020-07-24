import { Component, OnInit } from '@angular/core';
import { AuthService } from '../services/auth.service';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

 /*  fecha :string; */
 

  constructor(private authService: AuthService) { }

  ngOnInit(): void {
  /*   if (this.fecha != null) {
      this.formatFecha();      
    } */
  }
/* 
  formatFecha(){
    var today = new Date();
    var dd = String(today.getDate()).padStart(2, '0');
    var mm = String(today.getMonth() + 1).padStart(2, '0'); //January is 0!
    var yyyy = today.getFullYear();

    this.fecha = dd + '/' + mm + '/' + yyyy;
    document.write(this.fecha);
  } */
}
