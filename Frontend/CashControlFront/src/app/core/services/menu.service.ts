import { Injectable } from '@angular/core';
import { MenuItem } from '../models/menu-item.model';
import { Observable, BehaviorSubject, of } from 'rxjs';
import { AuthService } from './auth.service';

@Injectable({ providedIn: 'root' })
export class MenuService {
  private menuItems$ = new BehaviorSubject<MenuItem[]>([]);

  constructor(private authService: AuthService) {  }

  loadMenu(): void {
    const menu = this.authService.getMenu();
    this.menuItems$.next(menu!);
  }

  getMenu(): Observable<MenuItem[]> {
    return this.menuItems$.asObservable();
  }

  clearMenu() {
    this.menuItems$.next([]);
  }

  setMenu(menu: MenuItem[]): void {
    this.menuItems$.next(menu);
  }
}
