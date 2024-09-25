import { HttpInterceptorFn, HttpRequest, HttpHandler } from '@angular/common/http';
import { LoginService } from '../_services/login.service';
import { inject } from '@angular/core';
import { Router } from '@angular/router';

export const jwtExpirationInterceptor: HttpInterceptorFn = (req, next) => {

  const loginService = inject(LoginService);
  const router = inject(Router);  // Injecting the router to navigate if needed

  if (loginService.currentUser() && loginService.jwtExpirationTime()) {
    handleExpiredToken(loginService, router);
    window.location.reload();
  }
  return next(req);

};

function handleExpiredToken(loginService: LoginService, router: Router): void {
  // Try to refresh the token or redirect to the login page
  loginService.refreshToken();
  // if the refresh token is expired too, then redirect to login page
  if (loginService.currentUser() == null) {
    router.navigate(['/login']);
  }
}
