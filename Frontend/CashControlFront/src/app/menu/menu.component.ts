import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MenuService } from '../core/services/menu.service';
import { MenuItem } from '../core/models/menu-item.model';
import { RouterModule } from '@angular/router';
import { MatIconModule } from '@angular/material/icon';
import { MatListModule } from '@angular/material/list';

@Component({
  standalone: true,
  selector: 'app-menu',
  imports: [CommonModule, RouterModule, MatIconModule, MatListModule],
  template: `
    <mat-nav-list>
      <a mat-list-item *ngFor="let item of menuItems" [routerLink]="item.route">
        <mat-icon>{{ item.icon }}</mat-icon>
        <span>{{ item.label }}</span>
      </a>
    </mat-nav-list>
  `
})
export class MenuComponent implements OnInit {
  menuItems: MenuItem[] = [];

  constructor(private menuService: MenuService) {}

  ngOnInit() {
    this.menuService.getMenu().subscribe(items => this.menuItems = items);
  }
}
