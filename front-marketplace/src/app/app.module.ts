
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
import { LoginownerComponent } from './loginowner/loginowner.component';
import { OwnerRegisterComponent } from './owner-register/owner-register.component';
import { StoreListComponent } from './store-list/store-list.component';
import { SaleListComponent } from './sale-list/sale-list.component';
import { ProductRegisterComponent } from './product-register/product-register.component';
import { OwnerProductsComponent } from './owner-products/owner-products.component';
import { ProductEditComponent } from './product-edit/product-edit.component';

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
    PurchaseListComponent,
    LoginownerComponent,
    OwnerRegisterComponent,
    SaleListComponent,
    ProductRegisterComponent,
    StoreListComponent,
    ProductEditComponent,
    OwnerProductsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    RouterModule.forRoot([
      {path: '', component : ProductsListComponent},
      {path: 'edit/:productID/:storeID', component:ProductEditComponent},
      {path: 'product/:productID/:storeID', component:ProductDetailComponent},
      {path: 'address/register', component:AddressRegisterComponent},
      {path: 'store/register', component:StoreRegisterComponent},
      {path: 'wishlist', component:WishlistComponent},
      {path: 'product/register', component:ProductRegisterComponent}, 
      {path: 'client/register', component:ClientRegisterComponent},
      {path: 'address/register', component:AddressRegisterComponent},
      {path: 'login', component:MarketplaceLoginComponent},
      {path: 'purchases', component:PurchaseListComponent},
      {path: 'owner/register', component:OwnerRegisterComponent},
      {path: 'product/:productID', component:ProductDetailComponent},
      {path: 'store/list', component:StoreListComponent},
      {path: 'owner/products', component:OwnerProductsComponent},
      {path: 'store/sales/:storeID', component:SaleListComponent}
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }