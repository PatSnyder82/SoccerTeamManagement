import { IPerson } from "./person";
import { IPlayerAttributes } from "./player-attributes";
import { ITeam } from "./team";
import { IParent } from "./Parent";
import { IPlayerPosition } from "./joins/player-position";

export interface IPlayer extends IPerson {
  height: number;
  weight: number;
  foot: number;
  weakFootRating: number;
  flareRating: number;

  attributesId: number;
  attributes: IPlayerAttributes;
  teams: ITeam[];
  playerPositions: IPlayerPosition[];
  parents: IParent[];
}
