import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-client-register',
  templateUrl: './client-register.component.html',
  styleUrls: ['./client-register.component.css']
})
export class ClientRegisterComponent implements OnInit {
  title = 'front-marketplace';
  titlePage = 'Client';

  constructor() { }

  ngOnInit(): void {
  }

}
