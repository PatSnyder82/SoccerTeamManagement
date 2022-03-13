import { NgModule } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { AddressModule } from './address/address.module';
import { ApiAuthorizationModule } from './api-auth/api-authorization.module';
import { NavModule } from './nav/nav.module';
import { StarRatingComponent } from './star-rating/star-rating.component';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';

@NgModule({
  declarations: [
    StarRatingComponent
  ],
  imports: [
    AddressModule,
    ApiAuthorizationModule,
    FontAwesomeModule,
    MatButtonModule,
    MatIconModule,
    MatSnackBarModule,
    NavModule
  ],
  exports: [
    AddressModule,
    ApiAuthorizationModule,
    NavModule,
    StarRatingComponent
  ]
})
export class SharedModule { }
