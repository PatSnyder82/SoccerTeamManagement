import { NgModule } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { AddressModule } from './address/address.module';
import { ApiAuthorizationModule } from './api-auth/api-authorization.module';
import { NavModule } from './nav/nav.module';
import { StarRatingComponent } from './star-rating/star-rating.component';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { CheckboxComponent } from './checkbox/checkbox.component';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { MatTooltipModule } from '@angular/material/tooltip';
import { ButtonsModule } from './buttons/buttons.module';

@NgModule({
  declarations: [
    StarRatingComponent,
    CheckboxComponent
  ],
  imports: [
    AddressModule,
    ApiAuthorizationModule,
    BrowserModule,
    CommonModule,
    FontAwesomeModule,
    FormsModule,
    MatButtonModule,
    MatIconModule,
    MatSnackBarModule,
    MatTooltipModule,
    NavModule,
    ReactiveFormsModule,
    ButtonsModule
  ],
  exports: [
    AddressModule,
    ApiAuthorizationModule,
    CheckboxComponent,
    NavModule,
    StarRatingComponent
  ]
})
export class SharedModule { }
