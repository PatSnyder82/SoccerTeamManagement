import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ButtonCreateComponent } from './create/button-create.component';
import { MatButtonModule } from '@angular/material/button';
import { AppRoutingModule } from '../app-routing/app-routing.module';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { MatTooltipModule } from '@angular/material/tooltip';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

@NgModule({
  declarations: [
    ButtonCreateComponent
  ],
  imports: [
    AppRoutingModule,
    BrowserModule,
    BrowserAnimationsModule,
    CommonModule,
    FontAwesomeModule,
    MatButtonModule,
    MatTooltipModule
  ],
  exports: [
    ButtonCreateComponent
  ]
})
export class ButtonsModule { }
