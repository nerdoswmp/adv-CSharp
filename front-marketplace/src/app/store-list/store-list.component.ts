import { Component, OnInit } from '@angular/core';
import { Stores } from '../stores';
import axios from 'axios';
import {Router} from '@angular/router'

@Component({
  selector: 'app-store-list',
  templateUrl: './store-list.component.html',
  styleUrls: ['./store-list.component.css']
})
export class StoreListComponent implements OnInit {
  title = 'front-marketplace';
  titlePage = 'Stores';

  stores : [Stores] | undefined;

  constructor(private route: Router) { }

  ngOnInit(): void {
    var data = '';

    var config = {
      method: 'get',
      url: 'http://localhost:5009/store/all/' + localStorage.getItem("user"),
      headers: { 
        'Authorization': 'Bearer ' + localStorage.getItem("authToken"),
      },
      data : data
    };

    var instance = this;

    axios(config)
    .then(function (response:any) {
      console.log(JSON.stringify(response.data));
      instance.stores = response.data;
    })
    .catch(function (error:any) {
      console.log(error);
      if (error.response.status == 401 || 500){
        instance.route.navigate(['/login']) 
      }
    });

  }

}
