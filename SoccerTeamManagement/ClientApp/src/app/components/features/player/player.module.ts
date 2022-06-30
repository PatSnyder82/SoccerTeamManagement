import { NgModule } from '@angular/core';
import { AppRoutingModule } from '../../shared/app-routing/app-routing.module';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
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
import { PlayerDetailsComponent } from './details/player-details.component';
import { BaseModule } from '../../base/base.module';
import { MatDialogModule } from '@angular/material/dialog';
import { PipesModule } from '../../../pipes/pipes.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatCardModule } from '@angular/material/card';
import { BrowserModule } from '@angular/platform-browser';
import { AddressModule } from '../../shared/address/address.module';
import { PlayerListComponent } from './list/player-list.component';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSortModule } from '@angular/material/sort';
import { MatTableModule } from '@angular/material/table';
import { PhoneModule } from '../phone/phone.module';
import { SharedModule } from '../../shared/shared.module';
import { NavModule } from '../../shared/nav/nav.module';
import { ButtonsModule } from '../../shared/buttons/buttons.module';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';

@NgModule({
  declarations: [
    PlayerDetailsComponent,
    PlayerListComponent
  ],
  imports: [
    AddressModule,
    AppRoutingModule,
    BaseModule,
    BrowserModule,
    BrowserAnimationsModule,
    ButtonsModule,
    CommonModule,
    FontAwesomeModule,
    FormsModule,
    HttpClientModule,
    MatButtonModule,
    MatButtonToggleModule,
    MatCardModule,
    MatDatepickerModule,
    MatDialogModule,
    MatFormFieldModule,
    MatInputModule,
    MatNativeDateModule,
    MatPaginatorModule,
    MatSelectModule,
    MatSlideToggleModule,
    MatSortModule,
    MatTableModule,
    NavModule,
    PhoneModule,
    PipesModule,
    ReactiveFormsModule,
    SharedModule
  ],
  exports: [
    PlayerDetailsComponent,
    PlayerListComponent
  ]
})
export class PlayerModule { }
