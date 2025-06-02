import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { API_BASE_URL } from '../constants/api.constants';
import { HttpClient } from '@angular/common/http';
import { ApiResponse } from '../dtos/api-response.dto';
import { CreateTurnRequest } from '../dtos/create-turn.dto';

@Injectable({ providedIn: 'root' })
export class TurnService {

  private readonly apiUrl = `${API_BASE_URL}/turn`;

  constructor(private http: HttpClient) {}

  // Mock: total de turnos para admin
  getTotalTurnosHoy(): Observable<number> {
    return of(42); // Número mock
  }

  // Mock: total de turnos asignados por el gestor
  getTotalTurnosGestorHoy(userName: string): Observable<number> {
    return of(15); // Número mock
  }

  // Mock: total de turnos atendidos por el cajero
  getTotalTurnosCajeroHoy(userName: string): Observable<number> {
    return of(7); // Número mock
  }

  createTurn(request: CreateTurnRequest): Observable<ApiResponse<null>> {
    return this.http.post<ApiResponse<null>>(`${this.apiUrl}/create`, request);
  }
}