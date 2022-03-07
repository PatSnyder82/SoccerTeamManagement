import { NgModule } from '@angular/core';

import { AddressCreateModule } from './create/address-create.module';

@NgModule({
  imports: [
    AddressCreateModule
  ],
  exports: [
    AddressCreateModule
  ]
})
export class AddressModule { }
