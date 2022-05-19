import { Component, OnInit } from '@angular/core';
import { products } from '../products';

@Component({
  selector: 'app-wishlist',
  templateUrl: './wishlist.component.html',
  styleUrls: ['./wishlist.component.css']
})
export class WishlistComponent implements OnInit {
  title = 'front-marketplace';
  titlePage = 'WishList';

  products = products;

  constructor() { }

  ngOnInit(): void {
  }

  mudarCoracao(idTag : String){
    console.log(idTag)        
    var img = document.querySelector('#'+idTag);           
    if(img?.getAttribute("src") == "../assets/coraçãoCheio.png"){
      img?.setAttribute('src', '../assets/coraçãoVazio.png');  
    }
    else{
      img?.setAttribute('src', '../assets/coraçãoCheio.png');
    }
}
}
