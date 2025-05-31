import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatButtonModule } from '@angular/material/button';
import { MatSnackBar, MatSnackBarModule } from '@angular/material/snack-bar';
import { SystemUserService } from '../core/services/system-user.service';
import { Router } from '@angular/router';

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
    private systemUserService: SystemUserService,
    private snackBar: MatSnackBar,
    private router: Router
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

    const newUser = {
      userName: this.userForm.value['userName'],
      email: this.userForm.value['email'],
      password: this.userForm.value['password'],
      rolId: this.userForm.value['rolId']
    };

    this.systemUserService.createUser(newUser).subscribe({
      next: (res) => {
        alert(res.message);
        if (res.success) {
          this.userForm.reset();//
        }        
      },
      error: (error) => {
        if (error.error?.message) {
          alert(error.error.message);
        } else {
          alert('Error al crear usuario');
        }
      }
    });
  }
}
