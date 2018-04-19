import { Injectable } from '@angular/core';
import {CredentialsComponent} from '../../credentials/credentials.component'
import { Router } from '@angular/router';

var users = [
  new CredentialsComponent('admin','admin'),
  new CredentialsComponent('admin1','admin1')
];

@Injectable()
export class AuthenticateService {

  constructor(private _router: Router) { }

  logout() {
    localStorage.removeItem("user");
    this._router.navigate(['/login']);
  }

  login(user) {
    let authenticatedUser = users.find(u => u.loginname === user.username);
    if (authenticatedUser && authenticatedUser.password === user.password){
      localStorage.setItem("user", authenticatedUser.loginname);
      this._router.navigate(['/user']);
      return true;
    }
    return false;
  }

  checkCredentials() {
    if (localStorage.getItem("user") === null){
      this._router.navigate(['/login']);
    }
  }
}