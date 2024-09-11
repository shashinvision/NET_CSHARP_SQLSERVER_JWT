import { inject } from '@angular/core';
import { CanActivateFn } from '@angular/router';
import { LoginService } from '../_services/login.service';

export const adminGuard: CanActivateFn = (route, state) => {
  const loginService = inject(LoginService);

  if (loginService.roles().includes('admin') || loginService.roles().includes('moderator')) {
    return true;
  } else {
    return false;
  }
};
