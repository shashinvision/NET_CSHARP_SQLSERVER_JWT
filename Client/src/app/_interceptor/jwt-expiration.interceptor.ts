import { HttpInterceptorFn, HttpRequest, HttpHandler } from '@angular/common/http';
import { LoginService } from '../_services/login.service';
import { inject } from '@angular/core';
import { Router } from '@angular/router';

export const jwtExpirationInterceptor: HttpInterceptorFn = (req, next) => {

  const loginService = inject(LoginService);
  const router = inject(Router);  // Injecting the router to navigate if needed

  // Get the current user's JWT token
  const token = loginService.currentUser()?.user_jwt;

  if (token) {
    const decodedToken = decodeToken(token);

    if (decodedToken && decodedToken.exp < Date.now() / 1000) {
      // Token is expired, handle it
      handleExpiredToken(loginService, router);
      return next(req);  // Continue the request after handling the token expiration
    }
  }

  // Pass the request to the next handler if no token issues
  return next(req);
};

function decodeToken(token: string) {
  try {
    const decodedToken = JSON.parse(atob(token.split('.')[1]));
    return decodedToken;
  } catch (error) {
    console.error('Failed to parse JWT:', error);
    return null;
  }
}

function handleExpiredToken(loginService: LoginService, router: Router) {
  // Try to refresh the token or redirect to the login page
  loginService.refreshToken();
  if (loginService.currentUser() == null) {
    router.navigate(['/login']);
  }
}
