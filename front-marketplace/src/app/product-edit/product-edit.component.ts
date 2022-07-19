import { Component, OnInit } from '@angular/core';
import { Route, Router } from '@angular/router';
import { ActivatedRoute } from '@angular/router';
import { TopBarComponent } from '../top-bar/top-bar.component';
import { Product, products} from '../products';
import  axios from 'axios';

@Component({
  selector: 'app-product-edit',
  templateUrl: './product-edit.component.html',
  styleUrls: ['./product-edit.component.css']
})
export class ProductEditComponent implements OnInit {
  titlePage="Product Edit";
  title = 'front-marketplace';
  constructor(private route: ActivatedRoute, private router: Router) { }

  ngOnInit(): void {
    var token = localStorage.getItem('authToken')
    const routeParams = this.route.snapshot.paramMap;
    const productIdFromRoute = Number(routeParams.get('productID'));

    var data = '';

    var instance = this;

    var config = {
      method: 'post',
      url: 'http://localhost:5009/product/verify/' + productIdFromRoute + '/' + localStorage.getItem('user'),
      headers: { 
        'Content-Type': 'application/json',
        'Authorization': 'Bearer ' + token
      },
      data:data
    };
    
    axios(config)
    .then(function (response) {
      console.log(JSON.stringify(response.data));
      if (response.data == false){
        instance.router.navigate(['/']) 
      }
    })
    .catch(function (error) {
      console.log(error)
      if (error.response.status == 404 || error.response.status == 500){
        instance.router.navigate(['/']) 
      }
    });
  }


  editProduct(): void{
    var instance = this;
    var token = localStorage.getItem('authToken')
    const routeParams = this.route.snapshot.paramMap;
    const productIdFromRoute = Number(routeParams.get('productID'));
    const storeIdFromRoute = Number(routeParams.get('storeID'));
    let name = document.getElementById("name") as HTMLInputElement;
    let description = document.getElementById("description") as HTMLInputElement;
    let value = document.getElementById("preco") as HTMLInputElement;
    let quantidade = document.getElementById("quantidade") as HTMLInputElement;

    var data = JSON.stringify({
      "name": name?.value,
      "description": description?.value,
      "quantidade":quantidade?.value,
      "preço":value?.value
    });

    var config = {
      method: 'put',
      url: 'http://localhost:5009/product/update/' + productIdFromRoute+'/'+storeIdFromRoute,
      headers: { 
        'Content-Type': 'application/json',
        'Authorization': 'Bearer ' + token
      },
      data:data
    };
    
    axios(config)
    .then(function (response) {
      console.log(JSON.stringify(response.data));
      alert("Produto editado com sucesso!!")
    })
    .catch(function (error) {
      console.log(error)
      if (error.response.status == 401){
        instance.router.navigate(['/login']) 
      }
      alert("Produto não editado com sucesso")
    });
    
  }

}
