import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

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
