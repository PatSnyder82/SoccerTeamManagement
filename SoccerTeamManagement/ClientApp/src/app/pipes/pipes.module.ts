import { NgModule } from '@angular/core';
import { AddressPipe } from './address.pipe';
import { PhonePipe } from './phone.pipe';

@NgModule({
  declarations: [
    AddressPipe,
    PhonePipe
  ],
  imports: [

  ],
  exports: [
    AddressPipe,
    PhonePipe
  ]
})
export class PipesModule { }
