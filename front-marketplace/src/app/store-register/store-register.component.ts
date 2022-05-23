import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-store-register',
  templateUrl: './store-register.component.html',
  styleUrls: ['./store-register.component.css']
})
export class StoreRegisterComponent implements OnInit {
  title = 'front-marketplace';
  titlePage = 'Store';


  constructor() { }

  ngOnInit(): void {
  }

}
