import { Routes } from '@angular/router';
import { authGuard } from './core/guards/auth.guard';

export const routes: Routes = [
  // Login SIN layout
  {
    path: 'login',
    loadComponent: () => import('./login/login.component').then(m => m.LoginComponent)
  },

  // Rutas protegidas CON layout
  {
    path: '',
    canActivate: [authGuard],
    loadComponent: () => import('./layout/layout.component').then(m => m.LayoutComponent),
    children: [
      {
        path: 'welcome',
        loadComponent: () => import('./welcome/welcome.component').then(m => m.WelcomeComponent)
      },
      {
        path: 'dashboard',
        loadComponent: () => import('./dashboard/dashboard.component').then(m => m.DashboardComponent)
      },
      {
        path: 'create-user',
        loadComponent: () => import('./create-user/create-user.component').then(m => m.CreateUserComponent)
      },
      {
        path: 'user-list',
        loadComponent: () => import('./user-list/user-list.component').then(m => m.UserListComponent)
      },
      {
        path: 'user-edit/:id',
        loadComponent: () => import('./user-edit/user-edit.component').then(m => m.UserEditComponent)
      },
      {
        path: 'user-upload',
        loadComponent: () => import('./user-upload/user-upload.component').then(m => m.UserUploadComponent)
      },
      {
        path: 'shift-assignment',
        loadComponent: () => import('./shift-assignment/shift-assignment.component').then(m => m.ShiftAssignmentComponent)
      },
      { path: '', redirectTo: 'welcome', pathMatch: 'full' }
    ]
  },

  // Fallback
  { path: '**', redirectTo: '' }
];

