import { HttpInterceptorFn } from '@angular/common/http';
import { inject } from '@angular/core';
import { LoginService } from '../_services/login.service';


export const jwtInterceptor: HttpInterceptorFn = (req, next) => {
  const loginService = inject(LoginService);

  if (loginService.currentUser()) {
    req = req.clone({
      setHeaders: {
        Authorization: `Bearer ${loginService.currentUser()?.user_jwt}`
      }
    })
  }

  return next(req);
};
