import { HttpInterceptorFn, HttpRequest, HttpHandler } from '@angular/common/http';
import { LoginService } from '../_services/login.service';
import { inject } from '@angular/core';
import { Router } from '@angular/router';

export const jwtExpirationInterceptor: HttpInterceptorFn = (req, next) => {
  const loginService = inject(LoginService);
  const router = inject(Router);

  if (loginService.currentUser() && loginService.jwtExpirationTime()) {
    // Only refresh if not already refreshing
    if (!loginService.isRefreshing) {
      handleExpiredToken(loginService, router);
    }
  }

  return next(req);
};

function handleExpiredToken(loginService: LoginService, router: Router) {
  loginService.refreshToken();

  // Check if the user is still authenticated after trying to refresh
  setTimeout(() => {
    if (loginService.currentUser() == null) {
      router.navigate(['/login']);
    }
  }, 1000); // Delay to allow refresh to complete
}

