import { inject } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivateFn, Router } from '@angular/router';
import { AuthService } from '../services/auth.service';
import { MenuItem } from '../models/menu-item.model';

const allowedInternalRoutes = ['user-edit', 'user-upload'];

export const authGuard: CanActivateFn = (route: ActivatedRouteSnapshot) => {
  const auth = inject(AuthService);
  const router = inject(Router);

  if (!auth.isAuthenticated()) {
    router.navigate(['/login']);
    return false;
  }

  // Verificar acceso por menú cargado desde la BD
  const menu = auth.getMenu();
  const url = route.routeConfig?.path;
  if (menu && url && !menu.some((item: MenuItem) => item.route === url) &&
    !allowedInternalRoutes.includes(url)) {    
    router.navigate(['/welcome']);
    return false;
  }

  return true;
};
