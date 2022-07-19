import { Component, OnInit } from '@angular/core';
import axios from 'axios'
import {Product} from '../products'
import {Router} from '@angular/router'

@Component({
  selector: 'app-owner-products',
  templateUrl: './owner-products.component.html',
  styleUrls: ['./owner-products.component.css']
})
export class OwnerProductsComponent implements OnInit {
  titlePage = "All Products on Sale"
  products : [Product] | undefined
  isOwner = localStorage.getItem('isOwner');
  constructor(private route: Router) { }

  ngOnInit(): void {    
    var config = {
      method: 'get',
      url: 'http://localhost:5009/product/all/' + localStorage.getItem("user"),
      headers: { 
        "Access-Control-Allow-Origin":"*",
        "Access-Control-Allow-Headers":"Content-Type",
        'Authorization':'Bearer '+localStorage.getItem("authToken"),
        'Content-Type' : 'application/json',
      }
    };

    var instance = this;
    
    axios(config)
    .then(function (response:any) {
      console.log(JSON.stringify(response.data));
      instance.products = response.data;
      console.log(instance.products)
    })
    .catch(function (error:any) {
      console.log(error);
      if (error.response.status == 401){
        instance.route.navigate(['/login']) 
      }
    });
  }
}