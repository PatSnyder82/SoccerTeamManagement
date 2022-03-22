import { NgModule } from '@angular/core';
import { AddressPipe } from './address.pipe';
import { PhonePipe } from './phone.pipe';
import { PositionsPipe } from './positions.pipe';
import { TeamPipe } from './team.pipe';

@NgModule({
  declarations: [
    AddressPipe,
    PhonePipe,
    PositionsPipe,
    TeamPipe
  ],
  imports: [

  ],
  exports: [
    AddressPipe,
    PhonePipe,
    PositionsPipe,
    TeamPipe
  ]
})
export class PipesModule { }
