import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { Product } from './Product';

@Injectable({
  providedIn: 'root'
})
export class ProductServices {
  private shoppingcart = [];
  private productsList : Product[] = [
    {
      id: 1,
      title: "First product",
      price: 19.99,
      origPrice: 29.99,
      imageUrl: '/assets/images/flannelShirt.webp'

    },
    {
      id: 2,
      title: "Second Product",
      price: 9.99,
      origPrice: 23.99,
      imageUrl: '/assets/images/flannelShirt2.webp'
    },
    {
      id: 3,
      title: "Third Product",
      price: 14.99,
      origPrice: 19.99,
      imageUrl: '/assets/images/flannelShirt3.webp'
    }
  ];
 
  constructor() { }
  getAllProducts(): Product[] { return this.productsList; }

  getProductById(id: number): Observable<Product> {
    //console.log("getting product by id ",  id);
    return of(this.productsList[id-1]);
  }

  addProductToCart(id: number, qty: number) {
    this.shoppingcart.push({
      productId: id,
      quantity: qty
    })
  }
}
