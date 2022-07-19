import { Component, OnInit } from '@angular/core';
import { Route, Router } from '@angular/router';
import axios from 'axios';

@Component({
  selector: 'app-store-register',
  templateUrl: './store-register.component.html',
  styleUrls: ['./store-register.component.css']
})
export class StoreRegisterComponent implements OnInit {
  title = 'front-marketplace';
  titlePage = 'Store Register';


  constructor(private router: Router) { }

  Cancel() : void{
    window.location.reload;
  }

  CreateStore() : void{
    let name = document.getElementById("Name") as HTMLInputElement;
    let CNPJ = document.getElementById("CNPJ") as HTMLInputElement;

    var data = JSON.stringify({
      "name": name?.value,
      "CNPJ": CNPJ?.value,
      "owner": {
        "login": localStorage.getItem("user")
      }
    });
    var config = {
      method: 'post',
      url: 'http://localhost:5009/store/register',
      headers: { 
        'Authorization': 'Bearer ' + localStorage.getItem('authToken'),
        'Content-Type': 'application/json'
      },
      data : data
    };

    var instance = this;
    axios(config)
      .then(function (response:any) {
        console.log(JSON.stringify(response.data));
      })
      .catch(function (error:any) {
        console.log(error);
        if (error.response.status == 401){
          instance.router.navigate(['/login']) 
        }
    });

  }

  ngOnInit(): void {
    var instance = this;
    if (localStorage.getItem("isOwner") != 'true'){
      instance.router.navigate(['/login']) 
    }
  }

}
