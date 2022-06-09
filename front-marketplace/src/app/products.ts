export interface Product {
    id: number;
    name: string;
    price: number;
    description: string;
    image: string;
    storeid: number;
    store: string;
  }
  
  export const products = [
    {
      id: 1,
      name: 'Phone XL',
      price: 799,
      description: 'A large phone with one of the best screens',
      image:'../assets/cssmug.jpg',
      store: 'Mugstore',
      storeid: 0
    },
    {
      id: 2,
      name: 'Phone Mini',
      price: 699,
      description: 'A great phone with one of the best cameras',
      image:'../assets/cssmug.jpg',
      store: 'A little Trolling Store',
      storeid: -1
    },
    {
      id: 3,
      name: 'Phone Standard',
      price: 299,
      description: 'Just a phone',
      image:'../assets/cssmug.jpg',
      store: 'werg',
      storeid: -2
    }
  ];
  
  
  /*
  Copyright Google LLC. All Rights Reserved.
  Use of this source code is governed by an MIT-style license that
  can be found in the LICENSE file at https://angular.io/license
  */