import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ServiceService } from '../service.service';
import { Router } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  constructor(private fb:FormBuilder , private Service:ServiceService , private route:Router, private snackbar:MatSnackBar){}
  data:any
  LoginForm=new FormGroup({
    // employeeId: new FormControl(''),
    // displayName: new FormControl('',[Validators.required]),
    userEmail: new FormControl('',[Validators.required]),
    userPassword: new FormControl('',[Validators.required,Validators.minLength(8), Validators.maxLength(12)]),
    });
 
ngOnInit()
{
  localStorage.removeItem('token')
}
  Login(data:any)
  {
    if(this.LoginForm.valid)
    {
      this.Service.login(data).subscribe((res:any)=>{
        localStorage.setItem('displayname',res.name)
        this.data=res.token;
        if(this.data!=null)
        {
          localStorage.setItem('token',this.data)
          this.route.navigate(['dash'])
          this.snackbar.open('Login Successful', 'Verfied', {
          duration:2000
          });
         

        }
        else{
          this.snackbar.open('Login Failed', 'Please Enter Valid Credentials', {
            duration: 10000
          });
         
          this.route.navigate([''])
        }
      }) 
    }
    else{

      alert("lOGIN FAILED");
      
    }
     
  }
}
