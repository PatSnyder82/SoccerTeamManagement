import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavTopMenuModule } from './top-menu/nav-top-menu.module';

@NgModule({
  imports: [
    CommonModule,
    NavTopMenuModule
  ],
  exports: [
    NavTopMenuModule
  ]
})
export class NavModule { }
