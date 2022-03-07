import { NgModule } from '@angular/core';
import { ApiAuthLoginModule } from './login/api-auth-login.module';
import { ApiAuthLoginMenuModule } from './login-menu/api-auth-login-menu.module'
import { ApiAuthLogoutModule } from './logout/api-auth-logout.module';

@NgModule({
  imports: [
    ApiAuthLoginModule,
    ApiAuthLoginMenuModule,
    ApiAuthLogoutModule
  ],
  exports: [
    ApiAuthLoginModule,
    ApiAuthLoginMenuModule,
    ApiAuthLogoutModule
  ]
})
export class ApiAuthorizationModule { }
