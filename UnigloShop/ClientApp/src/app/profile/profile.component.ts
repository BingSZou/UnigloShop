import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {
  user = { nmae: 'John Doe', imageUrl: 'doe.com/profile.jpg' }
  constructor() { }

  ngOnInit() {
  }

  clickImage() {
    console.log("My image is clicked. ")
  }

}
