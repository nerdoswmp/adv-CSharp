import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
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

  constructor(private route: ActivatedRoute) { }

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
