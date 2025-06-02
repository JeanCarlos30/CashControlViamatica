import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatCardModule } from '@angular/material/card';
import { MatTableModule } from '@angular/material/table';
import { MatSelectModule } from '@angular/material/select';
import { MatButtonModule } from '@angular/material/button';
import { Router } from '@angular/router';
import { SystemUser } from '../core/models/system-user.model';
import { SystemUserDto } from '../core/dtos/system-user.dto';
import { UserService } from '../core/services/user.service';

@Component({
  standalone: true,
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.css'],
  imports: [CommonModule, MatCardModule, MatTableModule, MatSelectModule, MatButtonModule]
})
export class UserListComponent implements OnInit {
updateEstado(_t49: any) {
throw new Error('Method not implemented.');
}
  
  users: SystemUserDto[] = [];
  displayedColumns = ['userName', 'email', 'rol', 'estado', 'acciones'];

  constructor(
    private router: Router,
    private userService: UserService,
  ) {}

  ngOnInit(): void {
    this.userService.getUsersByStatus("APR").subscribe(u => this.users = u.data? u.data : []);
  }

  editUser(user: SystemUser) {
    this.router.navigate(['/user-edit', user.userId]);  
  }

  openUploadDialog() {
    this.router.navigate(['/users/upload']);
  }
}
