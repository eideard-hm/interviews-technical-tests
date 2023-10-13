import type { ILoginResponse } from '@/models';

export const loadUserInfo = (): ILoginResponse | null => {
  const user = sessionStorage.getItem('USER_INFO');
  if (!user) return null;

  return JSON.parse(user);
};
