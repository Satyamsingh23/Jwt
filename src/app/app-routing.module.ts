import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashBoardComponent } from './dash-board/dash-board.component';
import { LoginComponent } from './login/login.component';
import { AuthGuard } from './auth.guard';
// import { authguardGuard } from './authguard.guard';

const routes: Routes = [
  {
    path:'',
    component:LoginComponent
  },
  {
    path:'dash',
    component:DashBoardComponent,
    canActivate:[AuthGuard]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
