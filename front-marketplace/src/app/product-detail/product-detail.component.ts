import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Route, Router } from '@angular/router';
import { TopBarComponent } from '../top-bar/top-bar.component';
import { Product, products} from '../products';
import  axios from 'axios';

@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.css']
})
export class ProductDetailComponent implements OnInit {
  titlePage="Product Detail";
  title = 'front-marketplace';
  product: Product | undefined

  constructor(private route: ActivatedRoute, private router: Router) { }
  makePurchase(): void{
    var instance = this;
    var token = localStorage.getItem('authToken')
    const routeParams = this.route.snapshot.paramMap;
    const productIdFromRoute = Number(routeParams.get('productID'));
    const storeIdFromRoute = Number(routeParams.get('storeID'));
    
    var config = {
      method: 'post',
      url: 'http://localhost:5009/purchase/buy/' + storeIdFromRoute + '/' + productIdFromRoute + '/'  + localStorage.getItem('user'),
      headers: { 
        'Authorization': 'Bearer ' + token
      }
    };
    
    axios(config)
    .then(function (response) {
      console.log(JSON.stringify(response.data));
    })
    .catch(function (error) {
      console.log(error)
      if (error.response.status == 401){
        instance.router.navigate(['/login']) 
      }
    });
    
  }

  ngOnInit(): void {
    const routeParams = this.route.snapshot.paramMap;
    const productIdFromRoute = Number(routeParams.get('productID'));
    const storeIdFromRoute = Number(routeParams.get('storeID'));
    var instance = this;

    var config = {
      method: 'get',
      url: 'http://localhost:5009/product/' + String(productIdFromRoute) + '/' + String(storeIdFromRoute),
      headers: { }
    };

    axios(config)
    .then(function (response) {
      console.log(JSON.stringify(response.data));
      instance.product = response.data;
    })
    .catch(function (error) {
      console.log(error);
    });
    

    

    

  }

}
