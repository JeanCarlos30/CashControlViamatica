import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { SystemUser } from '../models/system-user.model';

@Injectable({ providedIn: 'root' })
export class SystemUserService {
  private apiUrl = 'http://localhost:5012/api/user/create';

  constructor(private http: HttpClient) {}

  createUser(user: SystemUser){
    return this.http.post<any>(this.apiUrl, user);
  }
}
