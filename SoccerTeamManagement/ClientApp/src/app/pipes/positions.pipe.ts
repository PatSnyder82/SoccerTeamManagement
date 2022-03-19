import { Pipe, PipeTransform } from '@angular/core';
import { IPlayerPosition } from '../interfaces/joins/player-position';
import { IPosition } from '../interfaces/lookups/position';

@Pipe({
  name: 'positions',
  pure: false
})
export class PositionsPipe implements PipeTransform {
  transform(positions: IPosition[], numberPositions: number = 5): string {
    let value: string = 'None';
    let index = 0;

    if (positions && positions?.length > 0) {
      value = '';
      positions.forEach(position => {
        if (index === 0) {
          value += position?.abbreviation;
        }
        else if (index < numberPositions) {
          value += ", " + position?.abbreviation;
        }

        index++;
      });
    }

    return value;
  }

}
