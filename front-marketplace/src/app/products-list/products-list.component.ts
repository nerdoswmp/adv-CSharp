import { Variable } from '@angular/compiler/src/render3/r3_ast';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Product } from '../products';
import { WishList} from '../wishlist';
import axios from 'axios';
import { NumberValueAccessor } from '@angular/forms';

@Component({
  selector: 'app-products-list',
  templateUrl: './products-list.component.html',
  styleUrls: ['./products-list.component.css']
})
export class ProductsListComponent implements OnInit {
  titlePage="Products";
  title = 'front-marketplace';
  
  isOwner = localStorage.getItem('isOwner');
  Wishlists : [WishList] | undefined;
  products : [Product] | undefined;
  coracao : Boolean | null;
  srcCoracaoCheio : string;
  srcCoracaoVazio : string;
  source : string;
  arrAdds : Array<Number>;
  
  constructor() {
    this.source = "";
    this.arrAdds = [];
    this.srcCoracaoCheio = "../assets/coraçãoCheio.png";
    this.srcCoracaoVazio = "../assets/coraçãoVazio.png";
    this.coracao = false;
   }

  ngOnInit(): void {
    var config = {
      method: 'get',
      url: 'http://localhost:5009/product/all/',
      headers: { 
        "Access-Control-Allow-Origin":"*",
        "Access-Control-Allow-Headers":"Content-Type",
        'Authorization':'Bearer'+localStorage.getItem("authToken"),
        'Content-Type' : 'application/json',
      }
    };

    var instance = this;
    
    axios(config)
    .then(function (response) {
      console.log(JSON.stringify(response.data));
      instance.products = response.data;
      console.log(instance.products)
    })
    .catch(function (error:any) {
      console.log(error);
    });

    var config2 = {
      method: 'get',
      url: 'http://localhost:5009/wishlist/get',
      headers: { 
        "Access-Control-Allow-Origin":"*",
        "Access-Control-Allow-Headers":"Content-Type",
        'Authorization':'Bearer '+localStorage.getItem("authToken"),
        'Content-Type' : 'application/json',
      }
    };

    var instance2 = this;
    
    axios(config2)
    .then(function (response) {
      console.log(JSON.stringify(response.data));
      instance2.Wishlists = response.data;
      if(instance2.Wishlists != undefined){
        for(let wishlist of instance2.Wishlists){
          instance2.arrAdds.push(wishlist.id);
        }
      }
      console.log(instance2.arrAdds);
    })
    .catch(function (error:any) {
      console.log(error);
    });    
  }
  
  setarIMG(id : Number) {
    if(this.arrAdds.includes(id)){

      return this.srcCoracaoCheio;
    }else{

      return this.srcCoracaoVazio
    }
    return this.srcCoracaoVazio;
  }

  mudarCoracao(idTag : String, id : Number){
    console.log(id)
    var img = document.querySelector('#'+idTag);
    
    if(img?.getAttribute("src") == this.srcCoracaoCheio){
      img?.setAttribute('src', this.srcCoracaoVazio);  
      this.RemoveWishList(id);
      console.log(this.coracao);      
    }
    else{
      img?.setAttribute('src', this.srcCoracaoCheio);
      this.addWishList(id);
      console.log(this.coracao);
    }
  }


  addWishList(IdStocks : Number){
    this.coracao = true;
    this.arrAdds.push(IdStocks);

    var data = JSON.stringify({
      id : IdStocks,
    })

    var config = {
      method:'post',
      url:'http://localhost:5009/wishList/register',
      headers:{
        "Access-Control-Allow-Headers": "Content-Type",
        'Authorization':'Bearer '+ localStorage.getItem("authToken"),
         'Content-Type': 'application/json',
       },
       data:data,
    }

    axios(config)
    .then(function (response) {
      console.log(JSON.stringify(response.data));
      alert("O produto foi add a lista de desejos!");
    })
    .catch(function (error) {
      
      alert("Erro ao adicionar na lista de desejos!");
      console.log(error);
    });
  }

  RemoveWishList(WishListId:Number){
    this.coracao=false;
    var pos = this.arrAdds.indexOf(WishListId);

    while(pos >= 0){
      this.arrAdds.splice(pos,1);

      pos = this.arrAdds.indexOf(WishListId);
      console.log(this.arrAdds);
    };

    var config = {
      method: 'delete',
      url: 'http://localhost:5009/wishlist/delete/' + WishListId,
      headers: {
        'Authorization': 'Bearer ' +  localStorage.getItem("authToken"),
      }
    };
    let instance = this;
  axios(config)
  .then(function (response: any) {
    console.log(JSON.stringify(response.data));
    alert("Removido da WishList!");
    window.location.reload();
  })
  .catch(function (error : any) {
    console.log(error);
  });
  }
}