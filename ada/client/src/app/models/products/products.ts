// Generated by https://quicktype.io

export interface IProductsResponse {
  id: string;
  name: string;
  stock: number;
  description: string;
  userProductDetails:
    | [
        {
          quantitySold: number;
        },
      ]
    | null;
  price: number;
  imageUrl: string;
}

export interface IUserShoppingDetail {
  unitPrice: number;
  quantitySold: number;
  total: number;
  product: Product;
  user: User;
}

export interface Product {
  name: string;
}

export interface User {
  fullName: string;
  identificationNumber: string;
}
