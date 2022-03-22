import { IPerson } from "./person";
import { IPlayerAttributes } from "./player-attributes";
import { IParent } from "./Parent";
import { IPlayerPosition } from "./joins/player-position";
import { ITeamPlayer } from "./joins/team-player";

export interface IPlayer extends IPerson {
  height: number;
  weight: number;
  foot: number;
  weakFootRating: number;
  flareRating: number;

  attributesId: number;
  attributes: IPlayerAttributes;
  teamPlayers: ITeamPlayer[];
  playerPositions: IPlayerPosition[];
  parents: IParent[];
}
