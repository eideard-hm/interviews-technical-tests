import { UserProfiles } from '@/enums';

export interface ILogin {
  identificationNumber: string;
  password: string;
}

export interface ILoginResponse {
  id: string;
  fullName: string;
  identificationNumber: string;
  userProfile: UserProfiles;
}
