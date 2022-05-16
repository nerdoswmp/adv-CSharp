import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { TopBarComponent } from '../top-bar/top-bar.component';
import { Product, products} from '../products';

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

    const productIdFromRoute = Number(routeParams.get('productID'))

    this.product = products.find(product => product.id === productIdFromRoute);
  }

}
