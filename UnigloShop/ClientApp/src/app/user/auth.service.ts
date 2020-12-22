import { ThrowStmt } from '@angular/compiler';
import { Route } from '@angular/compiler/src/core';
import { Injectable, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { user } from './data/user';

@Injectable({
  providedIn: 'root'
})
export class AuthService implements OnInit {
  currentUser : user;
  constructor(private router : Router) { }

  ngOnInit() {
    console.log("is logged in", this.isAuthenticated);
  }

  login(userName: string, password: string)
  {
    this.currentUser = {
      firstName: "John",
      lastName: "JohnLast",
      userName: 'johnl',
      password: 'johnlast'
    } as any;
  }

  isAuthenticated() :boolean
  {
    console.log('checking autenticated: ', this.currentUser);
    return !!this.currentUser;
  }

  saveProfile(firstname: string, lastname: string)
  {
    this.currentUser.firstName = firstname;
    this.currentUser.lastName = lastname;
    this.router.navigate(["prodducts"]);
  }

}
