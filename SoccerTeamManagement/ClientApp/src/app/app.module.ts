import { NgModule } from '@angular/core';
import { AuthorizeInterceptor } from './interceptors/authorize.interceptor';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { HomeModule } from './components/features/home/home.module';
import { PlayerModule } from './components/features/player/player.module';
import { SharedModule } from './components/shared/shared.module';

import { AppComponent } from './components/features/app/app.component';
import { CounterComponent } from './components/features/counter/counter.component';  //TODO: DELETE
import { FetchDataComponent } from './components/features/fetch-data/fetch-data.component';  //TODO: DELETE
import { RouterModule } from '@angular/router';
import { BrowserModule } from '@angular/platform-browser';

@NgModule({
  declarations: [
    AppComponent,
    CounterComponent,  //TODO: DELETE
    FetchDataComponent  //TODO: DELETE
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HomeModule,
    PlayerModule,
    SharedModule,
    RouterModule
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthorizeInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
