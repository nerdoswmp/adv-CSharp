import { Product } from "./products";

export interface Purchases {
    id: number;
    nf: string;
    date: Date;
    price: number;
    clientid: number;
    storeid: number;
    store: string;
    name: string;
    description: string;
    image: string;
    productid: number;

  }
  
  export const purchases = [
    {
      id: 1,
      price: 799,
      store: 'Mugstore',
      storeid: 0,
      nf: 12345678,
      date: new Date('2020-09-12'),
      productid: 1,
      name: 'Phone XL',
      description: 'A large phone with one of the best screens',
      image:'../assets/cssmug.jpg',
    },
    {
      id: 2,
      price: 699,
      store: 'Mugstore',
      storeid: 0,
      nf: 12365678,
      date: new Date('2020-09-12'),
      productid: 2,
      name: 'Phone XXL',
      description: 'A larger phone with one of the best screens',
      image:'../assets/cssmug.jpg',
      
    },
    {
      id: 3,
      price: 999,
      store: 'Mugstore',
      storeid: 0,
      nf: 12335678,
      date: new Date('2020-09-12'),
      productid: 3,
      name: 'Phoner XL',
      description: 'A large phone with one of the best screens',
      image:'../assets/cssmug.jpg',
      
    },
  ];
  
  
  /*
  Copyright Google LLC. All Rights Reserved.
  Use of this source code is governed by an MIT-style license that
  can be found in the LICENSE file at https://angular.io/license
  */