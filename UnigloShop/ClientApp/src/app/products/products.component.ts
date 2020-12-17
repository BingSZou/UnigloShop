import { Component, OnInit } from '@angular/core';
import { Router, Routes } from '@angular/router';
import { ProductServices } from '../Data/product.service';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit {
  public productsList

  constructor(private productServices: ProductServices, private router: Router) {

  }
  
  ngOnInit() {
    this.productsList = this.productServices.getAllProducts();
}

}
