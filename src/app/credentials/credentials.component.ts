import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-credentials',
  templateUrl: './credentials.component.html',
  styleUrls: ['./credentials.component.css']
})
export class CredentialsComponent implements OnInit {
  constructor(public loginname: string, public password: string) { }

  ngOnInit() {
  }

}