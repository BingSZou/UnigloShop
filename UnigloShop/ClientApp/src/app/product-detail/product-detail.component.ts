import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable, of } from 'rxjs';
import { Product } from '../Data/Product';
//import { take } from 'rxjs/operator';
import { ProductServices } from '../Data/product.service';

@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.css']
})
export class ProductDetailComponent implements OnInit {
  $product: Observable<Product>;
  quantity: number;

  constructor(private service: ProductServices, private route: ActivatedRoute) { }

  ngOnInit() {
   
    this.route.params.subscribe(params => {
      const id = +params['id'];
      this.$product = this.service.getProductById(id);
      this.quantity = 1;
      
    });
    
  }

  addToCart(id: number) {
    this.service.addProductToCart(id, this.quantity);
  }
}
