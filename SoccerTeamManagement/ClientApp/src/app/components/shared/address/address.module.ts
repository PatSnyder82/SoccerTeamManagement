import { NgModule } from '@angular/core';

import { AddressDetailsModule } from './details/address-details.module';
import { AddressModalModule } from './modal/address-modal.module';

@NgModule({
  imports: [
    AddressDetailsModule,
    AddressModalModule
  ],
  exports: [
    AddressDetailsModule,
    AddressModalModule
  ]
})
export class AddressModule { }
