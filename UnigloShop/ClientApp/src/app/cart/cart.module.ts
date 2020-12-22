import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { RouterModule } from "@angular/router";
import { CartBagComponent } from "./cart-bag/cart-bag.component";
import { CartPageComponent } from "./cart-page/cart-page.component";
import {cartRoutes } from "./cart.routes";

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(cartRoutes),
  ],
  declarations:[
    CartBagComponent,
    CartPageComponent
  ],
  exports: [
    CartBagComponent,
  ]
})
export class CartModule {

}
