import { Component, OnInit } from '@angular/core';
import {AuthenticateService} from './loginService/login.service'
import {CredentialsComponent} from '../credentials/credentials.component';
import { NgForm, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
  providers : [AuthenticateService]

})
export class LoginComponent {
  
  onSignin(form: NgForm){
    const UserName = form.value.UserName;
    const Password = form.value.Password;
  
    if(UserName=="admin"&&Password=="1234")
    debugger;  
    console.log('Ok');

  }
}
  
