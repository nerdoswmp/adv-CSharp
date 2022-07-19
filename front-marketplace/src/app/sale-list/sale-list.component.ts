import { Component, OnInit } from '@angular/core';
import { Purchases } from '../purchases';
import { ActivatedRoute, Router } from '@angular/router';
import axios from 'axios';

@Component({
  selector: 'app-sale-list',
  templateUrl: './sale-list.component.html',
  styleUrls: ['./sale-list.component.css']
})
export class SaleListComponent implements OnInit {
  title = 'front-marketplace';
  titlePage = 'Stores';

  purchases : [Purchases] | undefined;
  constructor(private route: ActivatedRoute, private router: Router) { }

  ngOnInit(): void {
    const routeParams = this.route.snapshot.paramMap;
    const storeIdFromRoute = Number(routeParams.get('storeID'));
    var instance = this;
    var token = localStorage.getItem('authToken')

    var config = {
      method: 'get',
      url: 'http://localhost:5009/purchase/store/'+ storeIdFromRoute,
      headers: { 
        'Content-Type': 'application/json',
        'Authorization': 'Bearer ' + token
      },
    };

    
    
    axios(config)
    .then(function (response) {
      console.log(JSON.stringify(response.data));
      instance.purchases = response.data;
    })
    .catch(function (error) {
      console.log(error);
      if (error.response.status == 401){
        instance.router.navigate(['/login']) 
      }
    });
  }
}
