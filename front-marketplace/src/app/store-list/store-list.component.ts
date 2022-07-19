import { Component, OnInit } from '@angular/core';
import { Stores } from '../stores';
import axios from 'axios';

@Component({
  selector: 'app-store-list',
  templateUrl: './store-list.component.html',
  styleUrls: ['./store-list.component.css']
})
export class StoreListComponent implements OnInit {
  title = 'front-marketplace';
  titlePage = 'Stores';

  stores : [Stores] | undefined;

  constructor() { }

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
    });

  }

}
