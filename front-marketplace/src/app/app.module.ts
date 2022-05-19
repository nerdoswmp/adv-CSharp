import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TopBarComponent } from './top-bar/top-bar.component';
import { ProductsListComponent } from './products-list/products-list.component';
import { ProductDetailComponent } from './product-detail/product-detail.component';
import { AddressRegisterComponent } from './address-register/address-register.component';
import { StoreRegisterComponent } from './store-register/store-register.component';
import { WishlistComponent } from './wishlist/wishlist.component';

@NgModule({
  declarations: [
    AppComponent,
    TopBarComponent,
    ProductsListComponent,
    ProductDetailComponent,
    AddressRegisterComponent,
    StoreRegisterComponent,
    WishlistComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    RouterModule.forRoot([
      {path: '', component : ProductsListComponent},
      {path: 'product/:productID/:storeID', component:ProductDetailComponent},
      {path: 'address/register', component:AddressRegisterComponent},
      {path: 'store/register', component:StoreRegisterComponent},
      {path: 'wishlist', component:WishlistComponent}
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
