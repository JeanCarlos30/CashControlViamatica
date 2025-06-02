import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatButtonModule } from '@angular/material/button';
import { MatSnackBar, MatSnackBarModule } from '@angular/material/snack-bar';
import { UserService } from '../core/services/user.service';
import { Router } from '@angular/router';
import { CreateUserRequest } from '../core/dtos/create-user.dto';
import { ApiResponse } from '../core/dtos/api-response.dto';

@Component({
  standalone: true,
  selector: 'app-create-user',
  templateUrl: './create-user.component.html',
  styleUrls: ['./create-user.component.css'],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatCardModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    MatButtonModule,
    MatSnackBarModule
  ]
})
export class CreateUserComponent implements OnInit {
  userForm: FormGroup;
  roles = [
    { id: 1, name: 'Administrador' },
    { id: 2, name: 'Gestor' },
    { id: 3, name: 'Cajero' }
  ];

  constructor(
    private fb: FormBuilder,
    private userService: UserService,
    private snackBar: MatSnackBar
  ) {
    this.userForm = this.fb.group({
      userName: [
        '',
        [
          Validators.required,
          Validators.minLength(8),
          Validators.pattern(/^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$/)
        ]
      ],
      email: ['', [Validators.required, Validators.email]],
      password: [
        '',
        [
          Validators.required,
          Validators.minLength(8),
          Validators.pattern(/^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$/)
        ]
      ],
      rolId: [null, Validators.required]
    });
  }

  ngOnInit(): void {}

  get f() {
    return this.userForm.controls;
  }

  onSubmit() {
    if (this.userForm.invalid) return;

    const newUser: CreateUserRequest = this.userForm.value;

    this.userService.createUser(newUser).subscribe({
      next: (res: ApiResponse<null>) => {
        this.snackBar.open(res.message || 'Usuario creado', 'Cerrar', { duration: 3000 });
        if (res.success) {
          this.userForm.reset();
          this.userForm.markAsPristine();
          this.userForm.markAsUntouched();
        }        
      },
      error: (error) => {
        if (error.error?.message) {
          this.snackBar.open(error.error.message || 'Error al crear usuario', 'Cerrar', { duration: 3000 });
        } else {
          this.snackBar.open('Error al crear usuario', 'Cerrar', { duration: 3000 });
        }
      }
    });
  }
}
