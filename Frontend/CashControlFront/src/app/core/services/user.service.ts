import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/internal/Observable';
import { API_BASE_URL } from '../constants/api.constants';
import { CreateUserRequest } from '../dtos/create-user.dto';
import { ApiResponse } from '../dtos/api-response.dto';
import { SystemUser } from '../models/system-user.model';
import { of } from 'rxjs';
import { SystemUserDto } from '../dtos/system-user.dto';

@Injectable({ providedIn: 'root' })
export class UserService {  
  private readonly apiUrl = `${API_BASE_URL}/user`;

  constructor(private http: HttpClient) {}

  createUser(request: CreateUserRequest): Observable<ApiResponse<null>> {
    return this.http.post<ApiResponse<null>>(`${this.apiUrl}/create`, request);
  }

  getUserById(userId: number): Observable<ApiResponse<SystemUserDto>> {
    return this.http.get<ApiResponse<SystemUserDto>>(`${this.apiUrl}/${userId}`);
  }

  getUsersByStatus(status: string): Observable<ApiResponse<SystemUserDto[]>> {
    return this.http.get<ApiResponse<SystemUserDto[]>>(`${this.apiUrl}/getAll/${status}`);
  }

  updateUser(userId: number, dto: SystemUserDto): Observable<ApiResponse<null>> {
    return this.http.put<ApiResponse<null>>(`${this.apiUrl}/${userId}`, dto);
  }
}
