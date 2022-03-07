import { NgModule } from '@angular/core';
import { ApiAuthorizationModule } from '../../api-auth/api-authorization.module';
import { AppRoutingModule } from '../../app-routing/app-routing.module';
import { CommonModule } from '@angular/common';
import { NavTopMenuComponent } from './nav-top-menu.component';
import { RouterModule } from '@angular/router';

@NgModule({
  declarations: [
    NavTopMenuComponent
  ],
  imports: [
    ApiAuthorizationModule,
    AppRoutingModule,
    CommonModule,
    RouterModule
  ],
  providers: [],
  exports: [
    NavTopMenuComponent
  ]
})
export class NavTopMenuModule { }
