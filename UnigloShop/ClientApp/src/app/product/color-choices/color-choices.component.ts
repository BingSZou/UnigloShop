import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'color-choices',
  templateUrl: './color-choices.component.html',
  styleUrls: ['./color-choices.component.css']
})
export class ColorChoicesComponent implements OnInit {
  public availableColors;
  public selectedIdx;
  public selectedColor;
  public colors;
  constructor() { }

  ngOnInit() {
    this.availableColors = [
      { name: 'white', encode: '#ffffff' },
      { name: 'yellow', encode: 'yellow' },
      { name: 'blue', encode: 'blue' },
      { name: 'green', encode: 'green' },
      { name: 'orange', encode: 'orange' }
    ];

    this.selectedIdx = 0;
    this.selectedColor = this.availableColors[0];
  }
  changeSelection(c) {
    this.selectedColor = c;
  }
  backgroundColor(c) {
    alert(c.encode)
    return c.encode;
  }
}
