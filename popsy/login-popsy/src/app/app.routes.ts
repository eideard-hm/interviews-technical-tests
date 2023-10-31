import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: 'auth/login',
    loadComponent: () =>
      import('./auth/pages/login/login.component').then(
        (c) => c.LoginComponent
      ),
    title: 'Iniciar sesión en Popsy',
  },
  {
    path: '**',
    redirectTo: 'auth/login',
  },
];
