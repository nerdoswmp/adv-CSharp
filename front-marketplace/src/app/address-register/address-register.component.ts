import { Component, OnInit } from '@angular/core';
import { TopBarComponent } from '../top-bar/top-bar.component';

@Component({
  selector: 'app-address-register',
  templateUrl: './address-register.component.html',
  styleUrls: ['./address-register.component.css']
})
export class AddressRegisterComponent implements OnInit {
  title = 'front-marketplace';
  titlePage = 'Address';

  constructor() { }

  ngOnInit(): void {
  }

}
