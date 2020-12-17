import { Component, Input, OnInit } from '@angular/core';
import { ToasterService } from '../common/toaster.service';

@Component({
  selector: 'product-thumbnail',
  templateUrl: './product-thumbnail.component.html',
  styleUrls: ['./product-thumbnail.component.css']
})
export class ProductThumbnailComponent implements OnInit {

  constructor(private toasterService : ToasterService) { }

  @Input()
  public product : any;

  public percentDiscount;
  ngOnInit() {
    this.percentDiscount = ((this.product.origPrice - this.product.price) / this.product.origPrice * 100).toFixed(2)

  }

  addToCart() {
    this.toasterService.success(`{product.title} added to the cart.`);
  }
}
