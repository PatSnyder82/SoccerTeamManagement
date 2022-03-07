import { NgModule } from '@angular/core';
import { AddressModule } from './address/address.module';
import { ApiAuthorizationModule } from './api-auth/api-authorization.module';
import { NavModule } from './nav/nav.module';

@NgModule({
  imports: [
    AddressModule,
    ApiAuthorizationModule,
    NavModule
  ],
  exports: [
    AddressModule,
    ApiAuthorizationModule,
    NavModule
  ]
})
export class SharedModule { }
