import { Component, OnInit } from '@angular/core';
import * as CryptoJS from 'crypto-js';
import { FormGroup, FormControl, Validators, } from '@angular/forms';

@Component({
  selector: 'app-encriptacion',
  templateUrl: './encriptacion.component.html',
  styleUrls: ['./encriptacion.component.scss']
})
export class EncriptacionComponent implements OnInit {

  title = 'EncryptionDecryptionSample';

  plainText: string;
  encryptText: string;
  encPassword: string;
  decPassword: string;
  conversionEncryptOutput: string;
  conversionDecryptOutput: string;
  constructor() { }

  ngOnInit(): void {
    this.plainText = 'algo';
    this.encPassword = '';
    this.conversionEncryptOutput = CryptoJS.AES.encrypt(this.plainText.trim(), this.encPassword.trim()).toString();
    console.log('encriptado => ', this.conversionEncryptOutput );
    this.conversionEncryptOutput = CryptoJS.AES.encrypt(this.plainText.trim(), 'clave').toString();
    console.log('encriptado => ', this.conversionEncryptOutput );
  }

  convertText(conversion: string) {
    if (conversion === 'encrypt') {
      this.conversionEncryptOutput = CryptoJS.AES.encrypt(this.plainText.trim(), this.encPassword.trim()).toString();
    } else {
      this.conversionDecryptOutput = CryptoJS.AES.decrypt(this.encryptText.trim(), this.decPassword.trim()).toString(CryptoJS.enc.Utf8);
    }
}
}
