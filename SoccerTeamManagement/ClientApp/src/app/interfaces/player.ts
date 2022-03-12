import { IPerson } from "./person";
import { IPlayerAttributes } from "./playerAttributes";
import { IPosition } from "./lookups/position";
import { ITeam } from "./team";
import { IParent } from "./Parent";

export interface IPlayer extends IPerson {
  height: number;
  weight: number;
  foot: string;
  weakFootRating: number;
  flareRating: number;

  attributesId: number;
  attributes: IPlayerAttributes;
  teams: ITeam[];
  position: IPosition[];
  parents: IParent[];
}
