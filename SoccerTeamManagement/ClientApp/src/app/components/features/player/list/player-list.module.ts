import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSortModule } from '@angular/material/sort';
import { MatTableModule } from '@angular/material/table';

import { AppRoutingModule } from '../../../shared/app-routing/app-routing.module';
import { PlayerListComponent } from './player-list.component';

@NgModule({
  declarations: [
    PlayerListComponent
  ],
  imports: [
    AppRoutingModule,
    CommonModule,
    HttpClientModule,
    MatButtonModule,
    MatInputModule,
    MatPaginatorModule,
    MatSortModule,
    MatTableModule
  ],
  exports: [
    PlayerListComponent
  ]
})
export class PlayerListModule { }
