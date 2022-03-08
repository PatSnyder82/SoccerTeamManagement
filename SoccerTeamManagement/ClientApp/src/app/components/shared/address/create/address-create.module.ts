import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { MatButtonModule } from '@angular/material/button';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatCardModule } from '@angular/material/card';
import { MatSelectModule } from '@angular/material/select';
import { ReactiveFormsModule } from '@angular/forms';

import { AddressCreateComponent } from './address-create.component';


@NgModule({
  declarations: [
    AddressCreateComponent
  ],
  imports: [
    BrowserAnimationsModule,
    CommonModule,
    HttpClientModule,
    MatButtonModule,
    MatCardModule,
    MatExpansionModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    ReactiveFormsModule
  ],
  exports: [
    AddressCreateComponent
  ]
})
export class AddressCreateModule { }
