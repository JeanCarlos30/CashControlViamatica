import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { StorageService } from './storage.service';
import { MenuItem } from '../models/menu-item.model';

@Injectable({ providedIn: 'root' })
export class AuthService {
  private apiUrl = 'http://localhost:5012/api/auth/login'; // cambia por tu endpoint real

  constructor(
    private http: HttpClient,
    private router: Router,
    private storage: StorageService
  ) {}

  login(username: string, password: string) {
    return this.http.post<any>(this.apiUrl, { username, password });
  }

  saveSession(token: string, role: string, menu: any[]): void {
    this.storage.set('token', token);
    this.storage.set('role', role);
    this.storage.set('menu', menu);
  }

  logout(): void {
    this.storage.clear();
    this.router.navigate(['/login']);
  }

  isAuthenticated(): boolean {
    return !!this.storage.get('token');
  }

  getToken(): string | null {
    return this.storage.get('token');
  }

  getRole(): string | null {
    return this.storage.get('role');
  }

  getMenu(): MenuItem[] | null {
    return this.storage.get<MenuItem[]>('menu');
  }
}
