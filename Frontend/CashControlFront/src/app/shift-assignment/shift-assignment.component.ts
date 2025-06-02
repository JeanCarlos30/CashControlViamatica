import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormBuilder, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatButtonModule } from '@angular/material/button';
import { CreateTurnRequest } from '../core/dtos/create-turn.dto';
import { TurnService } from '../core/services/turn.service';
import { ApiResponse } from '../core/dtos/api-response.dto';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  standalone: true,
  selector: 'app-shift-assignment',
  templateUrl: './shift-assignment.component.html',
  styleUrls: ['./shift-assignment.component.css'],
  imports: [
    CommonModule, ReactiveFormsModule, MatCardModule,
    MatFormFieldModule, MatInputModule, MatSelectModule, MatButtonModule
  ]
})
export class ShiftAssignmentComponent implements OnInit {
  shiftForm!: FormGroup;
  cajeros = [
    { id: 1, nombre: 'Cajero 1' },
    { id: 2, nombre: 'Cajero 2' }
  ];

  constructor(
    private fb: FormBuilder,
    private turnService: TurnService,
    private snackBar: MatSnackBar
  ) {}

  ngOnInit(): void {
    this.shiftForm = this.fb.group({
      cashId: [null],
      description: [''],
      dateTurn: ['']
    });
  }

  onSubmit() {
    if (this.shiftForm.invalid) return;
    
    const newTurn: CreateTurnRequest = this.shiftForm.value;

    this.turnService.createTurn(newTurn).subscribe({
      next: (res: ApiResponse<null>) => {
        this.snackBar.open(res.message || 'Usuario creado', 'Cerrar', { duration: 3000 });
        if (res.success) {
          this.shiftForm.reset();
          this.shiftForm.markAsPristine();
          this.shiftForm.markAsUntouched();
        }        
      },
      error: (error) => {
        if (error.error?.message) {
          this.snackBar.open(error.error.message || 'Error al crear el turno', 'Cerrar', { duration: 3000 });
        } else {
          this.snackBar.open('Error al crear el turno', 'Cerrar', { duration: 3000 });
        }
      }
    });
  }
}
