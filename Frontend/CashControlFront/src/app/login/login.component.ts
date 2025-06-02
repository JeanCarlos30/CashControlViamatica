import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '../core/services/auth.service';
import { MenuService } from '../core/services/menu.service';
import { Router } from '@angular/router';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { LoadingComponent } from '../loading/loading.component';
import { LoginRequest, LoginResponse } from '../core/dtos/login.dto';
import { ApiResponse } from '../core/dtos/api-response.dto';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  standalone: true,
  selector: 'app-login',
  imports: [CommonModule, ReactiveFormsModule, MatInputModule, MatButtonModule, LoadingComponent],
  templateUrl: './login.component.html'
})
export class LoginComponent {
  loginForm: FormGroup;

  constructor(
    private fb: FormBuilder, 
    private authService: AuthService, 
    private menuService: MenuService, 
    private router: Router,
    private snackBar: MatSnackBar,) {
    this.loginForm = this.fb.group({
      username: [
        '',
        [
          Validators.required,
          Validators.minLength(8),
          Validators.maxLength(20),
          Validators.pattern(/^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,20}$/)
        ]
      ],
      password: [
        '',
        [
          Validators.required,
          Validators.minLength(8),
          Validators.maxLength(30),
          Validators.pattern(/^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,30}$/)
        ]
      ]
    });
  }

  get f() {
    return this.loginForm.controls;
  }

  onSubmit() {
    if (this.loginForm.invalid) return;
    const credenciales: LoginRequest = this.loginForm.value;
    this.authService.login(credenciales).subscribe({
      next: (res: ApiResponse<LoginResponse>) => {
        if(res.success && res.data) {
          this.authService.saveSession(res.data.jwt, res.data.userName, res.data.role, res.data.roleDescripcion, res.data.menu);
          this.menuService.loadMenu();
          this.router.navigate(['/welcome']);
        }        
      },
      error: (error) => {
        if (error.error?.message) {
          this.snackBar.open(error.error.message || 'Error al autenticarse', 'Cerrar', { duration: 3000 });
        } else {
          this.snackBar.open('Error al autenticarse', 'Cerrar', { duration: 3000 });
        }
      }
    });
  }
}
