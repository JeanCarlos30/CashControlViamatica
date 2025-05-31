import { Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { authGuard } from '../app/core/guards/auth.guard';
import { LayoutComponent } from './layout/layout.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { CreateUserComponent } from './create-user/create-user.component';

export const routes: Routes = [
  // Login SIN layout
  { path: 'login', component: LoginComponent },

  // Rutas protegidas CON layout
  {
    path: '',
    component: LayoutComponent,
    canActivate: [authGuard],
    children: [
      { path: 'dashboard', component: DashboardComponent },
      { path: 'create-user', component: CreateUserComponent },
      { path: '', redirectTo: 'dashboard', pathMatch: 'full' }
    ]
  },

  // Fallback
  { path: '**', redirectTo: '' }
];

