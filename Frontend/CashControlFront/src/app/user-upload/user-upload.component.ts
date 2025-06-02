import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';

@Component({
  standalone: true,
  selector: 'app-user-upload',
  templateUrl: './user-upload.component.html',
  styleUrls: ['./user-upload.component.css'],
  imports: [CommonModule, MatCardModule, MatButtonModule]
})
export class UserUploadComponent {
  uploadResult: string = '';

  onFileChange(event: any) {
    // TODO: procesar archivo Excel/CSV
    this.uploadResult = 'Archivo procesado (mock)';
  }

  upload() {
    // TODO: enviar datos al backend
    alert('Usuarios cargados (mock)');
  }
}
