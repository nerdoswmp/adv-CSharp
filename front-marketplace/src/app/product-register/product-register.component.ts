import { Variable } from '@angular/compiler/src/render3/r3_ast';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Product } from '../products';
import { WishList } from '../wishlist';
import axios from 'axios';
import { NumberValueAccessor } from '@angular/forms';
import { Route, Router } from '@angular/router';
import { Stores } from '../stores';

@Component({
  selector: 'app-product-register',
  templateUrl: './product-register.component.html',
  styleUrls: ['./product-register.component.css']
})
export class ProductRegisterComponent implements OnInit {
  titlePage = "Product Register";
  title = 'front-marketplace';

  stores: [Stores] | undefined;

  isOwner = localStorage.getItem('isOwner');
  constructor() { }
  registerProduct() {
    let name = document.getElementById("name") as HTMLInputElement;
    let description = document.getElementById("description") as HTMLInputElement;
    let image = document.getElementById("image") as HTMLInputElement;
    let select = document.getElementById("store") as HTMLSelectElement;
    let option = select.options[select.selectedIndex];///////////////////////////////////AQUI
    let barCode = document.getElementById("barCode") as HTMLInputElement;
    let quantidade = document.getElementById("quantidade") as HTMLInputElement;
    let preco = document.getElementById("preco") as HTMLInputElement;

    var data = JSON.stringify({
      "name": name?.value,
      "description": description?.value,
      "image": image?.value,
      "bar_code":barCode?.value
    });

    var config = {
      method: 'post',
      url: 'http://localhost:5009/product/register',
      headers: {
        "Access-Control-Allow-Origin": "*",
        "Access-Control-Allow-Headers": "Content-Type",
        'Authorization': 'Bearer ' + localStorage.getItem("authToken"),
        'Content-Type': 'application/json',
      },
      data: data,
    };
    var instance = this;
    axios(config)
      .then(function (response: any) {
        console.log(JSON.stringify(response.data));
        alert("Produto Cadastrado com sucesso!!")
        alert(barCode.value)
        alert(option?.value)
        instance.registerStock(quantidade?.value,preco?.value,option?.value,barCode?.value);
      })
      .catch(function (error: any) {
        console.log(error);
      });
            
  }

  registerStock(quantidade : string,preco : string, option : string,barCode : string){
    
    var data2 = JSON.stringify({
      "quantity": quantidade,
      "unit_Price": preco,
      "store": {
        "cnpj": option
      },
      "product": {
        "bar_code": barCode
      }
    })


    var config2 = {
      method: 'post',
      url: 'http://localhost:5009/stock/add',
      headers: {
        "Access-Control-Allow-Origin": "*",
        "Access-Control-Allow-Headers": "Content-Type",
        'Authorization': 'Bearer ' + localStorage.getItem("authToken"),
        'Content-Type': 'application/json',
      },
      data: data2
    };

    axios(config2)
      .then(function (response) {
        console.log(JSON.stringify(response.data));
      })
      .catch(function (error) {
        console.log(error);
      });

  }


  ngOnInit(): void {
    var data = JSON.stringify({

    });
    let self = this;
    var config = {
      method: 'get',
      url: 'http://localhost:5009/store/get/all',
      headers: {
        'Content-Type': 'application/json'
      },
      data: data
    };

    axios(config)
      .then(function (response: any) {
        console.log(JSON.stringify(response.data));
        self.stores = response.data;
      })
      .catch(function (error: any) {
        console.log(error);
      });

  }
}
