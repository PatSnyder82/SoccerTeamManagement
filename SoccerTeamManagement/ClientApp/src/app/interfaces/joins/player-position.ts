import { IPosition } from '../lookups/position';

export interface IPlayerPosition {
  abbreviation: string;
  isPrimary: boolean;

  playerId: number;
  positionId: number;
  position: IPosition;
}
