import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ServiceService {

  constructor(private http:HttpClient) { }

  // Authenticate(data:any)
  // {
  //   this.http.post('http://localhost:5200/api/Authentication/AuthenticateUser',data).subscribe((res:any)=>
  //   {
  //     console.log(res.token);
  //     localStorage.setItem('token',res.token)
  //   })
  // }
  login(data:any)
  {
    return this.http.post('http://localhost:5200/api/Authentication/AuthenticateUser', data);
  }

  GetUser()
  {
    return this.http.get('http://localhost:5200/api/User/GetUsers')
  }

  GetEmployee()
  {
    return this.http.get('http://localhost:5200/api/Employee/GetAllEmployeeDetails');
  }

}
