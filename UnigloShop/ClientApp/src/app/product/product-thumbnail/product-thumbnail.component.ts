import { Component, Input, OnInit } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { ToastrService } from '../../common/toaster.service';
import { Product } from '../../Data/Product';
import { CartService } from '../../Data/cart.service';

@Component({
  selector: 'product-thumbnail',
  templateUrl: './product-thumbnail.component.html',
  styleUrls: ['./product-thumbnail.component.css']
})
export class ProductThumbnailComponent implements OnInit {
  public hasAvailableProduct;
  constructor(private toasterService : ToastrService, private cartService : CartService) { }

  @Input()
  public product : Product;

  public percentDiscount;
  ngOnInit() {
    this.percentDiscount = ((this.product.origPrice - this.product.price) / this.product.origPrice * 100).toFixed(2)
    console.log(`toal qty, ${this.product.totalQuantity}, ${this.product.totalQuantity <= 0}`);
    this.hasAvailableProduct=(this.product.totalQuantity > 0);
  }

}
