import { Route } from "@angular/router";
import { CartPageComponent } from "./cart-page/cart-page.component";

export const cartRoutes : Route[] = [
  {
    path: 'cart',
    component: CartPageComponent
  }
];
