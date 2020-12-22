
import { Route } from "@angular/router";

export const appRoutes: Route[] = [
  {path: 'cart', loadChildren: './cart/cart.module#CartModule'},
  { path: 'user', loadChildren: './user/user.module#UserModule'}
];
