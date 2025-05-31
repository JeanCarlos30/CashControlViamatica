import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { RouterOutlet } from '@angular/router';
import { MenuComponent } from '../menu/menu.component';
import { AuthService } from '../core/services/auth.service';
import { LoadingComponent } from "../loading/loading.component";

@Component({
  standalone: true,
  selector: 'app-layout',
  imports: [
    CommonModule,
    RouterOutlet,
    MenuComponent,
    MatSidenavModule,
    MatToolbarModule,
    MatIconModule,
    MatButtonModule,
    LoadingComponent
],
  templateUrl: './layout.component.html'
})
export class LayoutComponent {

  constructor(private authService: AuthService) {  }

  logout() {
    this.authService.logout();
  }
}
