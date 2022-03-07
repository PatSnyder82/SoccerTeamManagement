import { NgModule } from '@angular/core';

import { PlayerDetailsModule } from './details/player-details.module';
import { PlayerListModule } from './list/player-list.module';

@NgModule({
  imports: [
    PlayerDetailsModule,
    PlayerListModule,
  ],
  exports: [
    PlayerDetailsModule,
    PlayerListModule]
})
export class PlayerModule { }
