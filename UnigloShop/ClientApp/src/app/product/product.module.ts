import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { productRoutes } from './product.route';
import { ProductsComponent } from './products/products.component';
import { ProductThumbnailComponent } from './product-thumbnail/product-thumbnail.component';
import { ProductDetailComponent } from './product-detail/product-detail.component';
import { ColorChoicesComponent } from './color-choices/color-choices.component';
import { SizeChoicesComponent } from './size-choices/size-choices.component';

@NgModule({
  declarations: [
    ProductsComponent,
    ProductThumbnailComponent,
    ProductDetailComponent,
    ColorChoicesComponent,
    SizeChoicesComponent],
  imports: [
    CommonModule,
    RouterModule.forChild(productRoutes)
  ]
})
export class ProductModule { }
