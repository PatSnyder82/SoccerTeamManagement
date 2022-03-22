import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TeamModule } from './team/team.module';

@NgModule({
  imports: [
    CommonModule,
    TeamModule
  ],
  exports: [
    TeamModule
  ]
})
export class FeaturesModule { }
