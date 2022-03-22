import { HttpClient } from '@angular/common/http';
import { Inject } from '@angular/core';
import { Injectable } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { IPlayerPosition } from '../interfaces/joins/player-position';
import { IPosition } from '../interfaces/lookups/position';
import { BaseService } from './base.service';
import { PositionCategoryService } from './position-category.service';

@Injectable({
  providedIn: 'root'
})
export class PositionService extends BaseService<IPosition> {
  constructor(
    private formBuilder: FormBuilder,
    http: HttpClient, @Inject('BASE_URL') protected baseUrl: string,
    private positionCategoryService: PositionCategoryService
  ) {
    super(http, 'position/', baseUrl);
  }

  public getFormGroup(): FormGroup {
    return this.formBuilder.group({
      id: [0],
      category: [null],
      isDisabled: [false],
      isPrimary: [false],
      sortOrder: [null],
      text: [null, [Validators.required]],
      value: [null, [Validators.required]],
      abbreviation: [null, [Validators.required]],
      positionCategoryId: [null, [Validators.required]],
      positionCategory: this.positionCategoryService.getFormGroup()
    });
  }

  public toPlayerPositions(positions: IPosition[], playerId: number): IPlayerPosition[] {
    const playerPositions = [] as IPlayerPosition[];
    //const playerId = this.form.get('id').value;

    if (positions && positions.length > 0) {
      positions.forEach(position => {
        const playerPosition = {} as IPlayerPosition;

        playerPosition.abbreviation = position.abbreviation;
        playerPosition.isPrimary = position.isPrimary;
        playerPosition.positionId = position.id;
        playerPosition.playerId = playerId;
        playerPositions.push(playerPosition);
      });
    }

    return playerPositions;
  }

  public toPositions(playerPositions: IPlayerPosition[]): IPosition[] {
    const positions = [] as IPosition[];
    if (playerPositions) {
      playerPositions.forEach(playerPosition => {
        let position = {} as IPosition;
        position = playerPosition.position;
        positions.push(position);
      });
    }
    return positions;
  }
}
