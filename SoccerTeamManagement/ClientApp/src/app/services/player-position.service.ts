import { HttpClient } from '@angular/common/http';
import { Inject } from '@angular/core';
import { Injectable } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Observable } from 'rxjs';
import { IPlayerPosition } from '../interfaces/joins/player-position';
import { BaseService } from './base.service';
import { PositionService } from './position.service';

@Injectable({
  providedIn: 'root'
})
export class PlayerPositionService extends BaseService<IPlayerPosition> {
  constructor(
    private formBuilder: FormBuilder,
    http: HttpClient, @Inject('BASE_URL') protected baseUrl: string,
    private positionService: PositionService
  ) {
    super(http, 'position/', baseUrl);
  }

  getById(id: number): Observable<IPlayerPosition> {
    return null;
  }

  public getFormGroup(): FormGroup {
    return this.formBuilder.group({
      isPrimary: [false],
      playerId: [null],
      positionId: [null],
      position: this.positionService.getFormGroup()
    });
  }
}
