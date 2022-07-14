import { Component, OnInit } from '@angular/core';
import { Route, Router } from '@angular/router';
import axios from 'axios';

@Component({
  selector: 'app-client-register',
  templateUrl: './owner-register.component.html',
  styleUrls: ['./owner-register.component.css']
})
export class OwnerRegisterComponent implements OnInit {
  title = 'front-marketplace';
  titlePage = 'Owner';

  constructor(private router: Router) { }
    registerUser(): void{
      let name = document.getElementById("name") as HTMLInputElement;
      let email = document.getElementById("email") as HTMLInputElement;
      let password = document.getElementById("password") as HTMLInputElement;
      let doc = document.getElementById("document") as HTMLInputElement;
      let phone = document.getElementById("phone") as HTMLInputElement;
      let login = document.getElementById("login") as HTMLInputElement;
      let birthday = document.getElementById("birthday") as HTMLInputElement;
      let street = document.getElementById("street") as HTMLInputElement;
      let city = document.getElementById("city") as HTMLInputElement;
      let state = document.getElementById("state") as HTMLInputElement;
      let country = document.getElementById("country") as HTMLInputElement;
      let postalcode = document.getElementById("postalcode") as HTMLInputElement;
      var data = JSON.stringify({
        "name": name?.value,
        "email": email?.value,
        "passwd": password?.value,
        "document": doc?.value,
        "phone": phone?.value,
        "login": login?.value,
        "date_of_birth": birthday?.value,
        "address": {
          "street": street?.value,
          "city": city?.value,
          "state": state?.value,
          "country": country?.value,
          "postal_code": postalcode?.value,
        }
      });

      let self = this;

      var config = {
        method: 'post',
        url: 'http://localhost:5009/owner/register',
        headers: { 
          'Content-Type': 'application/json'
        },
        data : data
      };
    
      axios(config)
      .then(function (response) {
        console.log(JSON.stringify(response.data));
        if (response.data["id"] == -1){
          alert("Ese email já foi cadastrado")
        }
        if (response.data["id"] == -2){
          alert("Este telefone já foi cadastrado")
        }
        if (response.data["id"] == -3){
          alert("Este documento já foi cadastrado")
        }
        if (response.data["id"] == -4){
          alert("Este usuário já foi cadastrado")
        }
        else if(response.data["id"] > 0){
          self.router.navigate(['/login'])  
        } 
      })
      .catch(function (error) {
        console.log(error);
        alert("Favor preencher todos os campos")
      });
    }

  ngOnInit(): void {
  }
  
}
