import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ApiAuthLoginComponent } from '../api-auth/login/api-auth-login.component';
import { ApiAuthLogoutComponent } from '../api-auth/logout/api-auth-logout.component';
import { ApplicationPaths } from '../../../constants/api-authorization.constants';
import { AuthorizeGuard } from '../../../guards/authorize.guard';
import { CounterComponent } from '../../features/counter/counter.component';
import { FetchDataComponent } from '../../features/fetch-data/fetch-data.component';
import { HomeComponent } from '../../features/home/home.component';
import { PlayerDetailsComponent } from '../../features/player/details/player-details.component';
import { PlayerListComponent } from '../../features/player/list/player-list.component';

const routes: Routes = [
  { path: '', component: HomeComponent, pathMatch: 'full' },
  { path: 'counter', component: CounterComponent },
  { path: 'fetch-data', component: FetchDataComponent, canActivate: [AuthorizeGuard] },
  { path: 'players', component: PlayerListComponent },
  { path: 'player', component: PlayerDetailsComponent },
  { path: 'player/:id', component: PlayerDetailsComponent },
  { path: ApplicationPaths.Register, component: ApiAuthLoginComponent },
  { path: ApplicationPaths.Profile, component: ApiAuthLoginComponent },
  { path: ApplicationPaths.Login, component: ApiAuthLoginComponent },
  { path: ApplicationPaths.LoginFailed, component: ApiAuthLoginComponent },
  { path: ApplicationPaths.LoginCallback, component: ApiAuthLoginComponent },
  { path: ApplicationPaths.LogOut, component: ApiAuthLogoutComponent },
  { path: ApplicationPaths.LoggedOut, component: ApiAuthLogoutComponent },
  { path: ApplicationPaths.LogOutCallback, component: ApiAuthLogoutComponent }
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports: [
    RouterModule
  ]
})
export class AppRoutingModule { }
