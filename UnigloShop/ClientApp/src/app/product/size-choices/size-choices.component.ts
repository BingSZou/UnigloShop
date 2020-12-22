import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'size-choices',
  templateUrl: './size-choices.component.html',
  styleUrls: ['./size-choices.component.css']
})
export class SizeChoicesComponent implements OnInit {
  allSizes = ['XS', 'S', 'M', 'L', 'XL'];
  availableSizes = new Set();
  constructor() { }

  ngOnInit() {
    this.availableSizes.add('S');
  }
  getIsAvailable(s: string) {
    return !this.availableSizes.has(s);
  }
}
