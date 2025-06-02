import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormBuilder, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatButtonModule } from '@angular/material/button';
import { ActivatedRoute, Router } from '@angular/router';
import { UserService } from '../core/services/user.service';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  standalone: true,
  selector: 'app-user-edit',
  templateUrl: './user-edit.component.html',
  styleUrls: ['./user-edit.component.css'],
  imports: [
    CommonModule, ReactiveFormsModule, MatCardModule,
    MatFormFieldModule, MatInputModule, MatSelectModule, MatButtonModule
  ]
})
export class UserEditComponent implements OnInit {
  userForm!: FormGroup;

  constructor(
    private fb: FormBuilder, 
    private route: ActivatedRoute,
    private userService: UserService,
    private router: Router,
    private snackBar: MatSnackBar,) {
      this.userForm = this.fb.group({
      userName: [''],
      email: [''],
      rolId: [null],
      status: ['']
    });
    }

  ngOnInit(): void {
    const userId = this.route.snapshot.paramMap.get('id');
    if (userId) {
      this.userService.getUserById(+userId).subscribe(resp => {
        if (resp.success && resp.data) {
          this.userForm.patchValue(resp.data);
        }
      });
    } else {
      // Manejar el caso donde no se proporciona un ID de usuario
      console.error('No se proporcionó un ID de usuario');
      this.router.navigate(['/user-list']);
    }
  }

  onSubmit() {
    if (this.userForm.invalid) return;
    const userId = this.route.snapshot.paramMap.get('id');
    if (!userId) return;
  
    this.userService.updateUser(+userId, this.userForm.value).subscribe({
      next: (res) => {
        if (res.success) {
          this.snackBar.open(res.message || 'Usuario actualizado correctamente', 'Cerrar', { duration: 3000 });
          this.router.navigate(['/user-list']);
        } else {
          this.snackBar.open(res.message || 'No se pudo actualizar el usuario', 'Cerrar', { duration: 3000 });
        }
      },
      error: (error) => {
        if (error.error?.message) {
          this.snackBar.open(error.error.message || 'Error al autenticarse', 'Cerrar', { duration: 3000 });
        } else {
          this.snackBar.open('Error al actualizar el usuario', 'Cerrar', { duration: 3000 });
        }
      }
    });
  }

  cancel() {
    this.router.navigate(['/user-list']);
  }
}
