import { NgModule } from '@angular/core';
import { AuthorizeInterceptor } from './interceptors/authorize.interceptor';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { HomeModule } from './components/features/home/home.module';
import { SharedModule } from './components/shared/shared.module';

import { AppComponent } from './components/features/app/app.component';
import { CounterComponent } from './components/features/counter/counter.component';  //TODO: DELETE
import { FetchDataComponent } from './components/features/fetch-data/fetch-data.component';  //TODO: DELETE
import { RouterModule } from '@angular/router';
import { BrowserModule } from '@angular/platform-browser';
import { PipesModule } from './pipes/pipes.module';
import { AddressModalModule } from './components/shared/address/modal/address-modal.module';
import { PlayerModule } from './components/features/player/player.module';
import { PhoneModule } from './components/features/phone/phone.module';
import { FeaturesModule } from './components/features/features.module';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';

@NgModule({
  declarations: [
    AppComponent,
    CounterComponent,  //TODO: DELETE
    FetchDataComponent  //TODO: DELETE
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    FeaturesModule,
    HomeModule,
    PhoneModule,
    PipesModule,
    PlayerModule,
    SharedModule,
    RouterModule,
    HttpClientModule,
    AddressModalModule,
    MatDatepickerModule,
    MatNativeDateModule
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthorizeInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
