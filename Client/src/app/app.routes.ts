import { Routes } from '@angular/router';
import { HomeComponent } from './views/home/home.component';
import { LoginComponent } from './views/login/login.component';
import { authGuard } from './_guards/auth.guard';
import { AdminComponent } from './views/admin/admin.component';
import { adminGuard } from './_guards/admin.guard';
import { LogoutComponent } from './views/logout/logout.component';
import { ErrorComponent } from './views/error/error.component';


export const routes: Routes = [
  {
    path: '',
    redirectTo: 'dashboard/home',
    pathMatch: 'full'
  },
  {
    path: 'dashboard/home',
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
