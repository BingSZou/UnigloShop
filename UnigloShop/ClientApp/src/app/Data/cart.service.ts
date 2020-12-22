import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { OrderItem } from './OrderItem';
import { ProductServices } from './product.service';

@Injectable({
  providedIn: 'root'
})
export class CartService {
  itemsCount$ = new Subject<number>();
  items : OrderItem[];
  constructor(private productService: ProductServices) {
    this.items = [];
  }

  addToCart(id:number, quantity: number)
  {
    this.items.push({
      productId: id,
      quantity: quantity
    });
    this.itemsCount$.next(this.items.length);
  }

  async addProductToCart(id : number, quantity : number) {
    const product$ = this.productService.getProductById(id).subscribe( p => {

      if (!p)
      {
        console.error("Can't add product to cart, not found", id);
      }
      this.productService.reduceProduct(p, quantity);

      this.addToCart(id, quantity);
        console.log("product is added to the cart", id);

    });
  }
}
