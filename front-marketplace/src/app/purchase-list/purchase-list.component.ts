import { Component, OnInit } from '@angular/core';
import { products } from '../products';
import { Purchases } from '../purchases';
import { Route, Router } from '@angular/router';
import axios from 'axios';
import { InstantiateExpr } from '@angular/compiler';

@Component({
  selector: 'app-purchase-list',
  templateUrl: './purchase-list.component.html',
  styleUrls: ['./purchase-list.component.css']
})
export class PurchaseListComponent implements OnInit {
  title = 'front-marketplace';
  titlePage = 'Purchases';

  purchases : [Purchases] | undefined;

  constructor(private router: Router) { }

  ngOnInit(): void {  

    var instance = this;
    var token = localStorage.getItem('authToken')

    var config = {
      method: 'get',
      url: 'http://localhost:5009/purchase/client/'+ localStorage.getItem('user'),
      headers: { 
        'Content-Type': 'application/json',
        'Authorization': 'Bearer ' + token
      },
    };

    
    
    axios(config)
    .then(function (response) {
      console.log(JSON.stringify(response.data));
      instance.purchases = response.data;
    })
    .catch(function (error) {
      console.log(error);
      if (error.response.status == 401){
        instance.router.navigate(['/login']) 
      }
    });
  }
}