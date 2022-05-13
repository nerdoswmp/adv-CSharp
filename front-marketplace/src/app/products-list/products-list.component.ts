import { Variable } from '@angular/compiler/src/render3/r3_ast';
import { Component, OnInit } from '@angular/core';
import { products } from '../products';

@Component({
  selector: 'app-products-list',
  templateUrl: './products-list.component.html',
  styleUrls: ['./products-list.component.css']
})
export class ProductsListComponent implements OnInit {

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

