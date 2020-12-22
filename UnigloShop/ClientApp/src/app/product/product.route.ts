import { Route } from "@angular/router";
import { ProductDetailComponent } from "./product-detail/product-detail.component";
import { ProductsComponent } from "./products/products.component";

export const productRoutes: Route[] = [
  {
    path: 'products',
    canActivate: [],
    component: ProductsComponent
  },
  {
    path: 'products/:id',
    canActivate: [],
    component: ProductDetailComponent
  },
  {
    path: '',
    redirectTo: '/products',
    pathMatch: 'full'
  },
];
