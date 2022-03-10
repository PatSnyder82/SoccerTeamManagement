import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { MatButtonModule } from '@angular/material/button';
import { MatButtonToggleModule } from '@angular/material/button-toggle';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatNativeDateModule } from '@angular/material/core';
import { MatSelectModule } from '@angular/material/select';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { ReactiveFormsModule } from '@angular/forms';
import { FormsModule } from '@angular/forms';

import { AppRoutingModule } from '../../../shared/app-routing/app-routing.module';
import { PlayerDetailsComponent } from './player-details.component';
import { AddressModule } from '../../../shared/address/address.module';
import { BaseModule } from '../../../base/base.module';
import { MatDialogModule } from '@angular/material/dialog';
import { PipesModule } from '../../../../pipes/pipes.module';

@NgModule({
  declarations: [
    PlayerDetailsComponent
  ],
  imports: [
    AddressModule,
    AppRoutingModule,
    BaseModule,
    CommonModule,
    FormsModule,
    HttpClientModule,
    MatButtonModule,
    MatButtonToggleModule,
    MatDatepickerModule,
    MatDialogModule,
    MatFormFieldModule,
    MatInputModule,
    MatNativeDateModule,
    MatSelectModule,
    MatSlideToggleModule,
    PipesModule,
    ReactiveFormsModule
  ],
  exports: [
    PlayerDetailsComponent
  ]
})
export class PlayerDetailsModule { }
