import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatCardModule } from '@angular/material/card';
import { MatListModule } from '@angular/material/list';
import { AuthService } from '../core/services/auth.service';
import { TurnService } from '../core/services/turn.service';
import { SystemUser } from '../core/models/system-user.model';
import { UserService } from '../core/services/user.service';
import { SystemUserDto } from '../core/dtos/system-user.dto';

@Component({
  standalone: true,
  selector: 'app-welcome',
  templateUrl: './welcome.component.html',
  styleUrls: ['./welcome.component.css'],
  imports: [CommonModule, MatCardModule, MatListModule]
})
export class WelcomeComponent implements OnInit {
  rolId: string = '';
  rolDescripcion: string = '';
  userName: string = '';
  totalTurnos: number = 0;
  pendientesAprobacion: SystemUserDto[] = [];

  constructor(
    private authService: AuthService,
    private userService: UserService,
    private turnService: TurnService
  ) {}

  ngOnInit(): void {
    this.rolId = this.authService.getRole() || '';
    this.rolDescripcion = this.authService.getRoleDescripcion() || '';
    this.userName = this.authService.getUserName() || '';
    if (this.rolId === "1") { // Admin
      this.turnService.getTotalTurnosHoy().subscribe(t => this.totalTurnos = t);
    } else if (this.rolId === "2") { // Gestor
      this.turnService.getTotalTurnosGestorHoy(this.authService.getUserName()!).subscribe(t => this.totalTurnos = t);
      this.userService.getUsersByStatus("PND").subscribe(u => this.pendientesAprobacion = u.data? u.data : []);
    } else { // Cajero
      this.turnService.getTotalTurnosCajeroHoy(this.authService.getUserName()!).subscribe(t => this.totalTurnos = t);
    }
  }
}
