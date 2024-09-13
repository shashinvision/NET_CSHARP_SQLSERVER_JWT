import { Routes } from '@angular/router';
import { HomeComponent } from './_views/home/home.component';
import { LoginComponent } from './_views/login/login.component';
import { authGuard } from './_guards/auth.guard';
import { AdminComponent } from './_views/admin/admin.component';
import { adminGuard } from './_guards/admin.guard';
import { LogoutComponent } from './_views/logout/logout.component';
import { ErrorComponent } from './_views/error/error.component';


export const routes: Routes = [
  {
    path: 'home',
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
