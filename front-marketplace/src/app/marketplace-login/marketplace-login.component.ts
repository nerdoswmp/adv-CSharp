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

   loginUser(user : String,passwd : String){
    console.log(user)        
    console.log(passwd)
    //   var config = {
  //     method: 'get',
  //     url: 'http://localhost:5009/client/login',
  //     headers: { 
  //       'Content-Type': 'application/json'
  //     },
  //   };

  //   var instance = this;
        
  //   axios(config)
  //   .then(function (response) {
  //     console.log(JSON.stringify(response.data));
  //   })
  //   .catch(function (error) {
  //     console.log(error);
  //   });
}

  ngOnInit(): void {
  
   }

}
