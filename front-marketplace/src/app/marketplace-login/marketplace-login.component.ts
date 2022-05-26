import { Component, OnInit } from '@angular/core';
import axios from 'axios';


@Component({
  selector: 'app-marketplace-login',
  templateUrl: './marketplace-login.component.html',
  styleUrls: ['./marketplace-login.component.css']
})
export class MarketplaceLoginComponent implements OnInit {
  title = 'front-marketplace';
  titlePage = 'Marketplace';

  constructor() { }

   loginUser(){
    let user = document.getElementById("user") as HTMLInputElement;
    let passwd = document.getElementById("passwd") as HTMLInputElement;
    console.log(user?.value);      
    console.log(passwd?.value);
  
    var data = JSON.stringify({
      "login": user?.value,
      "passwd": passwd?.value
    });  
    var config = {
      method: 'post',
      url: 'http://localhost:5009/client/login',
      headers: { 
        'Content-Type': 'application/json'
      },
      data : data
    };
    
    axios(config)
    .then(function (response: any) {
      console.log(JSON.stringify(response.data));
    })
    .catch(function (error: any) {
      console.log(error);
    });
    //return
}

  ngOnInit(): void {    
    
   }

}
