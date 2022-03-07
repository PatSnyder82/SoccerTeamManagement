import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ApiAuthLoginComponent } from './api-auth-login.component';

@NgModule({
  declarations: [
    ApiAuthLoginComponent
  ],
  imports: [
    CommonModule
  ],
  exports: [
    ApiAuthLoginComponent
  ]
})
export class ApiAuthLoginModule { }
