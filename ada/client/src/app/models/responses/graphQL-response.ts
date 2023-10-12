import type { GraphQLError } from 'graphql';

export interface IGraphQLResponse<T> {
  errors?: GraphQLError[];
  data?: IData<T>;
}

export interface IData<T> {
  [key: string]: T;
}
