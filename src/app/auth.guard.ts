import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { ServiceService } from './service.service';

@Injectable({
  providedIn: 'root',

})

export class AuthGuard implements CanActivate {

  constructor(private service: ServiceService, private router: Router) {}

  canActivate(): boolean {
    
    if (localStorage.getItem("token")!=null) {
      return true; // User is authenticated, allow access to the route
    }
    
    this.router.navigate([''])
    return false; // User is not authenticated, redirect to login page
  }

}