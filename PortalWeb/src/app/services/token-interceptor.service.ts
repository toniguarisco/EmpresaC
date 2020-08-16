import { Injectable } from '@angular/core';
import { HttpInterceptor } from "@angular/common/http";
import { AuthService } from "../services/auth.service";

@Injectable({
  providedIn: 'root'
})
export class TokenInterceptorService implements HttpInterceptor {

  constructor( private authService: AuthService) { }

  intercept(req,next){
    const tokenizeReq = req.clone({
      setHeaders:{
        Authorization: `Bearer ${localStorage.getItem('token')}`
      }
    })
    return next.handle(tokenizeReq);
  }


}
