import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { StorageService } from './storage.service';
import { MenuItem } from '../models/menu-item.model';
import { API_BASE_URL } from '../constants/api.constants';
import { LoginRequest, LoginResponse } from '../dtos/login.dto';
import { Observable } from 'rxjs/internal/Observable';
import { ApiResponse } from '../dtos/api-response.dto';

@Injectable({ providedIn: 'root' })
export class AuthService {
  private readonly apiUrl = `${API_BASE_URL}/auth`;

  constructor(
    private http: HttpClient,
    private router: Router,
    private storage: StorageService
  ) {}

  login(request: LoginRequest): Observable<ApiResponse<LoginResponse>> {
    return this.http.post<any>(`${this.apiUrl}/login`, request);
  }

  saveSession(token: string, userName: string, role: string, roleDescripcion: string, menu: any[]): void {
    this.storage.set('token', token);
    this.storage.set('userName', userName);
    this.storage.set('role', role);
    this.storage.set('roleDescripcion', roleDescripcion);
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

  getUserName(): string | null {
    return this.storage.get('userName');
  }

  getRole(): string | null {
    return this.storage.get('role');
  }

  getRoleDescripcion(): string | null {
    return this.storage.get('roleDescripcion');
  }

  getMenu(): MenuItem[] | null {
    return this.storage.get<MenuItem[]>('menu');
  }
}
