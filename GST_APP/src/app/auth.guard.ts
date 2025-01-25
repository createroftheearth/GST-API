import { inject } from '@angular/core';
import { CanActivateFn, Router, UrlSegment } from '@angular/router';
import { LOCAL_STORAGE_KEYS } from './constants';

export const authGuard: CanActivateFn = (route, state: any) => {
  const router = inject(Router);

  const gstTokenData = localStorage.getItem(LOCAL_STORAGE_KEYS.GST_AUTH_DATA);
  const token = localStorage.getItem(LOCAL_STORAGE_KEYS.INTERNAL_AUTH_TOKEN);
  if (token && gstTokenData) {
    return true;
  }
  // Redirect to login if not authenticated
  router.navigate(['/login'], {
    queryParams: { returnUrl: state?.length && state[0].path },
  });
  return false;
};
