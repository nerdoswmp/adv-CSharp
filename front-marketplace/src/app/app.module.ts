import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TopBarComponent } from './top-bar/top-bar.component';
import { ProductsListComponent } from './products-list/products-list.component';
import { ProductDetailComponent } from './product-detail/product-detail.component';
import { ClientRegisterComponent } from './client-register/client-register.component';
import { AddressRegisterComponent } from './address-register/address-register.component';
import { StoreRegisterComponent } from './store-register/store-register.component';
import { WishlistComponent } from './wishlist/wishlist.component';
import { MarketplaceLoginComponent } from './marketplace-login/marketplace-login.component';
import { PurchaseListComponent } from './purchase-list/purchase-list.component';

@NgModule({
  declarations: [
    AppComponent,
    TopBarComponent,
    ProductsListComponent,
    ProductDetailComponent,
    ClientRegisterComponent,
    AddressRegisterComponent,
    AddressRegisterComponent,
    StoreRegisterComponent,
    WishlistComponent,
    ClientRegisterComponent,
    AddressRegisterComponent,
    MarketplaceLoginComponent,
    PurchaseListComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    RouterModule.forRoot([
      {path: '', component : ProductsListComponent},
      {path: 'product/:productID/:storeID', component:ProductDetailComponent},
      {path: 'address/register', component:AddressRegisterComponent},
      {path: 'store/register', component:StoreRegisterComponent},
      {path: 'wishlist', component:WishlistComponent},
      {path: 'product/:productID', component:ProductDetailComponent},
      {path: 'client/register', component:ClientRegisterComponent},
      {path: 'address/register', component:AddressRegisterComponent},
      {path: 'login', component:MarketplaceLoginComponent},
      {path: 'purchases', component:PurchaseListComponent}
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
