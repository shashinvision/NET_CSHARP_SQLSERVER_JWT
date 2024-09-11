import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { LoginService } from '../_services/login.service';

export const adminGuard: CanActivateFn = (route, state) => {
  const loginService = inject(LoginService);
  const router = inject(Router);

  if (loginService.roles().includes('admin') || loginService.roles().includes('moderator')) {
    return true;
  } else {
    router.navigate(['/error']);

    return false;
  }
};
