import { Router, type CanActivateFn } from '@angular/router';

import { loadUserInfo } from '@/utils';
import { inject } from '@angular/core';
import { UserProfiles } from '@/enums';

export const verifyUserProfileGuard: CanActivateFn = (route, state) => {
  const router = inject(Router);

  const userLoaded = loadUserInfo();

  if (!userLoaded || userLoaded.userProfile !== UserProfiles.ADMIN) {
    router.navigate(['/products']);
    return false;
  }

  return true;
};
