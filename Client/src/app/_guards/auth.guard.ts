import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { LoginService } from '../_services/login.service';

export const authGuard: CanActivateFn = (route, state) => {
  const loginService = inject(LoginService);
  const router = inject(Router);

  if (loginService.currentUser()) {
    return true;
  } else {
    console.error('You shall not pass!');

    router.navigate(['/login']);
    return false;
  }
};
