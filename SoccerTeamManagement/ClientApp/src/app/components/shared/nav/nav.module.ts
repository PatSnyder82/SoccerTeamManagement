import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavTopMenuModule } from './top-menu/nav-top-menu.module';
import { SideMenuComponent } from './side-menu/side-menu.component';
import { MatIconModule } from '@angular/material/icon';
import { MatListModule } from '@angular/material/list';
import { MatTooltipModule } from '@angular/material/tooltip';
import { RouterModule } from '@angular/router';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { MatDividerModule } from '@angular/material/divider';
@NgModule({
  declarations: [
    SideMenuComponent
  ],
  imports: [
    CommonModule,
    FontAwesomeModule,
    NavTopMenuModule,
    MatDividerModule,
    MatIconModule,
    MatListModule,
    MatTooltipModule,
    RouterModule
  ],
  exports: [
    NavTopMenuModule,
    SideMenuComponent
  ],
})
export class NavModule { }
