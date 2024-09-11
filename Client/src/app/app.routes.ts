import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { authGuard } from './_guards/auth.guard';
import { AdminComponent } from './admin/admin.component';
import { adminGuard } from './_guards/admin.guard';
import { LogoutComponent } from './logout/logout.component';
import { ErrorComponent } from './error/error.component';


export const routes: Routes = [
  {
    path: '',
    canActivate: [authGuard],
    component: HomeComponent
  },
  {
    path: 'login',
    component: LoginComponent
  },
  {
    path: 'logout',
    canActivate: [authGuard],
    component: LogoutComponent
  },
  {
    path: 'admin',
    canActivate: [adminGuard],
    component: AdminComponent
  },
  {
    path: 'error',
    component: ErrorComponent
  },
];
