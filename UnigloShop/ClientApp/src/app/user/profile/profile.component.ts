import { Route } from '@angular/compiler/src/core';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { timeStamp } from 'console';
import { AuthService } from '../auth.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styles: [`
            label {margin-right: 2rem}
            em { color: red; margin-left:2rem }
            .error {background-color: pink}
          `]
})
export class ProfileComponent implements OnInit {
  user = { nmae: 'John Doe', imageUrl: 'doe.com/profile.jpg' }
  constructor(private authService : AuthService, private router:Router) { }

  firstName : FormControl;
  lastName: FormControl;

  profileForm : FormGroup;
  ngOnInit() {
    this.authService.login("a","b");
    if (!this.authService.currentUser)
    {
        this.router.navigate(["user/login"]);
        return;
    }
    this.firstName = new FormControl(this.authService.currentUser.firstName, Validators.required);
    this.lastName = new FormControl(this.authService.currentUser.lastName, Validators.required);

    this.profileForm = new FormGroup({
      firstName: this.firstName,
      lastName: this.lastName
    });
  }
  validateFirstName()
  {
    return this.firstName.touched && this.firstName.valid;
  }
  validateLastName()
  {
    return this.lastName.touched && this.lastName.valid;
  }
  clickImage() {
    console.log("My image is clicked. ")
  }

  saveProfile(formValues)
  {
    if(this.profileForm.valid)
    {
      console.log("saving profile.. ", formValues);
      this.authService.saveProfile(formValues.firstName, formValues.LastName);
      this.router.navigate(["products"]);
  }
}
  cancel()
  {
    this.router.navigate(["products"]);
  }
}
