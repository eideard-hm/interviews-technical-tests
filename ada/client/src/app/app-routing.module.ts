import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { verifyUserProfileGuard } from './guards';

const routes: Routes = [
  {
    path: 'auth/login',
    loadComponent: () =>
      import('./pages/auth/login/login.component').then(c => c.LoginComponent),
    title: 'Login de Usuario',
  },
  {
    path: 'products',
    loadComponent: () =>
      import('./pages/products/list/list.component').then(c => c.ListComponent),
    title: 'Listado completo de Productos',
  },
  {
    path: 'shopping/:userId',
    loadComponent: () =>
      import('./pages/products/shopping/shopping.component').then(
        c => c.ShoppingComponent
      ),
    title: 'Productos Comprados',
  },
  {
    path: 'users-shopping-detail',
    loadComponent: () =>
      import('./pages/products/users-shopping/users-shopping.component').then(
        c => c.UsersShoppingComponent
      ),
    title: 'Listado de Compras de Usuarios',
    canMatch: [verifyUserProfileGuard],
  },
  {
    path: '**',
    redirectTo: 'auth/login',
    pathMatch: 'full',
  },
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes, {
      initialNavigation: 'enabledBlocking',
      bindToComponentInputs: true,
    }),
  ],
  exports: [RouterModule],
})
export class AppRoutingModule {}
