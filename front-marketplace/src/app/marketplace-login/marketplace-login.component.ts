import { Component, OnInit } from '@angular/core';
import { Route, Router } from '@angular/router';
import axios from 'axios';


@Component({
  selector: 'app-marketplace-login',
  templateUrl: './marketplace-login.component.html',
  styleUrls: ['./marketplace-login.component.css']
})
export class MarketplaceLoginComponent implements OnInit {
  title = 'front-marketplace';
  titlePage = 'Marketplace';

  constructor(private router: Router) { }
  loginType(): void{
    let user = document.getElementById("user") as HTMLInputElement;
    let passwd = document.getElementById("passwd") as HTMLInputElement;
    var data = JSON.stringify({
      "login": user?.value,
      "passwd": passwd?.value
    });

    var config = {
      method: 'post',
      url: 'http://localhost:5009/login/type',
      headers: { 
        'Content-Type': 'application/json'
      },
      data : data
    };
    
    var instance = this;
    axios(config)
    .then(function (response: any) {
      console.log(JSON.stringify(response.data));
      localStorage.setItem('isOwner',response.data)//guarda no local storage
      instance.loginUser();
    })
    .catch(function (error: any) {
      console.log(error);
    });

  }


  loginUser(): void{
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
      url: 'http://localhost:5009/login/login',
      headers: { 
        'Content-Type': 'application/json'
      },
      data : data
    };
    
    let self = this;
    axios(config)
    .then(function (response: any) {
      localStorage.setItem('authToken',response.data)//guarda no local storage
      localStorage.setItem('user',user?.value)//guarda no local storage
      console.log(localStorage.getItem('authToken'));//pega do local storage       
      self.router.navigate([''])      
    })
    .catch(function (error: any) {
      console.log(error);      
      localStorage.removeItem('authToken');
      localStorage.removeItem('user');
      localStorage.removeItem('isOwner');
    });
    //return
}

  ngOnInit(): void {    
   }
}