import { NgModule } from '@angular/core';
import { AddressPipe } from './address.pipe';
import { PhonePipe } from './phone.pipe';
import { PositionsPipe } from './positions.pipe';

@NgModule({
  declarations: [
    AddressPipe,
    PhonePipe,
    PositionsPipe
  ],
  imports: [

  ],
  exports: [
    AddressPipe,
    PhonePipe,
    PositionsPipe
  ]
})
export class PipesModule { }
