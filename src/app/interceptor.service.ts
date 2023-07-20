import { Injectable,Injector } from '@angular/core';
import {
  HttpInterceptor,
  HttpRequest,
  HttpResponse,
  HttpErrorResponse,
  HttpHandler,
  HttpEvent
} from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class InterceptorService implements HttpInterceptor {

  constructor(private inject:Injector){}
  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

    let token=localStorage.getItem('token');

    // let authservice=this.inject.get(UserService)
    let jwtToken=req.clone({
      setHeaders:{
        Authorization:'bearer '+token
      }
    });
    return next.handle(jwtToken);
  }
}
