export interface IUserResponse {
  id: string;
  account: string;
  type: string;
  status: string;
  password?: string;
}

export interface IUserCreateInput {
  account: string;
  type: string;
  status: string;
  password: string;
}
