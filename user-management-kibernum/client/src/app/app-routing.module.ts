import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: '',
    loadComponent: () =>
      import('./pages/user-list/user-list.component').then(
        c => c.UserListComponent
      ),
    title: 'Listado de Usuarios',
    pathMatch: 'full',
  },
  {
    path: 'form-user/:userId',
    loadComponent: () =>
      import('./pages/user-form/user-form.component').then(
        c => c.UserFormComponent
      ),
    title: 'Agregar | Actualizar Usuario',
  },
  {
    path: '**',
    redirectTo: '',
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
