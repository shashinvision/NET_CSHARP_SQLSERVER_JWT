import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { authGuard } from './_guards/auth.guard';
import { AdminComponent } from './admin/admin.component';
import { adminGuard } from './_guards/admin.guard';

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
    path: 'admin',
    canActivate: [adminGuard],
    component: AdminComponent
  },
];
