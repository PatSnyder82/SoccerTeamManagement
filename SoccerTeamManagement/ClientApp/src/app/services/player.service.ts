import { HttpClient } from '@angular/common/http';
import { Inject } from '@angular/core';
import { Injectable } from '@angular/core';
import { IPlayer } from '../interfaces/player';
import { BaseService } from './base.service';

@Injectable({
  providedIn: 'root'
})
export class PlayerService extends BaseService<IPlayer> {
  constructor(http: HttpClient, @Inject('BASE_URL') protected baseUrl: string) {
    super(http, 'players/', baseUrl);
  }
}
