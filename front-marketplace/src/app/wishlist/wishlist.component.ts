import { Component, OnInit } from '@angular/core';
import { products } from '../products';
import axios from 'axios';

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

    var token = localStorage.getItem('authToken')
    
    var config = {
      method: 'get',
      url: 'http://localhost:5009/wishList/all/'+ localStorage.getItem('user'),
      headers: { 
        'Content-Type': 'application/json',
        'Authorization': 'Bearer ' +token
      },
    };

    var instance = this;
    
    axios(config)
    .then(function (response) {
      console.log(JSON.stringify(response.data));
      instance.products = response.data;
    })
    .catch(function (error) {
      console.log(error);
    });
    
//   mudarCoracao(idTag : String){
//     console.log(idTag)        
//     var img = document.querySelector('#'+idTag);           
//     if(img?.getAttribute("src") == "../assets/coraçãoCheio.png"){
//       img?.setAttribute('src', '../assets/coraçãoVazio.png');  
//     }
//     else{
//       img?.setAttribute('src', '../assets/coraçãoCheio.png');
//     }
// }
  }
}
