import { NgModule } from '@angular/core';

import { AddressDetailsModule } from './details/address-details.module';

@NgModule({
  imports: [
    AddressDetailsModule
  ],
  exports: [
    AddressDetailsModule
  ]
})
export class AddressModule { }
