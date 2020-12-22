import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable, of } from 'rxjs';
import { ToastrService } from 'src/app/common/toaster.service';
import { CartService } from 'src/app/Data/cart.service';
import { Product } from 'src/app/Data/Product';
import { ProductServices } from 'src/app/Data/product.service';

@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.css']
})
export class ProductDetailComponent implements OnInit {
  $product: Observable<Product>;
  product: Product;
  quantity: number;
  public hasAvailableProduct;

  constructor(private productService: ProductServices, private cartService : CartService,  private route: ActivatedRoute, private toasterService :ToastrService) { }

  ngOnInit() {

    this.route.params.subscribe(params => {
      const id = +params['id'];
      this.$product = this.productService.getProductById(id);
      this.$product.subscribe(p =>
        this.product = p
        );
      this.quantity = 1;
      this.hasAvailableProduct=(this.product.totalQuantity > 0);
    });

  }

  addToCart() {
    this.toasterService.success("testing");
    this.cartService.addProductToCart(this.product.id, 1).then(_ => {
      this.toasterService.success(`${this.product.title} added to the cart. remaining ${this.product.totalQuantity}`);
      this.hasAvailableProduct=(this.product.totalQuantity > 0);
    });

  }
}
