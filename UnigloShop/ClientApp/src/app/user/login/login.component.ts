import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Console } from 'console';
import { AuthService } from '../auth.service';

@Component({
  selector: 'login',
  templateUrl: './login.component.html',
  styles: [`
            em { color: red; float: right}
          `]
})
export class LoginComponent implements OnInit {

  userName: string;
  password: string;

  constructor(private router : Router, private authService : AuthService) { }

  ngOnInit() {
  }

  submitInfo() {
    console.log('submit ', this.userName, this.password);
  }

  login(formValues)
  {
    console.log("login submited:", formValues);
    this.authService.login(formValues.userName, formValues.password);
    this.router.navigate(['products']);
  }
}
